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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public void TDelete(int id)
        {
            _categoryDAL.Delete(id);
        }

        public List<Category> TGetAll()
        {
            return _categoryDAL.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDAL.GetByID(id);
        }

        public void TInsert(Category entity)
        {
            _categoryDAL.Instert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDAL.Update(entity);
        }
    }
}
