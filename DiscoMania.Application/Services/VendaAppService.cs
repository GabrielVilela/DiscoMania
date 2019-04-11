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
    public class VendaAppService : AppServiceBase<Venda, VendaViewModel, VendaFilter>, IVendaAppService
    {
        private new readonly IVendaService _service;
        private readonly IDiscoVendaAppService _discoVendaAppService;
        private readonly IDiscoAppService _discoAppService;
        private readonly ICashBackAppService _cashBackAppService;
        public VendaAppService(IUnitOfWork uow, IVendaService service, IDiscoVendaAppService discoVendaAppService, IDiscoAppService discoAppService, ICashBackAppService cashBackAppService, IMapper mapper) : base(uow, service, mapper)
        {
            _service = service;
            _discoVendaAppService = discoVendaAppService;
            _discoAppService = discoAppService;
            _cashBackAppService = cashBackAppService;
        }

        public VendaViewModel FindByIdCompleta(int id)
        {
            var venda = _mapper.Map<VendaViewModel>( _service.FindByIdCompleta(id));
            
            return venda;
        }

        public VendaViewModel AddCompleta(VendaViewModel venda)
        {
         

            foreach (var discoVenda in venda.DiscosDaVenda)
            {
                var disco = _discoAppService.FindById(discoVenda.DiscoId);
                venda.ValorTotalVenda += disco.Valor * discoVenda.Qtde;
                venda.ValorTotalCashBack += disco.Valor * discoVenda.Qtde * _cashBackAppService.CalculaPercentCashBack(venda.DataVenda, disco.Genero);
            }
            var v = this.Add(venda);
            foreach(var discoVenda in venda.DiscosDaVenda)
            {
                var disco = _discoAppService.FindById(discoVenda.DiscoId);
                discoVenda.Valor = disco.Valor * discoVenda.Qtde;
                discoVenda.ValorCashBack = disco.Valor * discoVenda.Qtde * _cashBackAppService.CalculaPercentCashBack(venda.DataVenda, disco.Genero);
                discoVenda.VendaId = v.Id;
                discoVenda.Disco = null;
            }
            _discoVendaAppService.AddRange(_mapper.Map<List<DiscoVendaViewModel>>(venda.DiscosDaVenda));

            return _mapper.Map<VendaViewModel>(_service.FindByIdCompleta(v.Id));
        }

    }
}
