namespace ZStore_BLL.Models
{
    public partial class AccountRole
    {
        public int AccountRoleId { get; set; }
        public int? AccountId { get; set; }
        public int? RoleId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Role? Role { get; set; }
    }
}
