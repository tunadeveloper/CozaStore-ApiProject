using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.ViewComponents.Contact
{
    public class _MessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MessageComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List);
            }
            return View();
        }
    }
}
