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
        public DbSet<Publication> Publication { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Indexation> Indexations { get; set; }
        public DbSet<EducationalProgram> EducationalPrograms { get; set; }
        public DbSet<RegistrationCertificate> RegistrationCertificate { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Filename=Database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasOne(p => p.IntelliegentWork)
                .WithMany(b => b.Authors)
                .HasForeignKey(p => p.IntelliegentWorkId);
            modelBuilder.Entity<Indexation>()
                .HasOne(p => p.IntelliegentWork)
                .WithMany(b => b.Indexations)
                .HasForeignKey(p => p.IntelliegentWorkId);
            modelBuilder.Entity<KeyWord>()
                .HasOne(p => p.IntelliegentWork)
                .WithMany(b => b.KeyWords)
                .HasForeignKey(p => p.IntelliegentWorkId);
        }
    }
}
