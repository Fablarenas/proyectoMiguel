using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingAppQa.Data;
using TestingAppQa.Emails;
using TestingAppQa.Models;

namespace TestingAppQa.Controllers
{
    public class ConsolidationReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public ConsolidationReportsController(ApplicationDbContext context, UserManager<User> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: ConsolidationReports
        public async Task<IActionResult> Index()
        {
            List<ConsolidationReportVm> datos = new List<ConsolidationReportVm>();
            var data = _context.TaskReview.ToListAsync().Result.Where(x => x.TaskState == "COMPLETADO");
            var user = await _userManager.GetUserAsync(User);

            List<User> users = await (from p in _context.ProjectUser
                                                    join u in _context.user
                                                    on p.User.Id equals u.Id
                                                    where p.Project.IdProject == user.IdProjectActive
                                                    where p.IdRol == "2"
                                                    select u).ToListAsync();

            var listDeveloperts = new List<SelectListItem>();
            foreach (var item in users)
            {
                listDeveloperts.Add(new SelectListItem() { Text = item.Name , Value= item.Id} );
            }
            foreach (var item in data)
            {

                ConsolidationReportVm report = new ConsolidationReportVm();

                User userss = await (from t in _context.TaskReview
                                               join u in _context.user
                                               on t.ReponsabilityUser.Id equals u.Id
                                               where t.IdTask == item.IdTask
                                               select u).SingleAsync();

                UserHistory userHistory = await (from t in _context.TaskReview
                                   join u in _context.UserHistory
                                   on t.History.IdUserHistory equals u.IdUserHistory
                                   where t.IdTask == item.IdTask
                                   select u).SingleAsync();
                report.Analista = userss;
                report.HU = userHistory;
                report.Descripcion = item.Description;
                report.FechaReporte = item.DateComplete;
                report.Desarrolladores = listDeveloperts;
                datos.Add(report);
            }
            return View(datos);
        }

        // GET: ConsolidationReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidationReport = await _context.ConsolidationReport
                .FirstOrDefaultAsync(m => m.IdTimeOut == id);
            if (consolidationReport == null)
            {
                return NotFound();
            }

            return View(consolidationReport);
        }

        // GET: ConsolidationReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsolidationReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTimeOut,Descripcion,FechaReporte,FechaSolucion,EstadoTarea,EstadoReporte")] ConsolidationReport consolidationReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consolidationReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consolidationReport);
        }

        // GET: ConsolidationReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidationReport = await _context.ConsolidationReport.FindAsync(id);
            if (consolidationReport == null)
            {
                return NotFound();
            }
            return View(consolidationReport);
        }

        // POST: ConsolidationReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTimeOut,Descripcion,FechaReporte,FechaSolucion,EstadoTarea,EstadoReporte")] ConsolidationReport consolidationReport)
        {
            if (id != consolidationReport.IdTimeOut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consolidationReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsolidationReportExists(consolidationReport.IdTimeOut))
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
            return View(consolidationReport);
        }

        // GET: ConsolidationReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidationReport = await _context.ConsolidationReport
                .FirstOrDefaultAsync(m => m.IdTimeOut == id);
            if (consolidationReport == null)
            {
                return NotFound();
            }

            return View(consolidationReport);
        }

        // POST: ConsolidationReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consolidationReport = await _context.ConsolidationReport.FindAsync(id);
            _context.ConsolidationReport.Remove(consolidationReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsolidationReportExists(int id)
        {
            return _context.ConsolidationReport.Any(e => e.IdTimeOut == id);
        }

        [HttpGet]
        public async Task<IActionResult> Email(string email,string hu)
        {
            if (hu == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.Email == email);
            EmailVm emailobj = new EmailVm();
            emailobj.Name = user.Name;
            emailobj.Hu = hu;
            emailobj.Email = email;
            if (user == null)
            {
                return NotFound();
            }

            return View(emailobj);
        }
        
        [HttpPost]
        public async Task<IActionResult> SendEmail([Bind("Asunto,Cuerpo,Email,Hu,Name")] EmailVm? data)
        {
            var message = new Message(new string[] { data.Email }, data.Asunto, data.Cuerpo);
            _emailSender.SendEmail(message);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> AssignDeveloper([Bind("Asunto,Cuerpo,Email,Hu,Name")] EmailVm? data)
        {
            var message = new Message(new string[] { data.Email }, data.Asunto,data.Cuerpo);
            _emailSender.SendEmail(message);
            return RedirectToAction(nameof(Index));
        }
    }
}
