using Microsoft.EntityFrameworkCore;
using ScalableInventory.Core.DTOs;
using ScalableInventory.Core.Entities;
using ScalableInventory.Core.Interfaces;
using ScalableInventory.Services.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepo;
        private readonly IInventoryRepository _inventoryRepo;

        public CatalogService(ICatalogRepository catalogRepo, IInventoryRepository inventoryRepo)
        {
            _catalogRepo = catalogRepo;
            _inventoryRepo = inventoryRepo;
        }

        public async Task<List<ProductResponseDto>> SearchProductsAsync(string? name, string? description)
        {
            var query = _catalogRepo.GetQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(p => p.Description.Contains(description));

            var products = await query.ToListAsync();

            var results = new List<ProductResponseDto>();

            foreach (var product in products)
            {
                var stock = await _inventoryRepo.GetByProductIdAsync(product.Id);

                results.Add(new ProductResponseDto
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Currency = "EUR",
                    StockStatus = GetStockStatusMessage(stock?.Quantity ?? 0),
                    Id = product.Id
                });
            }

            return results;
        }

        private string GetStockStatusMessage(int quantity)
        {
            if (quantity <= 0) return "Out of stock";
            if (quantity < 10) return "Low stock! Hurry up!";
            return "In stock";
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(int id)
        {
            var product = await _catalogRepo.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductResponseDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto)
        {
            var newProduct = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Category = dto.Category,
                CreatedAt = DateTime.UtcNow
            };

            var savedProduct = await _catalogRepo.AddAsync(newProduct);

            return new ProductResponseDto
            {
                Name = savedProduct.Name,
                Price = savedProduct.Price,
                Description = savedProduct.Description,
                Id = savedProduct.Id
            };
        }

        public async Task DeleteProductAsync(int id)
        {
            await _catalogRepo.DeleteAsync(id);
        }
    }
}
