using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.CategoryDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category();
            category.CategoryName = createCategoryDto.CategoryName;

            _categoryService.TInsert(category);
            return Ok("Veri ekleme işlemi gerçekleşti!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Veri silme işlemi gerçekleşti!");
        }

        [HttpGet("GetCateory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category();
            category.CategoryID = updateCategoryDto.CategoryID;
            category.CategoryName= updateCategoryDto.CategoryName;

            _categoryService.TUpdate(category);
            return Ok("Veri güncelleme işlemi gerçekleşti!");
        }

    }
}
