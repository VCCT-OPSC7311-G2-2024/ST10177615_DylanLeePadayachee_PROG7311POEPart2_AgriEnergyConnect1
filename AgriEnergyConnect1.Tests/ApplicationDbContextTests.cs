using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AgriEnergyConnect1.Data;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect1.Tests
{
    public class ApplicationDbContextTests
    {
        [Fact]
        public void ApplicationDbContext_EnsuresDatabaseCreation()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                // Assert
                Assert.NotNull(context);
                Assert.True(context.Database.EnsureCreated());
            }
        }
    }
}