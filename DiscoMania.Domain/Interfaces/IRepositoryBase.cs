using DiscoMania.Domain.Entities;
using Filters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DiscoMania.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity, TFilter> : IDisposable
        where TEntity : Base<TEntity>
        where TFilter : FilterBase
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> items);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
        void DeleteRange(IEnumerable<TEntity> items);
        TEntity Update(TEntity entity);
        PagedList<TEntity> FindByFilter(TFilter filter);
        int SaveChanges();
    }
}
