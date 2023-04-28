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
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public ToolsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Tools
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IdProjectActive != 0)
            {
            List<Tools> tools = await (from s in _context.Tools
                                           where s.UserHistory.IdUserHistory == user.IdHUActive
                                           select s).ToListAsync();
            return View(tools);
            }
            else
            {
                return View("SeleccionarProyecto");
            }
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools
                .FirstOrDefaultAsync(m => m.IdTool == id);
            if (tools == null)
            {
                return NotFound();
            }

            return View(tools);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTool,Name,Version,Specification")] Tools tools)
        {
            var user = await _userManager.GetUserAsync(User);
            var proyecto = _context.UserHistory.Find(user.IdHUActive);
            tools.UserHistory = proyecto;
            if (ModelState.IsValid)
            {
                _context.Add(tools);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tools);
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools.FindAsync(id);
            UserHistory project = await (from p in _context.UserHistory
                                            join t in _context.Tools
                                            on p.IdUserHistory equals t.UserHistory.IdUserHistory
                                            where t.IdTool == id && p.IsDeleted == false
                                         select p).FirstOrDefaultAsync();
            tools.UserHistory = project;
            if (tools == null)
            {
                return NotFound();
            }
            return View(tools);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTool,Name,Version,Specification,Project")] Tools tools)
        {

            UserHistory project = await (from p in _context.UserHistory
                                     join t in _context.Tools
                                     on p.IdUserHistory equals t.UserHistory.IdUserHistory
                                     where t.IdTool == id && p.IsDeleted == false
                                         select p).FirstOrDefaultAsync();

            tools.UserHistory = project;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tools);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolsExists(tools.IdTool))
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
            return View(tools);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tools = await _context.Tools
                .FirstOrDefaultAsync(m => m.IdTool == id);
            if (tools == null)
            {
                return NotFound();
            }

            return View(tools);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tools = await _context.Tools.FindAsync(id);
            _context.Tools.Remove(tools);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolsExists(int id)
        {
            return _context.Tools.Any(e => e.IdTool == id);
        }
    }
}
