namespace ZStore_BLL.Models
{
    public partial class Variant
    {
        public Variant()
        {
            ProductVariants = new HashSet<ProductVariant>();
            VariantValues = new HashSet<VariantValue>();
        }

        public int VariantId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<VariantValue> VariantValues { get; set; }
    }
}
