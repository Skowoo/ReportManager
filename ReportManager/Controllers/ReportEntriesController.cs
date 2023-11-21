using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReportManager.Data;
using ReportManager.Models;

namespace ReportManager.Controllers
{
    public class ReportEntriesController : Controller
    {
        private readonly MainContext _context;

        public ReportEntriesController(MainContext context)
        {
            _context = context;

            if (!context.Database.CanConnect())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
                
        }

        // GET: ReportEntries
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Tickets.Include(r => r.Category).Include(r => r.Person).Include(r => r.Project);
            return View(await mainContext.ToListAsync());
        }

        // GET: ReportEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Tickets
                .Include(r => r.Category)
                .Include(r => r.Person)
                .Include(r => r.Project)
                .FirstOrDefaultAsync(m => m.ReportEntryId == id);
            if (reportEntry == null)
            {
                return NotFound();
            }

            return View(reportEntry);
        }

        // GET: ReportEntries/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId");
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: ReportEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportEntryId,TicketTitle,TicketDescription,CategoryId,ProjectId,PersonId")] ReportEntry reportEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // GET: ReportEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Tickets.FindAsync(id);
            if (reportEntry == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // POST: ReportEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportEntryId,TicketTitle,TicketDescription,CategoryId,ProjectId,PersonId")] ReportEntry reportEntry)
        {
            if (id != reportEntry.ReportEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportEntryExists(reportEntry.ReportEntryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // GET: ReportEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Tickets
                .Include(r => r.Category)
                .Include(r => r.Person)
                .Include(r => r.Project)
                .FirstOrDefaultAsync(m => m.ReportEntryId == id);
            if (reportEntry == null)
            {
                return NotFound();
            }

            return View(reportEntry);
        }

        // POST: ReportEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportEntry = await _context.Tickets.FindAsync(id);
            if (reportEntry != null)
            {
                _context.Tickets.Remove(reportEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportEntryExists(int id)
        {
            return _context.Tickets.Any(e => e.ReportEntryId == id);
        }
    }
}
