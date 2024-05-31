// C# class generated with assistance from ChatGPT


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AgriEnergyConnect1.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace AgriEnergyConnect1.IntegrationTests
{
    public class SeedDataIntegrationTests
    {
        [Fact]
        public async Task SeedData_EnsuresFarmerAndProductSeeding()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AgriEnergyDB")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userManager = GetUserManager(context);
                var roleManager = GetRoleManager(context);

                // Act
                await SeedData.Initialize(serviceProvider, userManager, roleManager);

                // Assert
                Assert.True(await context.Farmers.CountAsync() > 0);
                Assert.True(await context.Products.CountAsync() > 0);
            }
        }

        private UserManager<IdentityUser> GetUserManager(ApplicationDbContext context)
        {
            var userStore = new UserStore<IdentityUser>(context);
            return new UserManager<IdentityUser>(userStore, null, null, null, null, null, null, null, null);
        }

        private RoleManager<IdentityRole> GetRoleManager(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            return new RoleManager<IdentityRole>(roleStore, null, null, null, null);
        }
    }
}