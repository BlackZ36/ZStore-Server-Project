using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;

namespace ZStore_DAL
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        //Method Below
        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            var accounts = new List<Account>();
            try
            {
                using var context = new ZStore_SampleContext();
                accounts = await context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return accounts;
        }

        public async Task<Account> GetAccountByIDAsync(int ID)
        {
            var account = new Account();
            try
            {
                using var context = new ZStore_SampleContext();
                account = await context.Accounts.FirstOrDefaultAsync(x => x.AccountId == ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return account;
        }

        public async Task<bool> AddAccountAsync(Account account)
        {
            try
            {
                if (account == null)
                {
                    throw new ArgumentNullException(nameof(account), "Account Object Cannot Be Null");
                }
                using var context = new ZStore_SampleContext();
                context.Accounts.Add(account);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occureed: {ex.Message}");
            }
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                context.Accounts.Update(account);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAccountAsync(int ID)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                Account account = await context.Accounts.FirstOrDefaultAsync(x => x.AccountId == ID);
                if (account == null)
                {
                    throw new ArgumentNullException(nameof(account), "Account Object Cannot Be Null");
                }
                context.Accounts.Remove(account);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

    }
}
