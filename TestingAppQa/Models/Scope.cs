using System.ComponentModel.DataAnnotations;

namespace TestingAppQa.Models
{
    public class Scope
    {
        [Key]
        public int IdScope { get; set; }

        public string NameModule { get; set; }

        public string TestGoal { get; set; }
        public string Considerations { get; set; }

        public UserHistory UserHistory { get; set; }
    }
}
