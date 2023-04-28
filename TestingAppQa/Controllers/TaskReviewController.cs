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
    public class TaskReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public TaskReviewController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TaskReviews
        public async Task<IActionResult> Index()
        {
            List<TaskReview> datos = new List<TaskReview>();
            var useractive = await _userManager.GetUserAsync(User);

            List<TaskReview> data = await (from t in _context.TaskReview
                        join u in _context.UserHistory on t.History.IdUserHistory equals u.IdUserHistory
                        join s in _context.sprint on u.SprintHistoryUser.IdSprint equals s.IdSprint
                        where s.IdSprint == useractive.IdSprintActive && u.IsDeleted == false
                                           select t).ToListAsync();

            foreach (var item in data)
            {
                UserHistory hu = await (from u in _context.UserHistory
                                        join t in _context.TaskReview
                                        on u.IdUserHistory equals t.History.IdUserHistory
                                        where t.IdTask == item.IdTask
                                        && u.IsDeleted == false
                                        select u).SingleAsync();
                string email = await (from t in _context.TaskReview
                                      join u in _context.user
                                        on t.ReponsabilityUser.Id equals u.Id
                                        where t.IdTask == item.IdTask
                                        select u.Email).SingleAsync();
                item.History = hu;
                var user = await _userManager.FindByEmailAsync(email);
                item.ReponsabilityUser = user;
                datos.Add(item);
            }
            //var user = await _userManager.FindByEmailAsync(taskReview.ReponsabilityUser);
            return View(datos);
        }

        // GET: TaskReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskReview = await _context.TaskReview
                .FirstOrDefaultAsync(m => m.IdTask == id);
            if (taskReview == null)
            {
                return NotFound();
            }

            return View(taskReview);
        }

        // GET: TaskReviews/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            List<UserHistory> userHistories = await(from s in _context.UserHistory
                                                        where s.SprintHistoryUser.IdSprint == user.IdSprintActive && s.IsDeleted == false
                                                        select s).ToListAsync();
            var taks = new TaskReviewVm();
            taks.History = new List<SelectListItem>();
            foreach (var item in userHistories)
            {
                taks.History.Add(new SelectListItem() { Value = item.IdUserHistory.ToString(), Text = item.Title });
            }
            return View(taks);
        }
        // POST: TaskReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, idhu, ReponsabilityUser, Description")] TaskReviewVm taskReview)
        {
            UserHistory userHistories = await (from s in _context.UserHistory
                                               where s.IdUserHistory == taskReview.idhu && s.IsDeleted == false
                                               select s).SingleOrDefaultAsync();

            Sprint sprint = await (from u in _context.UserHistory
                                            join s in _context.sprint
                                            on u.SprintHistoryUser.IdSprint equals s.IdSprint
                                            where u.IdUserHistory == taskReview.idhu && u.IsDeleted == false
                                            select s).SingleAsync();

            Project project = await (from p in _context.Project
                                   join s in _context.sprint
                                   on p.IdProject equals s.Project.IdProject
                                   where s.IdSprint == sprint.IdSprint
                                     select p).SingleAsync();

            var user = await _userManager.FindByEmailAsync(taskReview.ReponsabilityUser);
            if (user == null)
            {
                return View("UsuarioExistentes");
            }
            TaskReview taskReview1 = new TaskReview() { Title = taskReview.Title , Description= taskReview.Description, History = userHistories, ReponsabilityUser = user, Project = project , State = "PENDIENTE" , TaskState = "PENDIENTE" , Date = System.DateTime.Now };
            if (ModelState.IsValid)
            {
                _context.Add(taskReview1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskReview);
        }

        // GET: TaskReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taskReview = await _context.TaskReview.FindAsync(id);

            User usuario = await (from t in _context.TaskReview
                                     join u in _context.user
                                     on t.ReponsabilityUser.Id equals u.Id
                                     where t.IdTask == id
                                     select u).SingleAsync();

            var user = await _userManager.GetUserAsync(User);


            List<UserHistory> userHistories = await (from s in _context.UserHistory
                                                     where s.SprintHistoryUser.IdSprint == user.IdSprintActive && s.IsDeleted == false
                                                     select s).ToListAsync();

            UserHistory hu = await (from u in _context.UserHistory
                                    join t in _context.TaskReview
                                    on u.IdUserHistory equals t.History.IdUserHistory 
                                    where t.IdTask == id && u.IsDeleted == false
                                    select u).SingleAsync();

            var taks = new TaskReviewVm();
            taks.Historyselect = hu;
            taks.idhu = hu.IdUserHistory;
            taks.History = new List<SelectListItem>();
            
            foreach (var item in userHistories)
            {
                if (item.IdUserHistory != taks.idhu)
                {
                    taks.History.Add(new SelectListItem() { Value = item.IdUserHistory.ToString(), Text = item.Title });
                }
                
            }
            taks.Title = taskReview.Title;
            taks.ReponsabilityUser = usuario.Email;
            taks.State = taskReview.State;
            taks.TaskState = taskReview.TaskState;




            if (taskReview == null)
            {
                return NotFound();
            }
            return View(taks);
        }

        // POST: TaskReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title, idhu, ReponsabilityUser,State")] TaskReviewVm taskRevie)
        {
            var taskReview = await _context.TaskReview.FindAsync(id);

            UserHistory userHistories = await (from s in _context.UserHistory
                                               where s.IdUserHistory == taskRevie.idhu && s.IsDeleted == false
                                               select s).SingleOrDefaultAsync();

            Sprint sprint = await (from u in _context.UserHistory
                                   join s in _context.sprint
                                   on u.SprintHistoryUser.IdSprint equals s.IdSprint
                                   where u.IdUserHistory == taskRevie.idhu && u.IsDeleted == false
                                   select s).SingleAsync();

            Project project = await (from p in _context.Project
                                     join s in _context.sprint
                                     on p.IdProject equals s.Project.IdProject
                                     where s.IdSprint == sprint.IdSprint
                                     select p).SingleAsync();

            var user = await _userManager.FindByEmailAsync(taskRevie.ReponsabilityUser);

            taskReview.History = userHistories;
            taskReview.ReponsabilityUser = user;
            taskReview.Title = taskRevie.Title;
            taskReview.State = taskRevie.State;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskReviewExists(taskReview.IdTask))
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
            return View(taskReview);
        }

        // GET: TaskReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskReview = await _context.TaskReview
                .FirstOrDefaultAsync(m => m.IdTask == id);
            if (taskReview == null)
            {
                return NotFound();
            }

            return View(taskReview);
        }

        // POST: TaskReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskReview = await _context.TaskReview.FindAsync(id);
            _context.TaskReview.Remove(taskReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskReviewExists(int id)
        {
            return _context.TaskReview.Any(e => e.IdTask == id);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeConfirm(int? id)
        {
            var taskReview = await _context.TaskReview.FindAsync(id);
            switch (taskReview.TaskState)
            {
                case "PENDIENTE":
                    taskReview.TaskState = "PROCESO";
                    break;
                case "PROCESO":
                    taskReview.TaskState = "COMPLETADO";
                    taskReview.DateComplete = System.DateTime.Now;
                    break;
                default:
                    break;
            }
            _context.Update(taskReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 

        }
        [HttpGet]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskReview = await _context.TaskReview
                .FirstOrDefaultAsync(m => m.IdTask == id);
            if (taskReview == null)
            {
                return NotFound();
            }

            return View(taskReview);
        }
    }
}
