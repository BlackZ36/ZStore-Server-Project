using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class VariantValue
    {
        public int VariantValueId { get; set; }
        public int? VariantId { get; set; }
        public int? ItemId { get; set; }
        public string? Value { get; set; }
        public string? ImgUrl { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}
