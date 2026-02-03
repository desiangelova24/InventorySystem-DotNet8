using ScalableInventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Core.Interfaces
{
    public interface ICatalogRepository
    {
        IQueryable<Product> GetQueryable();

        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task SaveChangesAsync();
        Task DeleteAsync(int id);
    }
}
