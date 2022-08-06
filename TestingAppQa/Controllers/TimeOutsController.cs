using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingAppQa.Data;
using TestingAppQa.Models;

namespace TestingAppQa.Controllers
{
    public class TimeOutsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public TimeOutsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TimeOuts
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IdSprintActive != 0)
            {
                List<TimeOut> userHistories = await (from s in _context.TimeOut
                                                         where s.Hu.IdUserHistory == user.IdHUActive
                                                         select s).ToListAsync();
                return View(userHistories);
            }
            else
            {
                return View("SeleccionarProyecto");
            }
        }

        public async Task<List<TimeOut>> getData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IdSprintActive != 0)
            {
                List<TimeOut> userHistories = await (from s in _context.TimeOut
                                                     where s.Hu.IdUserHistory == user.IdHUActive
                                                     select s).ToListAsync();
                return userHistories;
            }
            else
            {
                List<TimeOut> userHistoriesvacia = new List<TimeOut>();
                return userHistoriesvacia;
            }

        }

        // GET: TimeOuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOut = await _context.TimeOut
                .FirstOrDefaultAsync(m => m.IdTimeOut == id);
            if (timeOut == null)
            {
                return NotFound();
            }

            return View(timeOut);
        }

        // GET: TimeOuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(string Name, string StartDate ,string EndDate)
        {
            DateTime fechainicio = Convert.ToDateTime(StartDate + " 07:20:20");
            DateTime fechafinal = Convert.ToDateTime(EndDate + " 07:20:20");
            fechainicio =fechainicio.AddDays(1);
            fechafinal = fechafinal.AddDays(1);
            fechainicio.AddHours(2);
            fechafinal.AddHours(3);
            var user = await _userManager.GetUserAsync(User);
            var hu = _context.UserHistory.Find(user.IdHUActive);
            TimeOut timeOut = new TimeOut() { Name = Name , StartDate = fechainicio, EndDate = fechafinal, Hu = hu };
            _context.Add(timeOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TimeOuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOut = await _context.TimeOut.FindAsync(id);
            if (timeOut == null)
            {
                return NotFound();
            }
            return View(timeOut);
        }

        // POST: TimeOuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTimeOut,Name,StartDate,EndDate")] TimeOut timeOut)
        {
            if (id != timeOut.IdTimeOut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOutExists(timeOut.IdTimeOut))
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
            return View(timeOut);
        }

        // GET: TimeOuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOut = await _context.TimeOut
                .FirstOrDefaultAsync(m => m.IdTimeOut == id);
            if (timeOut == null)
            {
                return NotFound();
            }

            return View(timeOut);
        }

        // POST: TimeOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeOut = await _context.TimeOut.FindAsync(id);
            _context.TimeOut.Remove(timeOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeOutExists(int id)
        {
            return _context.TimeOut.Any(e => e.IdTimeOut == id);
        }
    }
}
