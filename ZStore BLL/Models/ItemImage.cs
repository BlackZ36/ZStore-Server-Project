using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class ItemImage
    {
        public int ImageId { get; set; }
        public int ItemId { get; set; }
        public string ImgUrl { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Item Item { get; set; } = null!;
    }
}
