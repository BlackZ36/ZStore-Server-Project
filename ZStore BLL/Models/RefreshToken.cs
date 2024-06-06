using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public int? AccountId { get; set; }
        public Guid? Token { get; set; }
        public int? TypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int? Status { get; set; }

        public virtual Account? Account { get; set; }
        public virtual TokenType? Type { get; set; }
    }
}
