using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class TokenType
    {
        public TokenType()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int TokenTypeId { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
