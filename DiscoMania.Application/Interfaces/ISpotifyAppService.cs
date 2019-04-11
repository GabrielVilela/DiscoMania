using DiscoMania.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Interfaces
{
    public interface ISpotifyAppService
    {
        void AdicionaDiscoSpotify(SpotifyCredentialsViewModel spotifyCredentials);
    }
}
