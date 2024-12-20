using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Delete(int id);
        void Instert(T entity);
        void Update(T entity);
        T GetByID(int id);
        List<T> GetAll();
    }
}
