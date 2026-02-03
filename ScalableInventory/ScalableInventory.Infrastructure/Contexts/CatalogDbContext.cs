using Microsoft.EntityFrameworkCore;
using ScalableInventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Infrastructure.Contexts
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .HasDatabaseName("Index_ProductName");

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Description)
                .HasDatabaseName("Index_ProductDescription");

            modelBuilder.Entity<Product>()
                    .HasIndex(p => p.CreatedAt)
                    .HasDatabaseName("Index_CreatedAt");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.Description)
                      .IsRequired();

                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired()
                      .HasPrecision(18, 2);

                entity.Property(p => p.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
