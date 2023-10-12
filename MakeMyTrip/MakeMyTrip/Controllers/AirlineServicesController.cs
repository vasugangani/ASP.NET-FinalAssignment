using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakeMyTrip.Data;
using MakeMyTripTravelPlan.Models;

namespace MakeMyTrip.Controllers
{
    public class AirlineServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlineServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AirlineServices
        public async Task<IActionResult> Index()
        {
              return _context.AirlineService != null ? 
                          View(await _context.AirlineService.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AirlineService'  is null.");
        }

        // GET: AirlineServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AirlineService == null)
            {
                return NotFound();
            }

            var airlineService = await _context.AirlineService
                .FirstOrDefaultAsync(m => m.AirlineSeriveId == id);
            if (airlineService == null)
            {
                return NotFound();
            }

            return View(airlineService);
        }

        // GET: AirlineServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirlineServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineSeriveId,Name,Description,Avaialable")] AirlineService airlineService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airlineService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airlineService);
        }

        // GET: AirlineServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AirlineService == null)
            {
                return NotFound();
            }

            var airlineService = await _context.AirlineService.FindAsync(id);
            if (airlineService == null)
            {
                return NotFound();
            }
            return View(airlineService);
        }

        // POST: AirlineServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirlineSeriveId,Name,Description,Avaialable")] AirlineService airlineService)
        {
            if (id != airlineService.AirlineSeriveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airlineService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineServiceExists(airlineService.AirlineSeriveId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(airlineService);
        }

        // GET: AirlineServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AirlineService == null)
            {
                return NotFound();
            }

            var airlineService = await _context.AirlineService
                .FirstOrDefaultAsync(m => m.AirlineSeriveId == id);
            if (airlineService == null)
            {
                return NotFound();
            }

            return View(airlineService);
        }

        // POST: AirlineServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AirlineService == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AirlineService'  is null.");
            }
            var airlineService = await _context.AirlineService.FindAsync(id);
            if (airlineService != null)
            {
                _context.AirlineService.Remove(airlineService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineServiceExists(int id)
        {
          return (_context.AirlineService?.Any(e => e.AirlineSeriveId == id)).GetValueOrDefault();
        }
    }
}
