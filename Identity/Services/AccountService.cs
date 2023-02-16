using Application.DTOs.Users;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSettings jwtSettings;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDateTimeService dateTimeService;

        public AccountService(UserManager<ApplicationUser> userManager, JWTSettings jwtSettings, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IDateTimeService dateTimeService)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.dateTimeService = dateTimeService;
        }

        public Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            throw new NotImplementedException();
        }
    }
}
