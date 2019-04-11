using DiscoMania.Domain.Entities;
using DiscoMania.Helper.Enums;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Interfaces
{
    public interface ICashBackService : IServiceBase<CashBack, CashBackFilter>
    {
        CashBack RetornaPorGenero(EnumGenero genero);
    }
}
