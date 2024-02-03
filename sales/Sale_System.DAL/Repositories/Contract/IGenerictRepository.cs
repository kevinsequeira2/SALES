﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sale_System.DAL.Repositories.Contract
{
    public interface IGenerictRepository<TModel>where TModel: class
    {
        Task<TModel> Get(Expression<Func<TModel,bool>>filter);
        Task<TModel> Create(TModel model);

        Task<bool> Edit(TModel model);

        Task<bool> delete(TModel model);

        Task<IQueryable<TModel>>Consult(Expression<Func<TModel,bool>>filter= null);



    }
}
