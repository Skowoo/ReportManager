using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReportManager.Data;
using ReportManager.Models;

namespace ReportManager.Controllers
{
    [Authorize(Roles = DbInitializer.AdminRoleName + "," + DbInitializer.UserRoleName)]
    public class ReportEntriesController : Controller
    {
        private readonly MainContext _context;

        public ReportEntriesController(MainContext context)
        {
            _context = context;
        }

        // GET: ReportEntries
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Reports.Include(r => r.Category).Include(r => r.Person).Include(r => r.Project);
            return View(await mainContext.ToListAsync());
        }

        // GET: ReportEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Reports
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ReportEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportTitle,ReportDescription,CategoryId,ProjectId,PersonId")] ReportEntry reportEntry)
        {
            Console.WriteLine(reportEntry.ReportTitle);
            Console.WriteLine(reportEntry.ReportDescription);
            Console.WriteLine(reportEntry.CategoryId);
            Console.WriteLine(reportEntry.ProjectId);
            Console.WriteLine(reportEntry.PersonId);

            if (ModelState.IsValid)
            {
                _context.Add(reportEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonName", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // GET: ReportEntries/Edit/5
        [Authorize(Roles = DbInitializer.AdminRoleName)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Reports.FindAsync(id);
            if (reportEntry == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonName", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // POST: ReportEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = DbInitializer.AdminRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportEntryId,ReportTitle,ReportDescription,CategoryId,ProjectId,PersonId")] ReportEntry reportEntry)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", reportEntry.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonName", reportEntry.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", reportEntry.ProjectId);
            return View(reportEntry);
        }

        // GET: ReportEntries/Delete/5
        [Authorize(Roles = DbInitializer.AdminRoleName)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntry = await _context.Reports
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
        [Authorize(Roles = DbInitializer.AdminRoleName)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportEntry = await _context.Reports.FindAsync(id);
            if (reportEntry != null)
            {
                _context.Reports.Remove(reportEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportEntryExists(int id)
        {
            return _context.Reports.Any(e => e.ReportEntryId == id);
        }
    }
}
