using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Helper.Enums;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Services
{
    public class CashBackAppService : AppServiceBase<CashBack, CashBackViewModel, CashBackFilter>, ICashBackAppService
    {
        private new readonly ICashBackService _service;
        public CashBackAppService(IUnitOfWork uow, ICashBackService service, IMapper mapper) : base(uow, service, mapper)
        {
            _service = service;
        }
        public CashBackViewModel RetornaPorGenero(EnumGenero genero)
        {
            return _mapper.Map<CashBackViewModel>(_service.RetornaPorGenero(genero));
        }
        public decimal CalculaPercentCashBack(DateTime data, EnumGenero genero)
        {
            var cashBack = this.RetornaPorGenero(genero);
            decimal percentualCashBack = 0;
            switch (data.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Domingo)/100;
                    break;
                case DayOfWeek.Monday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Segunda)/ 100;
                    break;
                case DayOfWeek.Tuesday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Terca)/ 100;
                    break;
                case DayOfWeek.Wednesday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Quarta) / 100;
                    break;
                case DayOfWeek.Thursday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Quinta)/ 100;
                    break;
                case DayOfWeek.Friday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Sexta)/ 100;
                    break;
                case DayOfWeek.Saturday:
                    percentualCashBack = Convert.ToDecimal(cashBack.Sabado)/ 100;
                    break;
            }
            return percentualCashBack;
        }
    }
}
