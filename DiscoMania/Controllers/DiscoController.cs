using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using Filters.DomainFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DiscoMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoController : ControllerBase
    {
        public readonly IDiscoAppService _discoAppService;
        private readonly IOptions<SpotifyCredentialsViewModel> spotifyCredential;
        private readonly ISpotifyAppService _spotifyService;
        public DiscoController(IDiscoAppService discoAppService, ISpotifyAppService spotifyService, IOptions<SpotifyCredentialsViewModel> spotifyCredential)
        {
            _discoAppService = discoAppService;
            this.spotifyCredential = spotifyCredential;
            _spotifyService = spotifyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetDisco([FromRoute] int id)
        {
            var disco = _discoAppService.FindById(id);

            if (disco == null)
            {
                return NotFound();
            }

            return Ok(disco);
        }
        [HttpGet("AdicionarDiscoSpotify/")]
        public IActionResult AdicionarDiscoSpotify()
        {
            _spotifyService.AdicionaDiscoSpotify(this.spotifyCredential.Value);

            return Ok(this.spotifyCredential);
        }

        [HttpGet("GetDiscosByFilter/")]
        public IActionResult GetDiscos([FromQuery] DiscoFilter filter)
        {
            return Ok(_discoAppService.FindByFilter(filter));
        }
        [HttpPost]
        public IActionResult PostDisco([FromBody] DiscoViewModel disco)
        {
            return Ok(_discoAppService.Add(disco));
        }
    }
}
