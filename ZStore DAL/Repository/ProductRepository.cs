using AutoMapper;
using ZStore_BLL.DTO;
using ZStore_BLL.Models;
using ZStore_DAL.DAO;
using ZStore_DAL.Interface;

namespace ZStore_DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> UserGetProductsAsync()
        {
            var products = await ProductDAO.Instance.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> UserGetProductByIdAsync(int productId)
        {
            var product = await ProductDAO.Instance.GetProductByIdAsync(productId);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync() => await ProductDAO.Instance.GetProductsAsync();

        public async Task<Product> GetProductByIdAsync(int productId) => await ProductDAO.Instance.GetProductByIdAsync(productId);

        public async Task<int> AddProductAsync(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            return await ProductDAO.Instance.AddProductAsync(newProduct);
        }

        public async Task UpdateProductAsync(ProductDTO product)
        {
            var updateProduct = _mapper.Map<Product>(product);
            await ProductDAO.Instance.UpdateProductAsync(updateProduct);
        }

        public async Task DeleteProductAsync(int productId) => await ProductDAO.Instance.DeleteProductAsync(productId);

    }
}
