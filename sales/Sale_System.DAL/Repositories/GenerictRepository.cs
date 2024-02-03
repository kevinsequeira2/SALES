using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sale_System.DAL.Repositories.Contract;
/*using Sale_System.DAL.DBContext;*/
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Sale_system.MODEL.DAL.DBContext;

namespace Sale_System.DAL.Repositories
{
    public class GenerictRepository<TModel>: IGenerictRepository<TModel>where TModel : class
    {
        private readonly DbSalesContext _salesContext;

        public GenerictRepository(DbSalesContext salesContext)
        {
            _salesContext=salesContext;
        }

        public Task<IQueryable<TModel>> Consult(Expression<Func<TModel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Create(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> delete(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Get(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
