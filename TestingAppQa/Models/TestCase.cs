using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    [Table("TestCase")]
    public class TestCase
    {
        [Key]
        public int IdTestCase { get; set; }

        public UserHistory HistoryUser { get; set; }

        public string TestType { get; set; }
        public string Var { get; set; }
        public string StepStep { get; set; }
        public string Analyst { get; set; }
    }
}
