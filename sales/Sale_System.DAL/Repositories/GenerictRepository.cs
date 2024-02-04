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

        public async Task<IQueryable<TModel>> Consult(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel>queryModel = filter == null? _salesContext.Set<TModel>(): _salesContext.Set<TModel>().Where(filter);
                return queryModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _salesContext.Set<TModel>().Add(model);
                await _salesContext.SaveChangesAsync();
                return model;
            }catch 
            {
                throw;
            }
        }

        public async Task<bool> delete(TModel model)
        {
            try
            {
                _salesContext.Set<TModel>().Remove(model);
                await _salesContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _salesContext.Set<TModel>().Update(model);
                await _salesContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Get(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _salesContext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}
