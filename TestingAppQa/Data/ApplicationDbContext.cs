using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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

            builder.Entity<UserHistory>()
            .HasMany(uh => uh.TestCases)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserHistory>()
            .HasMany(uh => uh.TimeOuts)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserHistory>()
            .HasMany(uh => uh.ReviewTask)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserHistory>()
            .HasMany(uh => uh.Report)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserHistory>()
            .HasMany(uh => uh.Tools)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserHistory>()
            .HasMany(uh => uh.Risks)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserHistory>()
            .HasMany(uh => uh.Scopes)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        }
            public DbSet<Project> Project { get; set; }
            public DbSet<Rols> rols { get; set; }
            public DbSet<Sprint> sprint { get; set; }
            public DbSet<User> user { get; set; }

        public DbSet<ProjectUser> ProjectUser { get; set; }

        public DbSet<TestingAppQa.Models.Tools> Tools { get; set; }

        public DbSet<TestingAppQa.Models.Risk> Risk { get; set; }
        public DbSet<TestingAppQa.Models.Scope> Scope { get; set; }
        public DbSet<TestingAppQa.Models.UserHistory> UserHistory { get; set; }
        public DbSet<TestingAppQa.Models.TestCase> TestCase { get; set; }
        public DbSet<TestingAppQa.Models.TimeOut> TimeOut { get; set; }
        public DbSet<TestingAppQa.Models.TaskReview> TaskReview { get; set; }
        public DbSet<TestingAppQa.Models.Metrics> Metrics { get; set; }
        public DbSet<TestingAppQa.Models.ConsolidationReport> ConsolidationReport { get; set; }

    }
}
