// C# class generated with assistance from ChatGPT


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgriEnergyConnect1.IntegrationTests
{
    public class ProductsIntegrationTests : IClassFixture<WebApplicationFactory<IStartup>>
    {
        private readonly WebApplicationFactory<IStartup> _factory;

        public ProductsIntegrationTests(WebApplicationFactory<IStartup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateProduct_WithValidData_ReturnsRedirectToIndex()
        {
            var client = _factory.CreateClient();
            var createRequest = new HttpRequestMessage(HttpMethod.Post, "/Products/Create");
            var formData = new Dictionary<string, string>
            {
                { "Name", "Wheat" },
                { "Category", "Grains" },
                { "ProductionDate", "2022-01-01" }
            };
            createRequest.Content = new FormUrlEncodedContent(formData);

            var createResponse = await client.SendAsync(createRequest);

            Assert.Equal(HttpStatusCode.Redirect, createResponse.StatusCode);
            Assert.Equal("/Products", createResponse.Headers.Location.OriginalString);
        }

        // Add more tests for other actions like Edit, Delete, etc.
    }
}