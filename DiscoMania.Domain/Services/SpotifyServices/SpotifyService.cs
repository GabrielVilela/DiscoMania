using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Entities.SpotiFyEntities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Domain.SpotifyInterface.Interfaces;
using DiscoMania.Helper.Enums;
using Newtonsoft.Json;
using SpotifyWebApi.Auth;
using SpotifyWebApi.Model.Enum;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static DiscoMania.Domain.Entities.SpotiFyEntities.Spotify;

namespace DiscoMania.Domain.Services.SpotifyServices
{
    public class SpotifyService : ISpotifyService
    {
        public readonly IDiscoService _discoService;
        public SpotifyService(IDiscoService discoService)
        {
            _discoService = discoService;
        }

        public List<Disco> PesquisarDiscoSpotify(SpotifyCredentials spotifyCredentials)
        {
            var token = ClientCredentials.GetToken(new AuthParameters
            {
                ClientId = spotifyCredentials.ClientId,
                ClientSecret = spotifyCredentials.ClientSecret,
                Scopes = Scope.All,
            });

            //adicionando discos do gênero Rock
            var discosRock = GetAlbums(token.AccessToken, "rock");
            discosRock.Wait();

            // adicionando discos do gênero MPB
            var discosMPB = GetAlbums(token.AccessToken, "mpb");
            discosMPB.Wait();

            // adicionando discos do gênero MPB
            var discosPOP = GetAlbums(token.AccessToken, "pop");
            discosPOP.Wait();

            // adicionando discos do gênero Clássico
            var discosClassico = GetAlbums(token.AccessToken, "classical");
            discosClassico.Wait();

            List<Disco> listaDiscos = new List<Disco>();

            if (discosRock.Result != null && discosRock.Result.tracks != null)
            {
                listaDiscos.AddRange(RetornaDiscos(EnumGenero.Rock, discosRock.Result.tracks));
            }

            if (discosMPB.Result != null && discosMPB.Result.tracks != null)
            {
                listaDiscos.AddRange(RetornaDiscos(EnumGenero.MPB, discosMPB.Result.tracks));
            }

            if (discosPOP.Result != null && discosPOP.Result.tracks != null)
            {
                listaDiscos.AddRange(RetornaDiscos(EnumGenero.POP, discosPOP.Result.tracks));
            }

            if (discosClassico.Result != null && discosClassico.Result.tracks != null)
            {
                listaDiscos.AddRange(RetornaDiscos(EnumGenero.Classic, discosClassico.Result.tracks));
            }


            return listaDiscos;
            
        }

        private static List<Disco> RetornaDiscos(EnumGenero genero, List<Track> discos)
        {
            List<Disco> listaDiscos = new List<Disco>();

            foreach (var d in discos)
            {
                Disco disco = new Disco()
                {
                    Genero = genero,
                    NomeArtista = d.album.artists.Count > 0 ? d.album.artists[0].name : string.Empty,
                    TituloAlbum = d.album.name,
                    Valor = Math.Round(new Random().Next(1000) / 13.6m, 2)
                };
                listaDiscos.Add(disco);
            }
            return listaDiscos;
        }
        private static async Task<RootObject> GetAlbums(string token, string type)
        {
            var teste = new RootObject();
            using (var client = new HttpClient())
            {
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var query = HttpUtility.ParseQueryString(string.Empty);
                query["limit"] = "50";
                query["market"] = "BR";
                query["seed_genres"] = type;
                string queryString = query.ToString();
               
                //Request Token
                var request = await client.GetAsync("https://api.spotify.com/v1/recommendations?" + queryString);
                var response = await request.Content.ReadAsStringAsync();
                teste = JsonConvert.DeserializeObject<RootObject>(response);

            }
            return teste;
        }
    }
}
