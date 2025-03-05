using CozaStore.WebUI.Dtos.Category;
using CozaStore.WebUI.Dtos.Product;
using CozaStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CozaStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // 📌 Kategorileri getiren yardımcı metod
        private async Task<List<ResultCategoryDto>> GetCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7065/api/Category");

            if (!response.IsSuccessStatusCode)
                return new List<ResultCategoryDto>();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
        }

        // 📌 Tüm ürünleri getiren yardımcı metod
        private async Task<List<ResultProductDto>> GetProductsAsync(string endpoint)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                return new List<ResultProductDto>();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductDto>>(data);
        }

        // 📌 Tüm ürünleri listeleme
        public async Task<IActionResult> Index()
        {
            var categories = await GetCategoriesAsync();
            var products = await GetProductsAsync("https://localhost:7065/api/Product");

            var viewModel = new ProductIndexViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel);
        }

        // 📌 Kategoriye göre ürünleri listeleme
        public async Task<IActionResult> CategoryProducts(int categoryId)
        {
            var categories = await GetCategoriesAsync();
            var products = await GetProductsAsync($"https://localhost:7065/api/Product/GetProductsByCategory?categoryId={categoryId}");

            var viewModel = new ProductIndexViewModel
            {
                Products = products,
                Categories = categories
            };

            return View("Index", viewModel);
        }

        // 📌 Ürün detay sayfası
        public async Task<IActionResult> Detail(int id)
        {
            var product = await GetProductsAsync($"https://localhost:7065/api/Product/{id}");

            if (product == null || product.Count == 0)
                return NotFound();

            return View(product[0]);
        }
    }
}
