namespace ZStore_BLL.Models
{
    public partial class Role
    {
        public Role()
        {
            AccountRoles = new HashSet<AccountRole>();
            RolePermissions = new HashSet<RolePermission>();
        }

        public int RoleId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
