using System;
using System.Collections.Generic;

namespace ZStore_BLL.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public int PermissionId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
