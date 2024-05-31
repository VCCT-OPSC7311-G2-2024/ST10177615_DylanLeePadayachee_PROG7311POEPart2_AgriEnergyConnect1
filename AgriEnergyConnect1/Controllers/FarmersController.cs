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
using Microsoft.Extensions.Logging;


namespace AgriEnergyConnect1.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FarmersController> _logger;

        public FarmersController(ApplicationDbContext context, ILogger<FarmersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public FarmersController()
        {
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Farmers.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving farmers.");
                TempData["ErrorMessage"] = "An error occurred while retrieving farmers.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,Name,Email")] Farmer farmer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(farmer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(farmer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a farmer.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again.");
                return View(farmer);
            }
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,Name,Email")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(farmer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(farmer.FarmerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing a farmer.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again.");
                return View(farmer);
            }
        }
        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FirstOrDefaultAsync(m => m.FarmerId == id);

            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }


        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var farmer = await _context.Farmers.FindAsync(id);
                _context.Farmers.Remove(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting a farmer.");
                TempData["ErrorMessage"] = "An error occurred while deleting the farmer.";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerId == id);
        }
    }
}