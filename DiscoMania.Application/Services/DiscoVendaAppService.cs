using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters.DomainFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Services
{
    public class DiscoVendaAppService : AppServiceBase<DiscoVenda, DiscoVendaViewModel, DiscoVendaFilter>, IDiscoVendaAppService
    {
        private new readonly IDiscoVendaService _service;
        public DiscoVendaAppService(IUnitOfWork uow, IDiscoVendaService service, IMapper mapper) : base(uow, service, mapper)
        {
            _service = service;
        }
    }
}
