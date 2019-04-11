using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities.SpotiFyEntities;
using DiscoMania.Domain.SpotifyInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Services
{
    public class SpotifyAppService : ISpotifyAppService
    {
        public readonly ISpotifyService _spotifyService;
        private readonly IDiscoAppService _discoAppService;
        private readonly IMapper _mapper;
        public SpotifyAppService(ISpotifyService spotifyService, IDiscoAppService discoAppService, IMapper mapper)
        {
            _spotifyService = spotifyService;
            _mapper = mapper;
            _discoAppService = discoAppService;
        }
        public void AdicionaDiscoSpotify(SpotifyCredentialsViewModel spotifyCredentials)
        {
            var discos =_spotifyService.PesquisarDiscoSpotify(_mapper.Map<SpotifyCredentials>(spotifyCredentials));
            _discoAppService.AddRange(_mapper.Map<List<DiscoViewModel>>(discos));

        }
    }
}
