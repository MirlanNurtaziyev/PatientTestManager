using Microsoft.EntityFrameworkCore;
using PatientTestManager.Domain.Entities;

namespace PatientTestManager.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Test> Tests => Set<Test>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Gender).IsRequired().HasMaxLength(50);
                entity.Property(p => p.DateOfBirth)
                      .HasColumnType("date");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Tests");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.TestName).IsRequired().HasMaxLength(200);
                entity.Property(t => t.TestDate).HasColumnType("date");
                entity.Property(t => t.Result).HasColumnType("decimal(18,2)");
                entity.HasIndex(t => new { t.PatientId, t.TestDate });
                entity.HasOne(t => t.Patient)
                      .WithMany(p => p.Tests)
                      .HasForeignKey(t => t.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}