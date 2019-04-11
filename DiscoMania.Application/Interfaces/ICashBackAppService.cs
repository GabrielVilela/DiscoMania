using DiscoMania.Application.ViewModel;
using DiscoMania.Helper.Enums;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Interfaces
{
    public interface ICashBackAppService : IAppServiceBase<CashBackViewModel, CashBackFilter>
    {
        CashBackViewModel RetornaPorGenero(EnumGenero genero);
        decimal CalculaPercentCashBack(DateTime data, EnumGenero genero);
    }
}
