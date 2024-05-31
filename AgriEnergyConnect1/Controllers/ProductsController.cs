// C# class generated with assistance from ChatGPT


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect1.Data;
using AgriEnergyConnect1.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnect1.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(p => p.Farmer).ToListAsync());
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Category,ProductionDate")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
                    var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == user.Email);
                    product.FarmerId = farmer.FarmerId;

                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the product.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again.");
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Category,ProductionDate,FarmerId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "A concurrency error occurred while editing the product.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing the product.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again.");
                return View(product);
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(p => p.Farmer).FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // Additional method to filter products
        [HttpGet]
        public async Task<IActionResult> Index(string category, DateTime? startDate, DateTime? endDate)
        {
            var products = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            if (startDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= endDate.Value);
            }

            return View(await products.ToListAsync());
        }

        // Add a new action for displaying all products
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            var allProducts = await _context.Products.Include(p => p.Farmer).ToListAsync();
            return View(allProducts);
        }
    }
}
