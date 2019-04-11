using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using DiscoMania.Helper.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DiscoMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoVendaController : ControllerBase
    {
        public readonly IVendaAppService _vendaAppService;
        public readonly IDiscoVendaAppService _discoVendaAppService;
        public readonly IDiscoAppService _discoAppService;
        public readonly ICashBackAppService _cashBackAppService;
        public readonly IMapper _mapper;
        public DiscoVendaController(IDiscoVendaAppService discoVendaAppService, IVendaAppService vendaAppService, IDiscoAppService discoAppService, ICashBackAppService cashBackAppService, IMapper mapper)
        {
            _vendaAppService = vendaAppService;
            _discoVendaAppService = discoVendaAppService;
            _mapper = mapper;
            _discoAppService = discoAppService;
            _cashBackAppService = cashBackAppService;
        }
        [HttpPost]
        public IActionResult PostVenda([FromBody]List<DiscoVendaMinViewModel> discoVendas)
        {
            try
            {
                var discosVendas = _mapper.Map<List<DiscoVendaViewModel>>(discoVendas);
                var venda = _vendaAppService.FindById(discoVendas[0].VendaId);
                foreach (var discoVenda in discosVendas)
                {
                    var disco = _discoAppService.FindById(discoVenda.DiscoId);
                    venda.ValorTotalVenda += disco.Valor * discoVenda.Qtde;
                    venda.ValorTotalCashBack += disco.Valor * discoVenda.Qtde * _cashBackAppService.CalculaPercentCashBack(venda.DataVenda, disco.Genero);
                    discoVenda.Valor = disco.Valor * discoVenda.Qtde;
                    discoVenda.ValorCashBack = disco.Valor * discoVenda.Qtde * _cashBackAppService.CalculaPercentCashBack(venda.DataVenda, disco.Genero);
                }
                _vendaAppService.Update(venda);
                _discoVendaAppService.AddRange(_mapper.Map<List<DiscoVendaViewModel>>(discosVendas));
                return Ok(venda);
            }
            catch
            {
                return Forbid();
            }
        }
        [HttpGet("{genero}")]
        public IActionResult GetCashBackByGenero(int genero)
        {
            return Ok(_cashBackAppService.RetornaPorGenero((EnumGenero)genero));
        }

    }
}