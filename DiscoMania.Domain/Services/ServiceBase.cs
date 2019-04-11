using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscoMania.Domain.Services
{
    public abstract class ServiceBase<TEntity, TRepository, TFilter> : IServiceBase<TEntity, TFilter> where TEntity : Base<TEntity>
        where TRepository : IRepositoryBase<TEntity, TFilter>
        where TFilter : FilterBase
    {
        protected TRepository _repository;

        protected ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            var list = items.ToList();
            _repository.AddRange(list);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual IEnumerable<TEntity> FindByFilterSimple(TFilter filter)
        {
            return _repository.FindByFilter(filter);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> items)
        {
            var list = items.ToList();
            if (list != null)
                _repository.DeleteRange(list);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public PagedList<TEntity> FindByFilter(TFilter filter)
        {
            return _repository.FindByFilter(filter);
        }
    }
}
