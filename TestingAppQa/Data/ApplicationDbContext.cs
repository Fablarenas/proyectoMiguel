using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAppQa.Models;

namespace TestingAppQa.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Rols rol = new Rols { Id = 1, Name = "Desarrollador" };
        }
            public DbSet<Project> Project { get; set; }
            public DbSet<Rols> rols { get; set; }
            public DbSet<Sprint> sprint { get; set; }
            public DbSet<User> user { get; set; }

        public DbSet<ProjectUser> ProjectUser { get; set; }
    }
}
