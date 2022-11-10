using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("Metrics")]
    public class Metrics
    {
        [Key]
        public int Id { get; set; }
        public string Desarrollador { get; set; }
        public int CantidadTareasDesarrollador { get; set; }
    }
}
