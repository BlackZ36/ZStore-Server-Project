using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            ProductCategories = new HashSet<Product>();
            ProductSubCategories = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public string? Sku { get; set; }
        public int? Status { get; set; }
        public int? Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<Product> ProductCategories { get; set; }
        public virtual ICollection<Product> ProductSubCategories { get; set; }
    }
}
