using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Persistence.Extensions
{
    public static class DataExtensions
    {
        public static void CreateData(this ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(DepartmentData());

            UserManager<ApplicationUser> userManager;
            RoleManager<ApplicationRole> roleManager;

        }

        public static List<Department> DepartmentData()
        {
            var departments = new List<Department>()
            {
                new()
                {
                    Id = 1,
                    Name = "Satış",
                },
                new()
                {
                    Id = 2,
                    Name = "Satınalma",
                },
                new()
                {
                    Id = 3,
                    Name = "Yazılım Geliştirme",
                },
                new()
                {
                    Id = 4,
                    Name = "Eğitim",
                }
            };

            return departments;
        }

        public static async Task SeedEssentialAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //Seed roles
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = Authorization.default_username,
                Email = Authorization.default_email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.default_password);
                await userManager.AddToRoleAsync(defaultUser, Authorization.default_role.ToString());
            }
        }
    }

    


}
