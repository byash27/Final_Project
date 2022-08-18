using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalP.Web.Data;
using FinalP.Web.Models;

namespace FinalP.Web.Areas.Users.Controllers
{
    [Area("Users")]
    public class StartupInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartupInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/StartupInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StartupInfos.Include(s => s.Customer).Include(s => s.SubCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Users/StartupInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupInfo = await _context.StartupInfos
                .Include(s => s.Customer)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.StartupId == id);
            if (startupInfo == null)
            {
                return NotFound();
            }

            return View(startupInfo);
        }

        // GET: Users/StartupInfoes/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["Id"] = new SelectList(_context.SubCategories, "Id", "SubCategories");
            return View();
        }

        // POST: Users/StartupInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartupId,CompanyName,CompanySales,Date,Id,CustomerId")] StartupInfo startupInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(startupInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", startupInfo.CustomerId);
            ViewData["Id"] = new SelectList(_context.SubCategories, "Id", "SubCategories", startupInfo.Id);
            return View(startupInfo);
        }

        // GET: Users/StartupInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupInfo = await _context.StartupInfos.FindAsync(id);
            if (startupInfo == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", startupInfo.CustomerId);
            ViewData["Id"] = new SelectList(_context.SubCategories, "Id", "SubCategories", startupInfo.Id);
            return View(startupInfo);
        }

        // POST: Users/StartupInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartupId,CompanyName,CompanySales,Date,Id,CustomerId")] StartupInfo startupInfo)
        {
            if (id != startupInfo.StartupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(startupInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartupInfoExists(startupInfo.StartupId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", startupInfo.CustomerId);
            ViewData["Id"] = new SelectList(_context.SubCategories, "Id", "SubCategories", startupInfo.Id);
            return View(startupInfo);
        }

        // GET: Users/StartupInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupInfo = await _context.StartupInfos
                .Include(s => s.Customer)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.StartupId == id);
            if (startupInfo == null)
            {
                return NotFound();
            }

            return View(startupInfo);
        }

        // POST: Users/StartupInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startupInfo = await _context.StartupInfos.FindAsync(id);
            _context.StartupInfos.Remove(startupInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartupInfoExists(int id)
        {
            return _context.StartupInfos.Any(e => e.StartupId == id);
        }
    }
}
