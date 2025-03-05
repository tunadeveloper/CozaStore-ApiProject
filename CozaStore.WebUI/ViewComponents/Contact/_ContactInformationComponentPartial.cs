using CozaStore.WebUI.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.ViewComponents.Contact
{
    public class _ContactInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactInformationComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7065/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
