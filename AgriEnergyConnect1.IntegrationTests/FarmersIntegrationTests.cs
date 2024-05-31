// C# class generated with assistance from ChatGPT


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;
using AgriEnergyConnect1;
using Microsoft.AspNetCore.Hosting;


namespace AgriEnergyConnect1.IntegrationTests
{
    public class FarmersIntegrationTests : IClassFixture<WebApplicationFactory<IStartup>>
    {
        private readonly WebApplicationFactory<IStartup> _factory;

        public FarmersIntegrationTests(WebApplicationFactory<IStartup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateFarmer_WithValidData_ReturnsRedirectToIndex()
        {
            // Arrange
            var client = _factory.CreateClient();
            var createRequest = new HttpRequestMessage(HttpMethod.Post, "/Farmers/Create");
            var formData = new Dictionary<string, string>
        {
            { "Name", "John Doe" },
            { "Email", "john@example.com" }
        };
            createRequest.Content = new FormUrlEncodedContent(formData);

            // Act
            var createResponse = await client.SendAsync(createRequest);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, createResponse.StatusCode);
            Assert.Equal("/Farmers", createResponse.Headers.Location.OriginalString);
        }

        // Add more tests for other actions like Edit, Delete, etc.
    }
}