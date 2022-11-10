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
        public Project()
        {
            Deleted = false;
        }
        [Key]
        public int IdProject { get; set; }

        public string Name { get; set; }

        public string description { get; set; }

        public virtual List<Sprint> Sprints { get; set; }

        public  List<ProjectUser> ProjectUsers { get; set; }

        public  List<Tools> Tools{ get; set; }
        public  List<Risk> Risks{ get; set; }
        public  List<Scope> Scopes{ get; set; }

        public List<TaskReview> TaskReviews { get; set; }
        public bool Deleted { get; set; }
    }
}
