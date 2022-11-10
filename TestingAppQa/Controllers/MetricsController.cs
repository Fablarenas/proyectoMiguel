using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingAppQa.Data;
using TestingAppQa.Models;

namespace TestingAppQa.Controllers
{
    public class MetricsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public MetricsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Metrics
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            UserHistory userHistories = await (from s in _context.UserHistory
                                                     where s.IdUserHistory == user.IdHUActive
                                                     select s).FirstOrDefaultAsync();

            List<TaskReview> tasks = await (from s in _context.TaskReview
                                               where s.History.IdUserHistory == userHistories.IdUserHistory
                                                where   s.TaskState == "COMPLETADO"
                                              select s).ToListAsync();

            foreach (var item in tasks)
            {

            }
            return View(await _context.Metrics.SingleOrDefaultAsync());
        }

        // GET: Metrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrics = await _context.Metrics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrics == null)
            {
                return NotFound();
            }

            return View(metrics);
        }

        // GET: Metrics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metrics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Metrics metrics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metrics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metrics);
        }

        // GET: Metrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrics = await _context.Metrics.FindAsync(id);
            if (metrics == null)
            {
                return NotFound();
            }
            return View(metrics);
        }

        // POST: Metrics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Metrics metrics)
        {
            if (id != metrics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metrics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricsExists(metrics.Id))
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
            return View(metrics);
        }

        // GET: Metrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrics = await _context.Metrics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrics == null)
            {
                return NotFound();
            }

            return View(metrics);
        }

        // POST: Metrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metrics = await _context.Metrics.FindAsync(id);
            _context.Metrics.Remove(metrics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricsExists(int id)
        {
            return _context.Metrics.Any(e => e.Id == id);
        }
    }
}
