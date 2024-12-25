using CozaStore.BusinessLayer.Abstract;
using CozaStore.EntityLayer.Concrete;
using CozaStore.WebUI.Dtos;
using CozaStore.WebUI.Dtos.Category;
using CozaStore.WebUI.Dtos.Product;
using CozaStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozaStore.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
