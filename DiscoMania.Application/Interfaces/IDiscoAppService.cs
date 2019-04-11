using DiscoMania.Application.ViewModel;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;

namespace DiscoMania.Application.Interfaces
{
    public interface IDiscoAppService : IAppServiceBase<DiscoViewModel, DiscoFilter>
    {
    }
}
