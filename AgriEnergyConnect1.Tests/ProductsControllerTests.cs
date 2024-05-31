using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect1.Controllers;
using AgriEnergyConnect1.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using AgriEnergyConnect1.Data;

public class ProductsControllerTests
{
    [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfProducts()
    {
        var mockLogger = new Mock<ILogger<ProductsController>>();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var controller = new ProductsController(mockDbContext.Object, mockLogger.Object);

        var result = await controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<Product>>(viewResult.ViewData.Model);
        Assert.NotNull(model);
    }

    // Add more tests for other action methods
}
