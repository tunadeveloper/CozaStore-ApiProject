using CozaStore.DataAccessLayer.Abstract;
using CozaStore.DataAccessLayer.Context;
using CozaStore.DataAccessLayer.Repositories;
using CozaStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DataAccessLayer.EntityFramework
{
    public class EfProductDAL : GenericRepositories<Product>, IProductDAL
    {
        public EfProductDAL(ApiContext context) : base(context)
        {
        }
    }
}
