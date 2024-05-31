// C# class generated with assistance from ChatGPT


using AgriEnergyConnect1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgriEnergyConnect1.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Farmer", "Employee" };
            IdentityResult roleResult;

            // Create roles if they don't exist
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a test user and assign the appropriate role
            var user = new IdentityUser
            {
                UserName = "testuser@test.com",
                Email = "testuser@test.com",
            };

            string userPassword = "Password@123";
            var userExists = await userManager.FindByEmailAsync("testuser@test.com");

            if (userExists == null)
            {
                var createUser = await userManager.CreateAsync(user, userPassword);
                if (createUser.Succeeded)
                {
                    // Assign the "Farmer" role to this test user
                    await userManager.AddToRoleAsync(user, "Farmer");
                }
            }
       

        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            // Seed sample farmers if the table is empty
            if (!context.Farmers.Any())
            {
                context.Farmers.AddRange(
                    new Farmer { Name = "John Doe", Email = "john@example.com" },
                    new Farmer { Name = "Jane Smith", Email = "jane@example.com" },
                    new Farmer { Name = "Liam Delon", Email = "Liam@example.com" }

                );
                await context.SaveChangesAsync();
            }

            // Seed sample products if the table is empty
            if (!context.Products.Any())
            {
                var farmer = await context.Farmers.FirstOrDefaultAsync();
                context.Products.AddRange(
                    new Product { Name = "Wheat", Category = "Grain", ProductionDate = DateTime.Now.AddDays(-30), FarmerId = farmer.FarmerId },
                    new Product { Name = "Corn", Category = "Grain", ProductionDate = DateTime.Now.AddDays(-60), FarmerId = farmer.FarmerId }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}