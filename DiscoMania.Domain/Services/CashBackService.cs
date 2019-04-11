using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Helper.Enums;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.Services
{
    public class CashBackService : ServiceBase<CashBack, ICashBackRepository, CashBackFilter>, ICashBackService
    {
        public CashBackService(ICashBackRepository repository) : base(repository)
        {
        }

        public CashBack RetornaPorGenero(EnumGenero genero)
        {
            return _repository.RetornaPorGenero(genero);
        }
    }
}
