using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class TaskReview
    {
        [Key]
        public int IdTask { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public UserHistory History { get; set; }

        public User ReponsabilityUser { get; set; }
        public string State { get; set; }
        public string TaskState { get; set; }
        public DateTime DateComplete { get; set; }
        public Project Project { get; set; }
        public string DeveloperId { get; set; }
        public string ReportState { get; set; }
    }
}
