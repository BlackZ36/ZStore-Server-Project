using Microsoft.EntityFrameworkCore;
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
                    var products = context.Products.ToList();
                    if (products.Any())
                    {
                        Console.WriteLine("Product information retrieved successfully:");
                        foreach (var product in products)
                        {
                            Console.WriteLine($"ID: {product.ProductId}, Product Title: {product.Title}, Item Count: {product.Items.Count()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to connect to the database or retrieve product information.");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
