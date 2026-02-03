using ScalableInventory.Core.DTOs;
using ScalableInventory.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly ICatalogRepository _catalogRepo;

        public InventoryService(IInventoryRepository repository, ICatalogRepository catalogRepository)
        {
            _repository = repository;
            _catalogRepo = catalogRepository;
        }

        public async Task<bool> IsStockLowAsync(int productId)
        {
            const int minimumThreshold = 5;

            return await _repository.IsStockLowAsync(productId, minimumThreshold);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updates"></param>
        /// <returns></returns>
        public async Task UpdateBulkStockAsync(IEnumerable<InventoryUpdateDto> updates)
        {
            try
            {
                await _repository.UpdateBulkStockAsync(updates);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetTotalStockValueAsync()
        {
            var allStocks = await _repository.GetAllAsync();
            decimal totalValue = 0;

            foreach (var stock in allStocks)
            {
                var product = await _catalogRepo.GetByIdAsync(stock.ProductId);

                if (product != null)
                {
                    totalValue += stock.Quantity * product.Price;
                }
            }

            return totalValue;
        }
    }
}
