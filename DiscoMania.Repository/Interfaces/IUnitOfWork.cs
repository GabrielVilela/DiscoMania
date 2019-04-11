using DiscoMania.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Repository.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : IDBContext
    {
        void Commit();
    }
}
