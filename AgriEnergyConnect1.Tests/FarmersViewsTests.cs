using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect1.Controllers;

namespace AgriEnergyConnect1.Tests
{
    public class FarmersViewsTests
    {
        [Fact]
        public async Task CreateView_ReturnsView()
        {
            // Arrange
            var controller = new FarmersController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.NotNull(result as ViewResult);
        }

        [Fact]
        public async Task DeleteView_ReturnsView()
        {
            // Arrange
            var controller = new FarmersController();

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.NotNull(result as ViewResult);
        }

        [Fact]
        public async Task DetailsView_ReturnsView()
        {
            // Arrange
            var controller = new FarmersController();

            // Act
            var result = await controller.Details(1);

            // Assert
            Assert.NotNull(result as ViewResult);
        }

        [Fact]
        public async Task EditView_ReturnsView()
        {
            // Arrange
            var controller = new FarmersController();

            // Act
            var result = await controller.Edit(1);

            // Assert
            Assert.NotNull(result as ViewResult);
        }

        [Fact]
        public async Task IndexView_ReturnsView()
        {
            // Arrange
            var controller = new FarmersController();

            // Act
            var result = await controller.Index();

            // Assert
            Assert.NotNull(result as ViewResult);
        }
    }
}
