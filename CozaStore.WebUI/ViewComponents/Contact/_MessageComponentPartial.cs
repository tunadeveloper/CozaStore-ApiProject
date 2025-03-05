using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.ViewComponents.Contact
{
    public class _MessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
