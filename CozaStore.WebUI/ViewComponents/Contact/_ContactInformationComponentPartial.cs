using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebUI.ViewComponents.Contact
{
    public class _ContactInformationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
