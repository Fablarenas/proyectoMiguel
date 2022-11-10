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
    public class SprintsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public SprintsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Sprints
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IdProjectActive != 0)
            {
                List<Sprint> projects = await (from s in _context.sprint
                                               where s.Project.IdProject == user.IdProjectActive
                                               select s).ToListAsync();
                return View(projects);
            }
            else
            {
                return View("SeleccionarProyecto");
            }

        }

        // GET: Sprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.sprint
                .FirstOrDefaultAsync(m => m.IdSprint == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // GET: Sprints/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Invite()
        {
            return View();
        }
        // POST: Sprints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSprint,Name")] Sprint sprint)
        {
            var user = await _userManager.GetUserAsync(User);
            var proyecto = _context.Project.Find(user.IdProjectActive);
            sprint.Project = proyecto;
            if (ModelState.IsValid)
            {
                _context.sprint.Add(sprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprint);
        }

        // GET: Sprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.sprint.FindAsync(id);
            if (sprint == null)
            {
                return NotFound();
            }
            return View(sprint);
        }

        // POST: Sprints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSprint,Name")] Sprint sprint)
        {
            if (id != sprint.IdSprint)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprintExists(sprint.IdSprint))
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
            return View(sprint);
        }

        // GET: Sprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.sprint
                .FirstOrDefaultAsync(m => m.IdSprint == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // POST: Sprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprint = await _context.sprint.FindAsync(id);
            _context.sprint.Remove(sprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprintExists(int id)
        {
            return _context.sprint.Any(e => e.IdSprint == id);
        }


        [HttpPost]
        public async Task<ActionResult> SelectSprint(int idsprint)
        {
            var user = await _userManager.GetUserAsync(User);

            Sprint proyectoselect = _context.sprint.Find(idsprint);

            user.IdSprintActive = proyectoselect.IdSprint;
            _context.user.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Sprints");
        }
    }
}
