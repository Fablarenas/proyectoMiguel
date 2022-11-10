using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAppQa.Models;

namespace TestingAppQa.Models
{
    public class ConsolidationReportVm
    {
        public int IdTimeOut { get; set; }
        public User Analista { get; set; }
        public UserHistory HU { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public DateTime FechaSolucion { get; set; }
        public User Desarrollador { get; set; }
        public string EstadoTarea { get; set; }
        public string EstadoReporte { get; set; }
        public List<SelectListItem> Desarrolladores { get; set; }

        public int IdDesarrollador { get; set; }

    }
}
