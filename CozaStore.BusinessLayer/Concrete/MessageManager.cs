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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TDelete(int id)
        {
            _messageDAL.Delete(id);
        }

        public List<Message> TGetAll()
        {
           return _messageDAL.GetAll();
        }

        public Message TGetById(int id)
        {
           return _messageDAL.GetByID(id);
        }

        public void TInsert(Message entity)
        {
           _messageDAL.Instert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDAL.Update(entity);
        }
    }
}
