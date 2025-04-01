using CozaStore.BusinessLayer.Abstract;
using CozaStore.DataAccessLayer.Abstract;
using CozaStore.DataAccessLayer.EntityFramework;
using CozaStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.BusinessLayer.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactDAL _contactDal;

        public ContactService(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(int id)
        {
            _contactDal.Delete(id);
        }

        public List<Contact> TGetAll()
        {
           return _contactDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetByID(id);
        }

        public void TInsert(Contact entity)
        {
            _contactDal.Instert(entity);
        }

        public void TUpdate(Contact entity)
        {
           _contactDal.Update(entity);
        }
    }
}
