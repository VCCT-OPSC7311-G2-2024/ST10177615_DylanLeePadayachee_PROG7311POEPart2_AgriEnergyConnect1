using AgriEnergyConnect1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriEnergyConnect1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action to render the home page
        public IActionResult Index()
        {
            _logger.LogInformation("Rendering the Index view.");
            return View();
        }

        // Action to render the privacy policy page
        public IActionResult Privacy()
        {
            _logger.LogInformation("Rendering the Privacy view.");
            return View();
        }

        // Action to render an error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("An error occurred with RequestId: {RequestId}", requestId);
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}