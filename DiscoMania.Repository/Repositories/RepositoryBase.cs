using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Repository.Contexts;
using DiscoMania.Repository.Interfaces;
using Filters;
using Filters.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DiscoMania.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TFilter> : IRepositoryBase<TEntity, TFilter> where TEntity : Base<TEntity>
        where TFilter : FilterBase
    {
        protected readonly IDBContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(IDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            _dbSet.AddRange(items);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity FindById(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void DeleteRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public abstract PagedList<TEntity> FindByFilter(TFilter filter);
    }
}
