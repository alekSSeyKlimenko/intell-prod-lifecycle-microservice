using System;
using IntellProdLifeCycleMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace IntellProdLifeCycleMS.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public string DbPath { get; private set; }

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<IntelliegentWork> IntelliegentWorks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Indexation> Indexations { get; set; }
        public DbSet<EducationalProgram> EducationalPrograms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Database.db");
    }
}
