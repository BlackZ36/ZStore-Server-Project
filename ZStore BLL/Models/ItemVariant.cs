using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class ItemVariant
    {
        public int ItemVariantId { get; set; }
        public int? ItemId { get; set; }
        public int? VariantId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}
