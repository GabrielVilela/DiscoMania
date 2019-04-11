using DiscoMania.Domain.Entities;
using Filters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Interfaces
{
    public interface IServiceBase<TEntity, TFilter> : IDisposable where TEntity : Base<TEntity>
        where TFilter : Filters.FilterBase
    {
        void AddRange(IEnumerable<TEntity> items);
        TEntity Add(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        PagedList<TEntity> FindByFilter(TFilter filter);
        IEnumerable<TEntity> FindByFilterSimple(TFilter filter);
        void Delete(int id);
        void DeleteRange(IEnumerable<TEntity> items);
    }
}
