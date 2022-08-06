using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class Scope
    {
        [Key]
        public int IdTool { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }
        public string Specification { get; set; }

        public Project Project { get; set; }
    }
}
