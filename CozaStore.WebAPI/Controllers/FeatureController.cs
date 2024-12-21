using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.FeatureDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        Feature feature = new Feature();
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            feature.Title = createFeatureDto.Title;
            feature.Subtitle = createFeatureDto.Subtitle;
            feature.ImageURL = createFeatureDto.ImageURL;

            _featureService.TInsert(feature);
            return Ok("Veri ekleme işlemi gerçekleşti!");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return Ok("Veri silme işlemi gerçekleşti!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            feature.ID = updateFeatureDto.ID;
            feature.Title = updateFeatureDto.Title;
            feature.Subtitle = updateFeatureDto.Subtitle;
            feature.ImageURL= updateFeatureDto.ImageURL;

            _featureService.TUpdate(feature);
            return Ok("Veri güncelleme işlemi gerçekleşti!");
        }
    }
}
