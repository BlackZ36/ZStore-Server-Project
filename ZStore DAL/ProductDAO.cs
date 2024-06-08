using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;

namespace ZStore_DAL
{
    internal class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new Object();

        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }


        //Method Below
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = new List<Product>();
            try
            {
                using var context = new ZStore_SampleContext();
                products = await context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occureed: {ex.Message}");
            }
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int ID)
        {
            var product = new Product();
            try
            {
                using var context = new ZStore_SampleContext();
                product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occureed: {ex.Message}");
            }
            return product;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product Object Cannot Be Null");
                }
                using var context = new ZStore_SampleContext();
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occureed: {ex.Message}");
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<bool> DeleteProductAsync(int ID)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                Product product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == ID);
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product Object Cannot Be Null");
                }
                context.Products.Remove(product);
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
