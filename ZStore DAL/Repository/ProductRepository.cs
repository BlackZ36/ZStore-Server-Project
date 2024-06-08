using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;
using ZStore_DAL.Interface;

namespace ZStore_DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductsAsync() => ProductDAO.Instance.GetProductsAsync();
        public Task<Product> GetProductByIdAsync(int ID) => ProductDAO.Instance.GetProductByIdAsync(ID);
        public Task<bool> AddProductAsync(Product product) => ProductDAO.Instance.AddProductAsync(product);
        public Task<bool> UpdateProductAsync(Product product) => ProductDAO.Instance.UpdateProductAsync(product);
        public Task<bool> DeleteProductAsycn(int ID) => ProductDAO.Instance.DeleteProductAsync(ID);
    }
}
