using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemImages = new HashSet<ItemImage>();
            ItemInventories = new HashSet<ItemInventory>();
            ItemVariants = new HashSet<ItemVariant>();
            VariantValues = new HashSet<VariantValue>();
        }

        public int ItemId { get; set; }
        public int? ProductId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public string? Sku { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ICollection<ItemInventory> ItemInventories { get; set; }
        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
        public virtual ICollection<VariantValue> VariantValues { get; set; }
    }
}
