using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Core
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        int SaveChanges();
    }
}
