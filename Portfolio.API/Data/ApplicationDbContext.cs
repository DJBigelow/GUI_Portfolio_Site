using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectFramework>().HasKey(pf => new { pf.ProjectID, pf.FrameworkID });
            modelBuilder.Entity<ProjectLanguage>().HasKey(pl => new { pl.ProjectID, pl.LanguageID });
            modelBuilder.Entity<ProjectPlatform>().HasKey(pp => new { pp.ProjectID, pp.PlatformID });
        }


        public DbSet<Project> Projects { get; set; }


        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<ProjectFramework> ProjectFrameworks { get; set; }


        public DbSet<Language> Languages { get; set; }
        public DbSet<ProjectLanguage> ProjectLanguages { get; set; }


        public DbSet<Platform> Platforms { get; set; }
        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

    }
}
