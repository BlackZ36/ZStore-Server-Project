using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class ProductVariant
    {
        public int ProductVariantId { get; set; }
        public int? ProductId { get; set; }
        public int? VariantId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}
