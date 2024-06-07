using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;

namespace ZStore_Console
{
    internal class TestDBContext
    {
        public static void Main(string[] args)
        {
            TestDatabaseConnection();
        }

        public static void TestDatabaseConnection()
        {
            try
            {
                using (var context = new ZStore_SampleContext())
                {
                    List<Account> accounts = new List<Account>();
                    accounts = context.Accounts.ToList();
                    int count = 0;
                    foreach (Account account in accounts)
                    {
                        Console.WriteLine($"number {count}:  {account.Email}");
                        count++;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to connect to the database.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
