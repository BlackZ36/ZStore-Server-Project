using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Variant
    {
        public Variant()
        {
            ItemVariants = new HashSet<ItemVariant>();
            VariantValues = new HashSet<VariantValue>();
        }

        public int VariantId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
        public virtual ICollection<VariantValue> VariantValues { get; set; }
    }
}
