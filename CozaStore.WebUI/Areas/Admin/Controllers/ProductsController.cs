using CozaStore.WebUI.Dtos.About;
using CozaStore.WebUI.Dtos.Category;
using CozaStore.WebUI.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CozaStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7065/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);

                var responseMessageCategories = await client.GetAsync("https://localhost:7065/api/Category");
                if (responseMessageCategories.IsSuccessStatusCode)
                {
                    var jsonDataCategories = await responseMessageCategories.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategories);

                    foreach (var product in products)
                    {
                        var category = categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
                        product.CategoryName = category?.CategoryName;
                    }

                    var totalProduct = products.Count();
                    var totalPages = (int)Math.Ceiling((double)totalProduct / pageSize);

                    var pagedProduct = products.OrderBy(x => x.ID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    ViewBag.TotalPages = totalPages;
                    ViewBag.CurrentPage = page;

                    return View(pagedProduct);
                }
            }

            return View();
        }


        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7065/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7065/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Products");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7065/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            }


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7065/api/Product/GetProduct?id=" + id);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var updatedValue = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
                return View(updatedValue);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateProductDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7065/api/Product", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7065/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}




//public async Task<IActionResult> DeleteProduct(int id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var responseMessage = await client.DeleteAsync($"https://localhost:7065/api/Product/{id}");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }
//    return View();
//}

//public async Task<IActionResult> CreateProduct()
//{
//    var client = _httpClientFactory.CreateClient();
//    var responseMessage = await client.GetAsync("https://localhost:7065/api/Category");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        var jsonData = await responseMessage.Content.ReadAsStringAsync();
//        var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

//        ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
//    }

//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
//{

//    var client = _httpClientFactory.CreateClient();
//    var jsonData = JsonConvert.SerializeObject(createProductDto);
//    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//    var responseMessage = await client.PostAsync("https://localhost:7065/api/Product", stringContent);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index", "Products");
//    }
//    return View();
//}

//[HttpGet]
//public async Task<IActionResult> UpdateProduct(int id)
//{
//    var client = _httpClientFactory.CreateClient();

//    var responseMessage = await client.GetAsync("https://localhost:7157/api/Category");

//    var jsonData = await responseMessage.Content.ReadAsStringAsync();

//    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

//    List<SelectListItem> values2 = (from x in values
//                                    select new SelectListItem
//                                    {
//                                        Text = x.CategoryName,
//                                        Value = x.CategoryID.ToString()
//                                    }).ToList();

//    ViewBag.v = values2;


//    var client2 = _httpClientFactory.CreateClient();
//    var responseMessage2 = await client2.GetAsync("https://localhost:7157/api/Product/GetProduct?id=" + id);

//    if (responseMessage2.IsSuccessStatusCode)
//    {
//        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
//        var updatedValue = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
//        return View(updatedValue);
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
//{
//    var client = _httpClientFactory.CreateClient();

//    var jsonData = JsonConvert.SerializeObject(updateProductDto);

//    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync("https://localhost:7157/api/Product", stringContent);

//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }

//    return View();
//}