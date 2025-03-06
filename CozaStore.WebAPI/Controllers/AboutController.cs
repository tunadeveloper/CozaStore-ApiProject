using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.AboutDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var existingAbout = _aboutService.TGetById(updateAboutDto.AboutID);

            if (existingAbout == null)
            {
                return NotFound("Güncellenecek veri bulunamadı!");
            }

            existingAbout.ImageURL1 = updateAboutDto.ImageURL1;
            existingAbout.ImageURL2 = updateAboutDto.ImageURL2;
            existingAbout.Title1 = updateAboutDto.Title1;
            existingAbout.Title2 = updateAboutDto.Title2;
            existingAbout.Description1 = updateAboutDto.Description1;
            existingAbout.Description2 = updateAboutDto.Description2;

            _aboutService.TUpdate(existingAbout);

            return Ok("Veri güncelleme işlemi gerçekleşti!");
        }


        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Veri silme işlemi gerçekleşti!");
        }

         [HttpPost]
         public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About();

            about.ImageURL1 = createAboutDto.ImageURL1;
            about.ImageURL2 = createAboutDto.ImageURL2;
            about.Title1 = createAboutDto.Title1;
            about.Title2 = createAboutDto.Title2;
            about.Description1 = createAboutDto.Description1;
            about.Description2 = createAboutDto.Description2;

            _aboutService.TInsert(about);
            return Ok("Veri ekleme işlemi gerçekleşti!");
        }

    }
}
