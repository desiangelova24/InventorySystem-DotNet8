using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
