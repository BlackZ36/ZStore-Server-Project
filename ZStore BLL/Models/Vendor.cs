namespace ZStore_BLL.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Products = new HashSet<Product>();
        }

        public int VendorId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Sku { get; set; }
        public int? Order { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
