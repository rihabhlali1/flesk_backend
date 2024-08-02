using Microsoft.EntityFrameworkCore;
using FleskBtocBackend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleskBtocBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            ConfigureProductEntity(modelBuilder.Entity<Product>());
        }

        private void ConfigureProductEntity(EntityTypeBuilder<Product> entity)
        {
            entity.Property(p => p.price)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.discount)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.freeShippingThreshold)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.newCustomerDiscount)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.newCustomerLimit)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.originalPrice)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.rating)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.shippingDiscount)
                .HasColumnType("decimal(18,2)");

            // Add any additional configuration here, e.g., relationships or indexes
        }
    }
}
