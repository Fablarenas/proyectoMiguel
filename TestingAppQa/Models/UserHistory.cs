using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("UserHistory")]
    public class UserHistory
    {
        [Key]
        public int IdUserHistory { get; set; }

        public string Title { get; set; }

        public string IWant { get; set; }

        public string Where { get; set; }

        public string Then { get; set; }

        public string TestType { get; set; }

        public string DescriptionTestType { get; set; }

        public Sprint SprintHistoryUser { get; set; }

        public List<TestCase> TestCases { get; set; }
        public List<TimeOut> TimeOuts { get; set; }
        public List<TaskReview> ReviewTask { get; set; }
        public List<ConsolidationReport> Report { get; set; }
    }
}
