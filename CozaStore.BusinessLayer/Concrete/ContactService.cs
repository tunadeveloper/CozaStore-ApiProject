using CozaStore.BusinessLayer.Abstract;
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
        private readonly IContactService _contactService;

        public ContactService(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void TDelete(int id)
        {
            _contactService.TDelete(id);
        }

        public List<Contact> TGetAll()
        {
           return _contactService.TGetAll();
        }

        public Contact TGetById(int id)
        {
           return _contactService.TGetById(id);
        }

        public void TInsert(Contact entity)
        {
            _contactService.TInsert(entity);
        }

        public void TUpdate(Contact entity)
        {
           _contactService.TUpdate(entity);
        }
    }
}
