using Microsoft.AspNetCore.Mvc;
using ScalableInventory.Core.DTOs;
using ScalableInventory.Services;
using ScalableInventory.Services.Catalog;

namespace ScalableInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public ProductsController(ICatalogService catalogService)
        {
            _catalogService = catalogService; 
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? name, [FromQuery] string? description)
        {
            var results = await _catalogService.SearchProductsAsync(name, description);
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _catalogService.GetProductByIdAsync(id);
            if (product == null) return NotFound("Product not found.");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _catalogService.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _catalogService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
