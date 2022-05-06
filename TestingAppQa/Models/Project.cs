using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int IdProject { get; set; }

        public string Name { get; set; }

        public string description { get; set; }

        public List<Sprint> Sprints { get; set; }

        public List<ProjectUser> ProjectUsers { get; set; }
    }
}
