using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternsMS.Data;
using InternsMS.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace InternsMS.Controllers
{

    public class EvaluationSheetsController : Controller
    {
        private readonly InternshipDbContext _context;

        public EvaluationSheetsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: EvaluationSheets
        public async Task<IActionResult> Index()
        {
            var internshipDbContext = _context.EvaluationSheets.Include(e => e.Assignment).Include(e => e.Intern).Include(e => e.Supervisor);
            return View(await internshipDbContext.ToListAsync());
        }

        // GET: EvaluationSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EvaluationSheets == null)
            {
                return NotFound();
            }

            var evaluationSheet = await _context.EvaluationSheets
                .Include(e => e.Assignment)
                .Include(e => e.Intern)
                .Include(e => e.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationSheet == null)
            {
                return NotFound();
            }

            return View(evaluationSheet);
        }

        // GET: EvaluationSheets/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title");
            ViewData["InternId"] = new SelectList(_context.Interns, "Id", "Name");
            ViewData["SupervisorId"] = new SelectList(_context.Supervisors, "Id", "Name");
            return View();
        }

        // POST: EvaluationSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InternId,AssignmentId,SupervisorId,Score,Comments")] EvaluationSheet evaluationSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title", evaluationSheet.AssignmentId);
            ViewData["InternId"] = new SelectList(_context.Interns, "Id", "Name", evaluationSheet.InternId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisors, "Id", "Name", evaluationSheet.SupervisorId);
            return View(evaluationSheet);
        }

        // GET: EvaluationSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EvaluationSheets == null)
            {
                return NotFound();
            }

            var evaluationSheet = await _context.EvaluationSheets.FindAsync(id);
            if (evaluationSheet == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title", evaluationSheet.AssignmentId);
            ViewData["InternId"] = new SelectList(_context.Interns, "Id", "Name", evaluationSheet.InternId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisors, "Id", "Name", evaluationSheet.SupervisorId);
            return View(evaluationSheet);
        }

        // POST: EvaluationSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InternId,AssignmentId,SupervisorId,Score,Comments")] EvaluationSheet evaluationSheet)
        {
            if (id != evaluationSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationSheetExists(evaluationSheet.Id))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title", evaluationSheet.AssignmentId);
            ViewData["InternId"] = new SelectList(_context.Interns, "Id", "Name", evaluationSheet.InternId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisors, "Id", "Name", evaluationSheet.SupervisorId);
            return View(evaluationSheet);
        }

        // GET: EvaluationSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EvaluationSheets == null)
            {
                return NotFound();
            }

            var evaluationSheet = await _context.EvaluationSheets
                .Include(e => e.Assignment)
                .Include(e => e.Intern)
                .Include(e => e.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationSheet == null)
            {
                return NotFound();
            }

            return View(evaluationSheet);
        }

        // POST: EvaluationSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EvaluationSheets == null)
            {
                return Problem("Entity set 'InternshipDbContext.EvaluationSheets'  is null.");
            }
            var evaluationSheet = await _context.EvaluationSheets.FindAsync(id);
            if (evaluationSheet != null)
            {
                _context.EvaluationSheets.Remove(evaluationSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationSheetExists(int id)
        {
          return (_context.EvaluationSheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
