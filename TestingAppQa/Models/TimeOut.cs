using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class TimeOut
    {
        [Key]
        public int IdTimeOut { get; set; }

        public string Name { get; set; }

        public UserHistory Hu { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
