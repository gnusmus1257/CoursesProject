using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using coursesProject.Models;

namespace coursesProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<coursesProject.Models.User> User { get; set; }
        public DbSet<coursesProject.Models.Rating> Rating { get; set; }
        public DbSet<coursesProject.Models.Project> Project { get; set; }
        public DbSet<coursesProject.Models.Category> Category { get; set; }
        public DbSet<coursesProject.Models.Subscriber> Subscriber { get; set; }
        public DbSet<coursesProject.Models.Goal> Goal { get; set; }
        public DbSet<coursesProject.Models.Comment> Comment { get; set; }
        public DbSet<coursesProject.Models.Statistic> Statistic { get; set; }
        public DbSet<coursesProject.Models.Tag> Tag { get; set; }
        public DbSet<coursesProject.Models.TagsRelation> TagRelation { get; set; }
        public DbSet<coursesProject.Models.Medal> Medal { get; set; }
        public DbSet<coursesProject.Models.MedalRelation> MedalRelation { get; set; }
    }
}
