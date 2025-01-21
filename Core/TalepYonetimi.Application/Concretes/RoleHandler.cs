using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Concretes
{
    public static class UserRoleHandler
    {
        public static async Task AddingUserRole(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // role tanımlıyoruz. bu metodu program.cs den çağıracağız.

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>(); // roleManager için instance aldık. DI yönte dışında service çağırma yöntemi (serviceProvider)
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>(); 

            string[] roleNames = configuration.GetSection("RoleSettings:Roles").Get<string[]>(); // appsettings ten role leri çekiyoruz.

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new() { Name = roleName });
                }
            }

            var userSetting = configuration.GetSection("UserSettings");
            var email = userSetting["Email"];
            var username = userSetting["Username"];
            var password = userSetting["Password"];
            var role = userSetting["RoleName"];

            ApplicationUser existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                var user = new ApplicationUser
                {
                    Email = email,
                    UserName = username,
                };

                var result = await userManager.CreateAsync(user,password);
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new ApplicationRole { Name = role });
                    }

                    var addRole = await userManager.AddToRoleAsync(user, role);
                    var addRole2 = await userManager.AddToRoleAsync(user, "Admin");
                    // admin, departmanına gelen talepleri günceller, siler. superadmin gelen tüm taleplere departman ataması yapar.
                    // bu yüzden superadmin olan kişi hem superadmin hem admin olmalı.

                }
            }
        }
    }
}
