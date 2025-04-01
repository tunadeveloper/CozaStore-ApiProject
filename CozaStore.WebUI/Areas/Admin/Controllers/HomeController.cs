using CozaStore.WebUI.Dtos.Contact;
using CozaStore.WebUI.Dtos.Message;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7065/api/Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);

                var totalMessages = values.Count();
                var totalPages = (int)Math.Ceiling((double)totalMessages / pageSize);

                var pagedMessages = values.OrderByDescending(m => m.MessageID)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();

                ViewBag.TotalPages = totalPages;
                ViewBag.CurrentPage = page;

                return View(pagedMessages);
            }
            return View();
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7065/api/Message?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> MessageDetails()
        {
            return View();

        }
    }
}
