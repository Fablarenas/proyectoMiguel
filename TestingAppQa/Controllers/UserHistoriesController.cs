using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingAppQa.Data;
using TestingAppQa.Models;

namespace TestingAppQa.Controllers
{
    public class UserHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserHistoriesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserHistories
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

        // GET: UserHistories/Details/5
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

        // GET: UserHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUserHistory,Title,IWant,Where,Then")] UserHistory userHistory)
        {
            var user = await _userManager.GetUserAsync(User);
            var sprint = _context.sprint.Find(user.IdSprintActive);
            userHistory.SprintHistoryUser = sprint;
            if (ModelState.IsValid)
            {
                _context.Add(userHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userHistory);
        }

        // GET: UserHistories/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("IdUserHistory,Title,IWant,Where,Then")] UserHistory userHistory)
        {
            if (id != userHistory.IdUserHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHistoryExists(userHistory.IdUserHistory))
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
            return View(userHistory);
        }

        public async Task<IActionResult> EditTest(int? id)
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
        public async Task<IActionResult> EditTest(int id, [Bind("IdUserHistory,Title,IWant,Where,Then")] UserHistory userHistory)
        {
            if (id != userHistory.IdUserHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHistoryExists(userHistory.IdUserHistory))
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
            return View(userHistory);
        }

        // GET: UserHistories/Delete/5
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

        // POST: UserHistories/Delete/5
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

        [HttpPost]
        public async Task<ActionResult> SelectHU(int idhu)
        {
            var user = await _userManager.GetUserAsync(User);

            user.IdHUActive = idhu;
            //_context.user.Update(user);
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "TestCases");
        }
    }
}
