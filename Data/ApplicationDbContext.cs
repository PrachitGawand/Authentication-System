using Microsoft.EntityFrameworkCore;
using TeamAuthMvc.Models;

namespace TeamAuthMvc.Data
{
    // DbContext = Bridge between C# classes (Entities) and SQL Server tables
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // This represents the Users table
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email should be unique (no duplicate registrations)
            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}