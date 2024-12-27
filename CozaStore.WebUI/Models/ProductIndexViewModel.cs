using CozaStore.WebUI.Dtos.Category;
using CozaStore.WebUI.Dtos.Product;

namespace CozaStore.WebUI.Models
{
    public class ProductIndexViewModel
    {
        public List<ResultProductDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}