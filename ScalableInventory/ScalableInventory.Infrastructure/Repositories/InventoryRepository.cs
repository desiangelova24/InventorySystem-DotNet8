using Microsoft.EntityFrameworkCore;
using ScalableInventory.Core.DTOs;
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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IsStockLowAsync(int productId, int threshold)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == productId);

            if (stock == null) return true;

            return stock.Quantity < threshold;
        }

        public async Task<Stock?> GetByProductIdAsync(int productId)
        {
            return await _context.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == productId);
        }

        public async Task<int> GetCurrentQuantityAsync(int productId)
        {
            var stock = await GetByProductIdAsync(productId);
            return stock?.Quantity ?? 0;
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }

        public async Task UpdateBulkStockAsync(IEnumerable<InventoryUpdateDto> updates)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var update in updates)
                {
                    var stock = await _context.Stocks.FindAsync(update.ProductId);
                    if (stock != null)
                    {
                        stock.Quantity = update.NewQuantity;
                        stock.LastUpdated = DateTime.UtcNow;
                    }
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }
    }
}
