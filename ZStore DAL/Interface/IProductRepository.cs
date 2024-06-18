using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore_BLL.Models;

namespace ZStore_DAL.Interface
{
    public interface IProductRepository
    {   


        //lấy ra toàn bộ danh sách sản phẩm
        Task<IEnumerable<Product>> GetProductsAsync();

        //lấy ra 1 sản phẩm theo id
        Task<Product> GetProductByIdAsync(int ID);

        //lấy ra một sản phẩm theo category id

        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsycn(int ID);
    }
}
