using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZStore_BLL.DTO;
using ZStore_BLL.Models;
using ZStore_DAL.Interface;

namespace ZStore_API.Controllers_Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository) 
        {
            this.productRepository = productRepository;
        }

        //API METHOD
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProductsAsync());
            }catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                var productId = await productRepository.AddProductAsync(productDTO);
                var newProduct = await productRepository.GetProductByIdAsync(productId);
                return newProduct == null ? NotFound() : Ok(newProduct);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
