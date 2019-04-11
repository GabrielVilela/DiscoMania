using DiscoMania.Application.ViewModel;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Interfaces
{
    public interface IVendaAppService : IAppServiceBase<VendaViewModel, VendaFilter>
    {
        VendaViewModel FindByIdCompleta(int id);
        VendaViewModel AddCompleta(VendaViewModel venda);
    }
}
