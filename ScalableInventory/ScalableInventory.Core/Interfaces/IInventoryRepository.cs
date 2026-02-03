using ScalableInventory.Core.DTOs;
using ScalableInventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Core.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock?> GetByProductIdAsync(int productId);

        
        Task UpdateBulkStockAsync(IEnumerable<InventoryUpdateDto> stocks);


        Task AddAsync(Stock stock);

       
        Task<int> SaveChangesAsync();

     
        Task<int> GetCurrentQuantityAsync(int productId);
       
        Task<bool> IsStockLowAsync(int productId, int threshold);
    }
}
