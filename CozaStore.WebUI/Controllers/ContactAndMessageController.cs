using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebUI.Controllers
{
    public class ContactAndMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
