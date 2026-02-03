using Microsoft.EntityFrameworkCore;
using ScalableInventory.Core.Entities;
using ScalableInventory.Core.Interfaces;
using ScalableInventory.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext _context;

        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetQueryable()
        {
            return _context.Products.AsQueryable();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
