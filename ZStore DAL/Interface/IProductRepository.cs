using ZStore_BLL.DTO;
using ZStore_BLL.Models;

namespace ZStore_DAL.Interface
{
    public interface IProductRepository
    {
        //User
        Task<IEnumerable<ProductDTO>> UserGetProductsAsync();
        Task<ProductDTO> UserGetProductByIdAsync(int productId);

        //Admin
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(ProductDTO product);
        Task UpdateProductAsync(ProductDTO product);
        Task DeleteProductAsync(int productId);
    }
}
