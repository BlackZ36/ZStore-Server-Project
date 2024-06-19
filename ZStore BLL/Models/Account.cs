using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRoles = new HashSet<AccountRole>();
            Addresses = new HashSet<Address>();
            AuditLogs = new HashSet<AuditLog>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Mobile { get; set; }
        public int? Status { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public int? DefaultAddressId { get; set; }

        public virtual Address? DefaultAddress { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
