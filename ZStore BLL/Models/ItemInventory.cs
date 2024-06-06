using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class ItemInventory
    {
        public int InventoryId { get; set; }
        public int? ItemId { get; set; }
        public string? VariantCombination { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Item? Item { get; set; }
    }
}
