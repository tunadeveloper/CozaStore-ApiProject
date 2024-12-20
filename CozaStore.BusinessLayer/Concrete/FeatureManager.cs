using CozaStore.BusinessLayer.Abstract;
using CozaStore.DataAccessLayer.Abstract;
using CozaStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TDelete(int id)
        {
           _featureDAL.Delete(id);  
        }

        public List<Feature> TGetAll()
        {
            return _featureDAL.GetAll();
        }

        public Feature TGetById(int id)
        {
           return _featureDAL.GetByID(id);
        }

        public void TInsert(Feature entity)
        {
           _featureDAL.Instert(entity);
        }

        public void TUpdate(Feature entity)
        {
            _featureDAL.Update(entity);
        }
    }
}
