using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var defaultUser = new ApplicationUser
            {
                UserName = "userAdmin",
                Email = "useradmin@mail.com",
                Nombre = "Juan Pablo",
                Apellido = "Sanabria Moscoso",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (await userManager.FindByEmailAsync(defaultUser.Email) == null)
            {
                await userManager.CreateAsync(defaultUser, "Pablo161718!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }
        }
    }
}
