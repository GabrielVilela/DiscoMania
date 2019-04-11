using DiscoMania.Domain.Interfaces;
using DiscoMania.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBContext _dbContext;
        private bool _disposed;

        public UnitOfWork(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
