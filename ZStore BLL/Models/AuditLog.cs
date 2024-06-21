namespace ZStore_BLL.Models
{
    public partial class AuditLog
    {
        public int LogId { get; set; }
        public int? AccountId { get; set; }
        public string? Action { get; set; }
        public string? Entity { get; set; }
        public int? EntityId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        public virtual Account? Account { get; set; }
    }
}
