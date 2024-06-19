using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZStore_DAL.Interface;

namespace ZStore_API.Controllers_User
{
    [Route("api/public/[controller]")]
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
                return Ok(await productRepository.UserGetProductsAsync());
            }catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productRepository.UserGetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
