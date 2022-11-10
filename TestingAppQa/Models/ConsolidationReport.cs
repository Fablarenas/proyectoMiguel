using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class ConsolidationReport
    {
        [Key]
        public int IdTimeOut { get; set; }
        public User Analista { get; set; }
        public UserHistory HU { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public DateTime FechaSolucion { get; set; }
        public User Desarrollador { get; set; }
        public string EstadoTarea { get; set; }
        public string EstadoReporte { get; set; }
    }
}
