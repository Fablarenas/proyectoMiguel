using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class TaskReviewVm
    {
        public string Title { get; set; }
        public UserHistory Historyselect { get; set; }
        public int idhu { get; set; }
        public string Description { get; set; }

        public List<SelectListItem> History { get; set; }

        public string ReponsabilityUser { get; set; }
        public string State { get; set; }
        public string TaskState { get; set; }
    }
}
