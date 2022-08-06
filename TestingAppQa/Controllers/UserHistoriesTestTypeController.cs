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
    public class UserHistoriesTestTypeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UserHistoriesTestTypeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserHistoriesTestType
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IdSprintActive != 0)
            {
                List<UserHistory> userHistories = await (from s in _context.UserHistory
                                                         where s.SprintHistoryUser.IdSprint == user.IdSprintActive
                                                         select s).ToListAsync();
                return View(userHistories);
            }
            else
            {
                return View("SeleccionarProyecto");
            }
        }

        // GET: UserHistoriesTestType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHistory = await _context.UserHistory
                .FirstOrDefaultAsync(m => m.IdUserHistory == id);
            if (userHistory == null)
            {
                return NotFound();
            }

            return View(userHistory);
        }

        // GET: UserHistoriesTestType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserHistoriesTestType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUserHistory,Title,IWant,Where,Then,TestType,DescriptionTestType")] UserHistory userHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userHistory);
        }

        // GET: UserHistoriesTestType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHistory = await _context.UserHistory.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }
            return View(userHistory);
        }

        // POST: UserHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestType,DescriptionTestType")] UserHistory userHistory)
        {
            var userHistoryori = await _context.UserHistory.FirstOrDefaultAsync(m => m.IdUserHistory == id);
            userHistoryori.TestType = userHistory.TestType;
            userHistoryori.DescriptionTestType = userHistory.DescriptionTestType;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHistoryori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHistoryExists(userHistoryori.IdUserHistory))
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
            return View(userHistoryori);
        }

        // GET: UserHistoriesTestType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHistory = await _context.UserHistory
                .FirstOrDefaultAsync(m => m.IdUserHistory == id);
            if (userHistory == null)
            {
                return NotFound();
            }

            return View(userHistory);
        }

        // POST: UserHistoriesTestType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userHistory = await _context.UserHistory.FindAsync(id);
            _context.UserHistory.Remove(userHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserHistoryExists(int id)
        {
            return _context.UserHistory.Any(e => e.IdUserHistory == id);
        }
    }
}
