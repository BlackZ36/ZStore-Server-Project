using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInventories = new HashSet<ProductInventory>();
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? TypeId { get; set; }
        public int? VendorId { get; set; }
        public int? CollectionId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public string? Images { get; set; }
        public string? Slug { get; set; }
        public string? Sku { get; set; }
        public int? ViewTime { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Collection? Collection { get; set; }
        public virtual Category? SubCategory { get; set; }
        public virtual Type? Type { get; set; }
        public virtual Vendor? Vendor { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
