using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Entities.SpotiFyEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Domain.SpotifyInterface.Interfaces
{
    public interface ISpotifyService
    {
        List<Disco> PesquisarDiscoSpotify(SpotifyCredentials spotifyCredentials);
    }
}
