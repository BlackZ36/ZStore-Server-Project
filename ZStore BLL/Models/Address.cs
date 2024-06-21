namespace ZStore_BLL.Models
{
    public partial class Address
    {
        public Address()
        {
            Accounts = new HashSet<Account>();
        }

        public int AddressId { get; set; }
        public int? AccountId { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Zip { get; set; }
        public string? Detail { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
