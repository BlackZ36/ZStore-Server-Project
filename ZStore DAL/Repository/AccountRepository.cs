using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;
using ZStore_DAL.Interface;

namespace ZStore_DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {


        //Basic Methods
        public async Task<IEnumerable<Account>> GetAccountsAsync() => await AccountDAO.Instance.GetAccountsAsync();
        public async Task<Account> GetAccountByIDAsync(int ID) => await AccountDAO.Instance.GetAccountByIDAsync(ID);
        public async Task<bool> AddAccountAsync(Account account) => await AccountDAO.Instance.AddAccountAsync(account);
        public async Task<bool> UpdateAccountAsync(Account account) => await AccountDAO.Instance.UpdateAccountAsync(account);
        public async Task<bool> deleteAccountAsync(int ID) => await AccountDAO.Instance.DeleteAccountAsync(ID);

        //Other Methods

    }
}
