// C# class generated with assistance from ChatGPT


using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect1.Controllers;
using AgriEnergyConnect1.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AgriEnergyConnect1.Data;
using Microsoft.EntityFrameworkCore;

public class FarmersControllerTests
{
    [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfFarmers()
    {
        var mockLogger = new Mock<ILogger<FarmersController>>();
        var mockDbContext = new Mock<ApplicationDbContext>();

        // Mock data for Farmers
        var farmers = new List<Farmer>
        {
            new Farmer { Id = 1, Name = "Farmer1" },
            new Farmer { Id = 2, Name = "Farmer2" }
        };

        var mockFarmersDbSet = new Mock<DbSet<Farmer>>();
        mockFarmersDbSet.As<IQueryable<Farmer>>().Setup(m => m.Provider).Returns(farmers.AsQueryable().Provider);
        mockFarmersDbSet.As<IQueryable<Farmer>>().Setup(m => m.Expression).Returns(farmers.AsQueryable().Expression);
        mockFarmersDbSet.As<IQueryable<Farmer>>().Setup(m => m.ElementType).Returns(farmers.AsQueryable().ElementType);
        mockFarmersDbSet.As<IQueryable<Farmer>>().Setup(m => m.GetEnumerator()).Returns(farmers.AsQueryable().GetEnumerator());

        mockDbContext.Setup(c => c.Farmers).Returns(mockFarmersDbSet.Object);

        var controller = new FarmersController(mockDbContext.Object, mockLogger.Object);

        var result = await controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<Farmer>>(viewResult.ViewData.Model);
        Assert.NotNull(model);
    }

    [Fact]
    public async Task DeleteView_ReturnsView()
    {
        var mockLogger = new Mock<ILogger<FarmersController>>();
        var mockDbContext = new Mock<ApplicationDbContext>();

        var farmer = new Farmer { Id = 1, Name = "Farmer1" };
        var mockFarmersDbSet = new Mock<DbSet<Farmer>>();
        mockFarmersDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(farmer);
        mockDbContext.Setup(c => c.Farmers).Returns(mockFarmersDbSet.Object);

        var controller = new FarmersController(mockDbContext.Object, mockLogger.Object);

        var result = await controller.Delete(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Farmer>(viewResult.ViewData.Model);
        Assert.NotNull(model);
    }

    [Fact]
    public async Task DetailsView_ReturnsView()
    {
        var mockLogger = new Mock<ILogger<FarmersController>>();
        var mockDbContext = new Mock<ApplicationDbContext>();

        var farmer = new Farmer { Id = 1, Name = "Farmer1" };
        var mockFarmersDbSet = new Mock<DbSet<Farmer>>();
        mockFarmersDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(farmer);
        mockDbContext.Setup(c => c.Farmers).Returns(mockFarmersDbSet.Object);

        var controller = new FarmersController(mockDbContext.Object, mockLogger.Object);

        var result = await controller.Details(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Farmer>(viewResult.ViewData.Model);
        Assert.NotNull(model);
    }

    [Fact]
    public async Task EditView_ReturnsView()
    {
        var mockLogger = new Mock<ILogger<FarmersController>>();
        var mockDbContext = new Mock<ApplicationDbContext>();

        var farmer = new Farmer { Id = 1, Name = "Farmer1" };
        var mockFarmersDbSet = new Mock<DbSet<Farmer>>();
        mockFarmersDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(farmer);
        mockDbContext.Setup(c => c.Farmers).Returns(mockFarmersDbSet.Object);

        var controller = new FarmersController(mockDbContext.Object, mockLogger.Object);

        var result = await controller.Edit(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Farmer>(viewResult.ViewData.Model);
        Assert.NotNull(model);
    }
}
