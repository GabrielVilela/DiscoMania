using DiscoMania.Domain.Entities;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Interfaces
{
    public interface IVendaRepository : IRepositoryBase<Venda, VendaFilter>
    {
        Venda FindByIdCompleta(int id);
    }
}
