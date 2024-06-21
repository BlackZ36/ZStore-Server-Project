namespace ZStore_BLL.Models
{
    public partial class Voucher
    {
        public int VoucherId { get; set; }
        public string? Code { get; set; }
        public int? Discount { get; set; }
        public string? Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int? Status { get; set; }
        public int? UsageLimit { get; set; }
        public int? UsedCount { get; set; }
    }
}
