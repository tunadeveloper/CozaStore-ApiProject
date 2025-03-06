using CozaStore.WebUI.Dtos.Feature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7065/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                var totalFeature = values.Count();
                var totalPages = (int)Math.Ceiling((double)totalFeature / pageSize);

                var pagedFeature = values.OrderBy(x=>x.ID)
                    .Skip((page -1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ViewBag.TotalPages =totalPages;
                ViewBag.CurrentPage = page;

                return View(pagedFeature);
            }
            return View();
        }
    }
}
