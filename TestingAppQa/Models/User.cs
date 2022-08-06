using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAppQa.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }

        public int IdProjectActive { get; set; }
        public int IdSprintActive { get; set; }

        public int IdHUActive { get; set; }

        public List<ProjectUser> ProjectUsers { get; set; }
    }
}
