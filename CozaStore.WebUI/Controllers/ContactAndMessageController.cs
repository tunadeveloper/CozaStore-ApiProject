using CozaStore.WebUI.Dtos.Message;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CozaStore.WebUI.Controllers
{

    public class ContactAndMessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactAndMessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateMessageDto createMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createMessageDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7065/api/Message", jsonContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ContactAndMessage");
            }
            return View();
        }
    }
}
