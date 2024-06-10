using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            //TestDatabaseConnection();
            convertJSON();
        }

        public static void convertJSON()
        {
            try
            {
                using (var context = new ZStore_SampleContext())
                {
                    var products = context.Products.ToList();
                    var items = context.Items.ToList();
                    var variants = context.Variants.ToList();
                    var variantValues = context.VariantValues.ToList();

                    var JSONProduct = products.Select(p => new
                    {
                        p.ProductId,
                        p.Title,
                        p.ItemCount,
                        Items = items.Where(item => item.ItemId == p.ProductId).Select(item => new
                        {
                            item.ItemId,
                            item.Title,
                            item.Content,
                            Variants = variants.Where(variant => variant.ItemVariants.Any(iv => iv.ItemId == item.ItemId)).Select(variant => new
                            {
                                variant.VariantId,
                                variant.Title,
                                VariantValues = variantValues.Where(vv => vv.ItemId == item.ItemId).Select(vv => new
                                {
                                    vv.VariantValueId,
                                    vv.Value
                                })
                            })
                        })
                    }).ToList();

                    var jsonString = JsonConvert.SerializeObject(JSONProduct, Formatting.Indented);

                    // Print the JSON string to the console
                    Console.WriteLine(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to connect to the database or retrieve product information.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestDatabaseConnection()
        {
            try
            {
                using (var context = new ZStore_SampleContext())
                {
                    var products = context.Products.ToList();
<<<<<<< HEAD
=======
                    var items = context.Items.ToList();
                    var variants = context.Variants
                                            .Include(v => v.VariantValues)
                                            .Include(v => v.ItemVariants)
                                            .ToList();



>>>>>>> 08259b8acbb553d979dc613b29a44fe5f9a06d40
                    if (products.Any())
                    {
                        Console.WriteLine("Product information retrieved successfully:");
                        foreach (var product in products)
                        {
                            Console.WriteLine($"productID: {product.ProductId}, Product Title: {product.Title}, Item Count: {product.ItemCount}");
                            foreach (var item in items)
                            {
                                if (item.ProductId == product.ProductId)
                                {
                                    Console.WriteLine($"\t - itemID: {item.ItemId}, Product Title: {item.Title}, Item Count: {item.Content}");
                                    foreach (var variant in variants)
                                    {
                                        if (variant.ItemVariants.Any(iv => iv.ItemId == item.ItemId))
                                        {
                                            Console.WriteLine($"\t\t- VariantID: {variant.VariantId}, Variant Title: {variant.Title}");
                                            foreach (var variantValue in variant.VariantValues)
                                            {
                                                if (variantValue.ItemId == item.ItemId)
                                                {
                                                    Console.WriteLine($"\t\t\t- Variant Value ID: {variantValue.VariantValueId}, Value: {variantValue.Value}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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
