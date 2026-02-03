using ScalableInventory.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Services.Inventory
{
    public interface IInventoryService
    {
        Task UpdateBulkStockAsync(IEnumerable<InventoryUpdateDto> updates);
        Task<decimal> GetTotalStockValueAsync();
    }
}
