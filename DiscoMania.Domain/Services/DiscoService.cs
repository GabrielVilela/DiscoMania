using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Services
{
    public class DiscoService : ServiceBase<Disco, IDiscoRepository, DiscoFilter>, IDiscoService
    {
        public DiscoService(IDiscoRepository repository) : base(repository)
        {
        }
    }
}
