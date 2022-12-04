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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace TestingAppQa.Controllers
{
    public class MetricsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MetricsController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Metrics
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            UserHistory userHistories = await (from s in _context.UserHistory
                                                     where s.IdUserHistory == user.IdHUActive
                                                     select s).FirstOrDefaultAsync();

            List<Metrics> email = await (from t in _context.TaskReview
                               join us in _context.user
                                on t.DeveloperId equals us.Id
                               where t.History.IdUserHistory == user.IdHUActive
                               where t.ReportState == "SOLUCIONADO"
                               group t by t.DeveloperId into newgroup
                               select new Metrics { Desarrollador = newgroup.Key.ToString(), CantidadTareasDesarrollador = newgroup.Count() }).ToListAsync();


            return View(email);
        }

        public async Task<object> GetData()
        {
            var user = await _userManager.GetUserAsync(User);
            UserHistory userHistories = await (from s in _context.UserHistory
                                               where s.IdUserHistory == user.IdHUActive
                                               select s).FirstOrDefaultAsync();

            List<Metrics> email = await (from t in _context.TaskReview
                                         join us in _context.user
                                          on t.DeveloperId equals us.Id
                                         where t.History.IdUserHistory == user.IdHUActive
                                         where t.ReportState == "SOLUCIONADO"
                                         group t by t.DeveloperId into newgroup
                                         select new Metrics { Desarrollador = newgroup.Key.ToString(), CantidadTareasDesarrollador = newgroup.Count() }).ToListAsync();
            List<string> milistadesarrolladores = new List<string>();
            List<int> milistatareas = new List<int>();
            for (int i = 0; i < email.Count; i++)
            {
                var data = await _context.user.FirstOrDefaultAsync(x => x.Id.Equals(email[i].Desarrollador));
                milistadesarrolladores.Add(data.Name);
                milistatareas.Add(email[i].CantidadTareasDesarrollador);
            }


            List<Metrics> analistas = await (from t in _context.TaskReview
                                         join us in _context.user
                                          on t.ReponsabilityUser.Id equals us.Id
                                         where t.History.IdUserHistory == user.IdHUActive
                                         where t.State == "NOEXITOSO"
                                            group t by t.ReponsabilityUser.Id into newgroup
                                         select new Metrics { Analista = newgroup.Key.ToString(), CantidadReportadosAnalista = newgroup.Count() }).ToListAsync();



            List<string> milistaanalistas = new List<string>();
            List<int> milistareportados = new List<int>();
            for (int i = 0; i < analistas.Count; i++)
            {
                var data = await _context.user.FirstOrDefaultAsync(x => x.Id.Equals(analistas[i].Analista));
                milistaanalistas.Add(data.Name);
                milistareportados.Add(analistas[i].CantidadReportadosAnalista);
            }


            List<TaskReview> noexitosos = await (from t in _context.TaskReview
                                       where t.History.IdUserHistory == user.IdHUActive
                                       where t.State == "NOEXITOSO"
                                       select t).ToListAsync();

            List<TaskReview> exitosos = await (from t in _context.TaskReview
                                       where t.History.IdUserHistory == user.IdHUActive
                                       where t.State == "EXITOSO"
                                       select t).ToListAsync();
            decimal exitososdecimal = Decimal.Parse(exitosos.Count.ToString());
           decimal  noexitososdecimal = Decimal.Parse(noexitosos.Count.ToString());

            decimal total = exitososdecimal + noexitososdecimal;

            decimal totalnoexitosos = (noexitososdecimal / total) * 100;
            decimal totalexitosos = (exitososdecimal / total) * 100;

            List<TimeOut> userHistoriess = await (from s in _context.sprint
                                                  join u in _context.UserHistory
                                                  on s.IdSprint equals user.IdSprintActive
                                                  join t in _context.TimeOut
                                                  on u.IdUserHistory equals t.Hu.IdUserHistory
                                                  select t).ToListAsync();

            List<DateTime> listafechas = new List<DateTime>();
            int numdias = 0;
            foreach (var item in userHistoriess)
            {
                TimeSpan difFechas = item.EndDate - item.StartDate;
                numdias += difFechas.Days;
            }
            return new { labels = milistadesarrolladores , coun = milistatareas ,labelsanalista = milistaanalistas, counreport = milistareportados, exitosos =  totalexitosos , noexitosos = totalnoexitosos };
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

        static List<DateTime> SortAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }

        [HttpGet]

        public async Task<IActionResult> DescargarPDF(int idproyecto)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MyFiles", "TuArchivo.pdf");
            System.IO.FileStream fs = new FileStream(path, FileMode.Create);

            var user = await _userManager.GetUserAsync(User);

            List<UserHistory> userHistories = await (from s in _context.UserHistory
                                                     where s.SprintHistoryUser.IdSprint == user.IdSprintActive
                                                     select s).ToListAsync();

            List<TestCase> testCases = await (from e in _context.TestCase
                                              join p in _context.ProjectUser
                                              on e.IdTestCase equals p.User.IdHUActive
                                              where p.User.Id == user.Id
                                              select e).ToListAsync();

            var project = await _context.Project.FindAsync(user.IdProjectActive);

            var sprint = await _context.Project.FindAsync(user.IdSprintActive);


            Document document = new Document(PageSize.LETTER, -1, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.AddAuthor("Micke Blomquist");
            document.AddCreator("Sample application using iTextSharp");
            document.AddKeywords("PDF tutorial education");
            document.AddSubject("Document subject - Describing the steps creating a PDF document");
            document.AddTitle("The document title - PDF creation using iTextSharp");


            // Open the document to enable you to write to the document  
            document.Open();
            var pathImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MyFiles", "Logo.png");
            Image img3 = Image.GetInstance(pathImage);
            img3.SetAbsolutePosition(30, 680);
            img3.ScaleAbsoluteHeight(100);
            img3.ScaleAbsoluteWidth(100);
            document.Add(img3);

            //BigTitle
            Font FontBigTitle = FontFactory.GetFont("Calibri", 11, Font.BOLD);
            Paragraph BigTitle;
            BigTitle = new Paragraph("DOCUMENTO PLAN DE PRUEBAS", FontBigTitle);
            BigTitle.Alignment = Element.ALIGN_CENTER;
            BigTitle.SpacingAfter = 40;
            BigTitle.SpacingBefore = 40;
            document.Add(BigTitle);

            ////////////////////////////////////////Tabla cabecera///////////////////
            PdfPTable table = new PdfPTable(2);
            // Esta es la primera fila
            table.AddCell("Nombre Del Proyecto:" + project.Name);
            table.AddCell("Sprint:" + sprint.Name);

            // Segunda fila
            table.AddCell("Impreso por: " + user.Name + user.LastName);
            table.AddCell(DateTime.Now.ToString());
            table.SpacingBefore = 20;
            table.SpacingAfter = 20;
            // Agregamos la tabla al documento
            document.Add(table);

            //////////////////////////////////////FIN Tabla cabecera///////////////////

            //////////////////////////////////////TABLA CASOS DE PRUEBA////////////////
            PdfPTable tableHu = new PdfPTable(4);

            PdfPCell cellWithRowspanHU = new PdfPCell(new Phrase("HISTORIAS DE USUARIO Y CASOS DE PRUEBAS ASOCIADOS"));
            cellWithRowspanHU.Colspan = 4;

            tableHu.AddCell(cellWithRowspanHU);

            // Segunda fila
            foreach (var item in userHistories)
            {
                PdfPCell cellWithRowspanIdUser = new PdfPCell(new Phrase("ID HU:" + item.IdUserHistory));
                cellWithRowspanIdUser.Rowspan = testCases.Count;
                tableHu.AddCell(cellWithRowspanIdUser);

                PdfPCell cellWithRowspanNameUser = new PdfPCell(new Phrase("Nombre HU" + item.Title));
                cellWithRowspanNameUser.Rowspan = testCases.Count;
                tableHu.AddCell(cellWithRowspanNameUser);

                foreach (var test in testCases)
                {
                    if (test.HistoryUser.IdUserHistory == item.IdUserHistory)
                    {
                        tableHu.AddCell("ID Caso:" + test.IdTestCase);
                        tableHu.AddCell("DescripcionCaso" + test.Var);
                    }
                    else
                    {
                        tableHu.AddCell("");
                        tableHu.AddCell("");
                    }
                }
            }
            tableHu.SpacingBefore = 20;
            tableHu.SpacingAfter = 20;
            document.Add(tableHu);
            //////////////////////////////////////FIN TABLA CASOS DE PRUEBA////////////////
            List<Risk> risks = await (from r in _context.Risk
                                      where r.Project.IdProject == user.IdProjectActive
                                      select r).ToListAsync();

            PdfPTable tableRisk = new PdfPTable(3);
            var tablerisktittle = new Paragraph("RIESGOS", FontBigTitle);
            BigTitle.Alignment = Element.ALIGN_CENTER;
            PdfPCell cellWithRowspanRisk = new PdfPCell(tablerisktittle);

            cellWithRowspanRisk.Colspan = 3;

            tableRisk.AddCell(cellWithRowspanRisk);
            tableRisk.AddCell("Nombre Riesgo");
            tableRisk.AddCell("Estrategia de mitigacion");
            tableRisk.AddCell("Dependencia de Riesgo");
            foreach (var item in risks)
            {
                tableRisk.AddCell(item.Name);
                tableRisk.AddCell(item.MitigationStrategy);
                tableRisk.AddCell(item.RiskDependency);
            }

            document.Add(tableRisk);
            List<Scope> scopes = await(from r in _context.Scope
                                       where r.Project.IdProject == user.IdProjectActive
                                       select r).ToListAsync();

            PdfPTable tableScope = new PdfPTable(4);
            PdfPCell cellWithRowspantableScope = new PdfPCell(new Phrase("Alcances"));
            cellWithRowspantableScope.Colspan = 4;

            tableScope.AddCell(cellWithRowspantableScope);
            tableScope.AddCell("Nombre Modulo");
            tableScope.AddCell("Historia de usuario");
            tableScope.AddCell("Objetivo de la prueba");
            tableScope.AddCell("Consideraciones");
            foreach (var item in scopes)
            {
                tableScope.AddCell(item.Name);
                tableScope.AddCell(item.Name);
                tableScope.AddCell(item.Name);
                tableScope.AddCell(item.Name);
            }
            tableScope.SpacingBefore = 20;
            tableScope.SpacingAfter = 20;
            document.Add(tableScope);

            List<Tools> tools = await(from r in _context.Tools
                                      where r.Project.IdProject == user.IdProjectActive
                                      select r).ToListAsync();

            PdfPTable tableTools = new PdfPTable(3);
            PdfPCell cellWithRowspantools = new PdfPCell(new Phrase("Herramientas"));
            cellWithRowspantools.Colspan = 3;

            tableTools.AddCell(cellWithRowspantools);
            tableTools.AddCell("Nombre de la herramienta");
            tableTools.AddCell("Version");
            tableTools.AddCell("Especificion de uso");
            foreach (var item in tools)
            {
                tableTools.AddCell(item.Name);
                tableTools.AddCell(item.Version);
                tableTools.AddCell(item.Specification);
            }
            tableTools.SpacingBefore = 20;
            tableScope.SpacingAfter = 20;
            document.Add(tableTools);


            ///////////////////////////////TABLA DE TAREAS
            PdfPTable tabletask = new PdfPTable(3);

            PdfPCell cellWithRowspantask = new PdfPCell(new Phrase("Tipos de pruebas"));
            cellWithRowspantask.Colspan = 3;

            tabletask.AddCell(cellWithRowspantask);

            // Segunda fila
            foreach (var item in userHistories)
            {

                tabletask.AddCell(item.Title);
                tabletask.AddCell(item.TestType);
                tabletask.AddCell(item.DescriptionTestType);

            }
            tabletask.SpacingBefore = 20;
            tabletask.SpacingAfter = 20;
            document.Add(tabletask);

            ///////////////////////TABLA DE TAREAS
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            fs.Close();



            var memory = DownloadSinghFile("TuArchivo.pdf", "wwwroot\\MyFiles");
            return File(memory.ToArray(), "application/pdf", "TuArchivo.pdf");
        }

        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
                var memory = new MemoryStream();
                if (System.IO.File.Exists(path))
                {
                    var net = new System.Net.WebClient();
                    var data = net.DownloadData(path);
                    var content = new System.IO.MemoryStream(data);
                    memory = content;
                }
                memory.Position = 0;
                return memory;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async void generarpdf() {

        }
    }
}
