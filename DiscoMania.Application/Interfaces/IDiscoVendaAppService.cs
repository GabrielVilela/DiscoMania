using DiscoMania.Application.ViewModel;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Interfaces
{
    public interface IDiscoVendaAppService : IAppServiceBase<DiscoVendaViewModel, DiscoVendaFilter>
    {
    }
}
