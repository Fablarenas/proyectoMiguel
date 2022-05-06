using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("Rols")]
    public class Rols
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectUser> ProjectUsers { get; set; }
    }
}
