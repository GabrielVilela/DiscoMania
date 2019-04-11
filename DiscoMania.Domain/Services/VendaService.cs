using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Services
{
    public class VendaService : ServiceBase<Venda, IVendaRepository, VendaFilter>, IVendaService
    {
        public VendaService(IVendaRepository repository) : base(repository)
        {
        }
        public Venda FindByIdCompleta(int id)
        {
            return _repository.FindByIdCompleta(id);
        }
    }
}
