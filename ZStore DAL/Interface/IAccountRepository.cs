using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;

namespace ZStore_DAL.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIDAsync(int ID);
        Task<bool> AddAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> deleteAccountAsync(int ID);
    }
}
