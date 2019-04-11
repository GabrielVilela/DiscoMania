using DiscoMania.Domain.Entities;
using Filters.DomainFilters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Interfaces
{
    public interface IDiscoRepository : IRepositoryBase<Disco, DiscoFilter>
    {
       
    }
}
