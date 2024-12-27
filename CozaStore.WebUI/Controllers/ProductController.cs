using CozaStore.WebUI.Dtos.Category;
using CozaStore.WebUI.Dtos.Product;
using CozaStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var categoryResponse = await client.GetAsync("https://localhost:7065/api/Category");
            List<ResultCategoryDto> categories = new();
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
            }

            var productResponse = await client.GetAsync("https://localhost:7065/api/Product");
            List<ResultProductDto> products = new();
            if (productResponse.IsSuccessStatusCode)
            {
                var productData = await productResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);
            }

            var viewModel = new ProductIndexViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel); 
        }



        public async Task<IActionResult> CategoryProducts(int categoryId)
        {
            var client = _httpClientFactory.CreateClient();

            var categoryResponse = await client.GetAsync("https://localhost:7065/api/Category");
            List<ResultCategoryDto> categories = new();
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
            }

            var productResponse = await client.GetAsync($"https://localhost:7065/api/Product/GetProductsByCategory?categoryId={categoryId}");
            List<ResultProductDto> products = new();
            if (productResponse.IsSuccessStatusCode)
            {
                var productData = await productResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);
            }

            var viewModel = new ProductIndexViewModel
            {
                Products = products, 
                Categories = categories
            };

            return View("Index", viewModel);
        }




    }
}
