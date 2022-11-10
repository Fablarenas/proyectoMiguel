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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<User> _userManager;
        public ProjectsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            List<Project> projects= await (from e in _context.Project
                          join p in _context.ProjectUser
                          on e.IdProject equals p.Project.IdProject
                          where p.User.Id == user.Id
                          where p.Project.Deleted == false
                          select e).ToListAsync();
            return View(projects);
        }
        public IActionResult Invite()
        {
            return View();
        }
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Project());
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProject,Name,description")] Project project)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                _context.Add(project);
                //var rol = await _context.rols.FirstOrDefaultAsync(m => m.Id == 4);
                var projectUser = new ProjectUser { IdRol = "4", Project = project, User = user };
                _context.Add(projectUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProject,Name,description")] Project project)
        {
            project.IdProject = id;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.IdProject))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            project.Deleted = true;
            _context.Project.Update(project);
            var user = await _userManager.GetUserAsync(User);

            user.IdProjectActive = 0;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.IdProject == id);
        }

        [HttpPost]

        public async Task<ActionResult> SelectProject(int idproyecto)
        {
            var user = await _userManager.GetUserAsync(User);

            Project proyectoselect = _context.Project.Find(idproyecto);

            user.IdProjectActive = proyectoselect.IdProject;
            user.IdSprintActive = 0;
            _context.user.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Sprints");
            //return View("../Sprints/Index", sprints);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invite([Bind("User,Rols,IdRol")] ProjectUser projectUser)
        {
            var user = await _userManager.GetUserAsync(User);
            var usuarioAdd = await _context.user.FirstOrDefaultAsync(x => x.Email == projectUser.User.Email);
            if (usuarioAdd == null)
            {
                return View("UsuarioExistentes");
            }
            var projectAdd = await _context.Project.FirstOrDefaultAsync(x => x.IdProject == user.IdProjectActive);

            if (projectAdd != null)
            {
                var projectUsers = await _context.ProjectUser.FirstOrDefaultAsync(x => x.Project.IdProject == user.IdProjectActive && x.User.Id == usuarioAdd.Id);
                if (projectUsers != null)
                {
                    return View("PermisosExistentes");
                }
                projectAdd.ProjectUsers = new List<ProjectUser>();
                var projectUsernew = new ProjectUser { Project = projectAdd, User = usuarioAdd , IdRol = projectUser.IdRol };
                _context.Add(projectUsernew);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Sprints");
            }
            else
            {
                return View("SeleccionarProyecto");
            }
        }
    }
}
