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
    public class DiscoAppService : AppServiceBase<Disco, DiscoViewModel, DiscoFilter>, IDiscoAppService
    {
        private new readonly IDiscoService _service;
        public DiscoAppService(IUnitOfWork uow, IDiscoService service, IMapper mapper) : base(uow, service, mapper)
        {
            _service = service;
        }
    }
}
