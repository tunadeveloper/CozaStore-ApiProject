using CozaStore.DataAccessLayer.Abstract;
using CozaStore.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DataAccessLayer.Repositories
{
    public class GenericRepositories<T> : IGenericDAL<T> where T : class
    {
        private readonly ApiContext _context;

        public GenericRepositories(ApiContext context)
        {
            _context = context;
        }


        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Instert(T entity)
        {
          _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
