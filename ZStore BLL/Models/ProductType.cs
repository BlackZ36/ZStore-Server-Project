using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public string? Sku { get; set; }
        public int? Order { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
