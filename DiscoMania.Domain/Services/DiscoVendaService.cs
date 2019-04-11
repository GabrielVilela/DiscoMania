using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Services
{
    public class DiscoVendaService : ServiceBase<DiscoVenda, IDiscoVendaRepository, DiscoVendaFilter>, IDiscoVendaService
    {
        public DiscoVendaService(IDiscoVendaRepository repository) : base(repository)
        {
        }
    }
    
}
