namespace ScalableInventory.Core.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = "EUR";
        public string StockStatus { get; set; } = string.Empty;
        public bool IsPromotional { get; set; }
    }
}
