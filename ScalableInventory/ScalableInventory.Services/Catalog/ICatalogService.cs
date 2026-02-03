using ScalableInventory.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Services.Catalog
{
    public interface ICatalogService
    {
        Task<List<ProductResponseDto>> SearchProductsAsync(string? name, string? description);
        Task<ProductResponseDto> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto);
        Task DeleteProductAsync(int id);
    }
}
