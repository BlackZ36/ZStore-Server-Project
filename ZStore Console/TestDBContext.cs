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
                    var canConnect = context.Database.CanConnect();
                    if (canConnect)
                    {
                        Console.WriteLine("Connection to the database was successful!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to connect to the database.");
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
