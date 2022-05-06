using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("ProjectUser")]
    public class ProjectUser
    {
        [Key]
        public int IdRolUser { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public Rols Rols { get; set; }
    }
}
