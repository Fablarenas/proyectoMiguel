using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class Risk
    {
        [Key]
        public int IdRisk { get; set; }

        public string Name { get; set; }

        public string MitigationStrategy { get; set; }
        public string RiskDependency { get; set; }

        public Project Project { get; set; }
    }
}
