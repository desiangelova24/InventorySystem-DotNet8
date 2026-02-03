using Microsoft.AspNetCore.Mvc;
using ScalableInventory.Services.Catalog;
using ScalableInventory.Services.Inventory;

namespace ScalableInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("total-value")]
        public async Task<IActionResult> GetTotalValue()
        {
            var totalValue = await _inventoryService.GetTotalStockValueAsync();
            return Ok(new { TotalValueEUR = totalValue, Currency = "EUR" });
        }
    }
}
