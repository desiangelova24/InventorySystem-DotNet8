using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Core.DTOs
{
    public class InventoryUpdateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(0, 10000, ErrorMessage = "Quantity cannot be negative.")]
        public int NewQuantity { get; set; }
    }
}
