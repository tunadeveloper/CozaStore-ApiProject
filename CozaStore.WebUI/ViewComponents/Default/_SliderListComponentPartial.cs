using CozaStore.BusinessLayer.Abstract;
using CozaStore.WebUI.Dtos.Feature;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebUI.ViewComponents.Default
{
    public class _SliderListComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _SliderListComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            var features = _featureService.TGetAll();
            var resultFeatures = features.Select(x => new ResultFeatureDto
            {
                ID = x.ID,
                Title = x.Title,
                Subtitle = x.Subtitle,
                ImageURL = x.ImageURL
            }).ToList();

            return View(resultFeatures);
        }
    }
}
