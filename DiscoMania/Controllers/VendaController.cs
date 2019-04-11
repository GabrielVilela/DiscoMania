using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using Filters.DomainFilters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DiscoMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : Controller
    {
        public readonly IVendaAppService _vendaAppService;
        public readonly IDiscoVendaAppService _discoVendaAppService;
        public readonly IMapper _mapper;
        public VendaController(IVendaAppService vendaAppService, IDiscoVendaAppService discoVendaAppService, IMapper mapper)
        {
            _vendaAppService = vendaAppService;
            _discoVendaAppService = discoVendaAppService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            try
            {
                var result = _vendaAppService.FindById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
        [HttpGet("GetVendaCompletaById/{id}")]
        public IActionResult GetVendaCompletaById(int id)
        {
            try
            {
                var result = _vendaAppService.FindByIdCompleta(id);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetVendaByFilter/")]
        public IActionResult GetVendas([FromQuery] VendaFilter filter)
        {
            return Ok(_vendaAppService.FindByFilter(filter));
        }
        [HttpPost("InserirVenda")]
        public IActionResult PostVenda([FromBody] VendaMinViewModel venda)
        {
            try
            {
                var result = _vendaAppService.Add(_mapper.Map<VendaViewModel>(venda));

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("InserirVendaCompleta")]
        public IActionResult PostVendaCompleta([FromBody] VendaCompletaMinViewModel venda)
        {
            try
            {
                var result = _vendaAppService.AddCompleta(_mapper.Map<VendaViewModel>(venda));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}