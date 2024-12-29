using CozaStore.BusinessLayer.Abstract;
using CozaStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutService _aboutService;

        public AboutManager(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public void TDelete(int id)
        {
          _aboutService.TDelete(id);
        }

        public List<About> TGetAll()
        {
            return _aboutService.TGetAll();
        }

        public About TGetById(int id)
        {
          return _aboutService.TGetById(id);
        }

        public void TInsert(About entity)
        {
            _aboutService.TInsert(entity);
        }

        public void TUpdate(About entity)
        {
           _aboutService.TUpdate(entity);
        }
    }
}
