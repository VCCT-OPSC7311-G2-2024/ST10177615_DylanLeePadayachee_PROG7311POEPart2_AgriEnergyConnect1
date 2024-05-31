// C# class generated with assistance from ChatGPT


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriEnergyConnect1.IntegrationTests
{
    public class ProductsControllerIntegrationTests : IClassFixture<WebApplicationFactory<IStartup>>
    {
        private readonly WebApplicationFactory<IStartup> _factory;

        public ProductsControllerIntegrationTests(WebApplicationFactory<IStartup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_ProductsIndex_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Products");
            response.EnsureSuccessStatusCode();
        }

        // Add more tests for other actions
    }
}