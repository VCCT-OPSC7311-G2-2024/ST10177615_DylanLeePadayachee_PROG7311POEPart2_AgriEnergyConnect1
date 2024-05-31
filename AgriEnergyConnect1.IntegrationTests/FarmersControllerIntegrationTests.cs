// C# class generated with assistance from ChatGPT


using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using AgriEnergyConnect1;
using System.Net.Http;
using Microsoft.VisualStudio.TestPlatform.TestHost;

public class FarmersControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public FarmersControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_FarmersIndex_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Farmers");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }

    // Write similar tests for other actions
}
