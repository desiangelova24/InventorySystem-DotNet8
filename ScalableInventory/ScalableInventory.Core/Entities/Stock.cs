using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableInventory.Core.Entities
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
       
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
