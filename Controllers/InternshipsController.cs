using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternsMS.Data;
using InternsMS.Models;

namespace InternsMS.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly InternshipDbContext _context;

        public InternshipsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: Internships
        public async Task<IActionResult> Index()
        {
              return _context.Internships != null ? 
                          View(await _context.Internships.ToListAsync()) :
                          Problem("Entity set 'InternshipDbContext.Internships'  is null.");
        }

        // GET: Internships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Internships == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // GET: Internships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartDate,EndDate,Location,Description")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(internship);
        }

        // GET: Internships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Internships == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships.FindAsync(id);
            if (internship == null)
            {
                return NotFound();
            }
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StartDate,EndDate,Location,Description")] Internship internship)
        {
            if (id != internship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternshipExists(internship.Id))
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
            return View(internship);
        }

        // GET: Internships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Internships == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Internships == null)
            {
                return Problem("Entity set 'InternshipDbContext.Internships'  is null.");
            }
            var internship = await _context.Internships.FindAsync(id);
            if (internship != null)
            {
                _context.Internships.Remove(internship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternshipExists(int id)
        {
          return (_context.Internships?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
