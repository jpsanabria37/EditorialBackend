using Application.DTOs.Users;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Identity.Helpers;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDateTimeService dateTimeService;
        private readonly JWTSettings _jwtSettings;
        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IDateTimeService dateTimeService, IOptions<JWTSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.dateTimeService = dateTimeService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await userManager.FindByNameAsync(request.UserName) ?? await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException("Nombre de usuario o correo electrónico incorrectos");
            }

            // Verificar la contraseña
            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException("Nombre de usuario o contraseña incorrectos");
            }

            var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            var userClaims = await userManager.GetClaimsAsync(user);
            // Crear un token JWT
            var jwtHelper = new JWTHelper(_jwtSettings);


            var token = await  jwtHelper.GenerateJwtTokenAsync(user,roles, userClaims);
            var refreshToken = await JWTHelper.GenerateRefreshTokenAsync(ipAddress);
            var authenticationResponse = new AuthenticationResponse
            {
                JWToken = token,
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList(),
                IsVerified = user.EmailConfirmed,
                RefreshToken = refreshToken.Token
            };

            return new Response<AuthenticationResponse>(authenticationResponse, $"usuario autenticado {user.UserName}");
            

        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var existingUserName = await userManager.FindByNameAsync(request.UserName);
            if (existingUserName != null)
            {
                throw new ApiException($"el nombre de usuario {request.UserName} ya esta en uso.");
            }

            var existingEmail = await userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                throw new ApiException($"el correo electronico {request.Email} ya esta en uso.");
            }

            var newUser = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                EmailConfirmed = true, // Si desea que los usuarios confirmen su correo electrónico, esto debe ser false
                PhoneNumberConfirmed = true
            };

            var result = await userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                throw new ApiException("No se pudo crear la cuenta");
            }

            var roleResult = await userManager.AddToRoleAsync(newUser, Roles.Basic.ToString());
            if (!roleResult.Succeeded)
            {
                throw new ApiException("No se pudo asignar el rol");
            }

            return new Response<string>(newUser.Id, message: $"Usuario registrado correctamente. {newUser.UserName}");
        }
    }
}
