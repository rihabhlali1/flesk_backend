using Microsoft.EntityFrameworkCore;
using FleskBtocBackend.Models;

namespace FleskBtocBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  // Correctly define Users as DbSet<User>
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.price)  // Ensure property names match exactly
                .HasColumnType("decimal(18,2)");

            // Configure relationships and other model configurations here
        }
    }
}
