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
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void TDelete(int id)
        {
           _productDAL.Delete(id);
        }

        public List<Product> TGetAll()
        {
            return _productDAL.GetAll();
        }

        public Product TGetById(int id)
        {
           return _productDAL.GetByID(id);
        }

        public void TInsert(Product entity)
        {
          _productDAL.Instert(entity);
        }

        public void TUpdate(Product entity)
        {
           _productDAL.Update(entity);
        }
    }
}
