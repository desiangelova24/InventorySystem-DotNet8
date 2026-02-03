using Microsoft.EntityFrameworkCore;
using ScalableInventory.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Infrastructure.Contexts
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Stock>()
                .HasIndex(s => s.ProductId)
                .IsUnique()
                .HasDatabaseName("Index_Stock_ProductId");

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(s => s.ProductId)
                      .IsRequired();

                entity.Property(s => s.Quantity)
                      .IsRequired()
                      .HasDefaultValue(0);
            });
        }
    }
}
