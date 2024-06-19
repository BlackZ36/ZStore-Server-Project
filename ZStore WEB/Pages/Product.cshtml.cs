using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ZStore_BLL.DTO;

namespace ZStore_WEB.Pages
{
    public class ProductModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ProductModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5291/api/public/Products");
            if (response.IsSuccessStatusCode)
            {
                Products = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
                return Page();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
