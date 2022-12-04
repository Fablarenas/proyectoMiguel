using System.ComponentModel.DataAnnotations;

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
