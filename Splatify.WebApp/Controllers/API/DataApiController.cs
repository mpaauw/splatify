using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Splatify.Services;
using Splatify.Core;
using System.IO;
using System.Threading.Tasks;

namespace Splatify.WebApp.Controllers.API
{
    [RoutePrefix("api")]
    public class DataApiController : ApiController
    {
        private ArtistService _artistService;
        private WebAPIService _webAPIService;
        private PlaylistService _playListService;
        
        public DataApiController()
        {
            _artistService = new ArtistService();
            _webAPIService = new WebAPIService();
            _playListService = new PlaylistService();
        }

        [HttpGet]
        [Route("artist/{artistId}/{token}")]
        public List<Artist> GetRelatedArtists(HttpRequestMessage request, string artistId, string token)
        {
            List<Artist> relatedArtists = new List<Artist>();
            List<Track> playlistTracks = new List<Track>();           
            Task<MultipleArtists> artists = _artistService.GetRelatedArtists(artistId);
            foreach(Artist artist in artists.Result.Artists)
            {
                relatedArtists.Add(artist);
            }          
            foreach (Artist artist in relatedArtists)
            {
                Task<List<Track>> topTracks = _artistService.GetArtistTopTracks(artist.Id, token);
                for (int i = 0; topTracks.Result.Count() <= 5 ? i < topTracks.Result.Count() : i < 5; i++)
                {
                    playlistTracks.Add(topTracks.Result.ElementAt(i));
                }
            }          
            Task<string> created  = _playListService.CreateRelatedArtistsPlaylist(artistId, relatedArtists, token);
            if(created.Result != null || created.Result.Length > 0)
            {
                Task<bool> populated = _playListService.PopulatePlaylist(created.Result, playlistTracks, token);
                if(populated.Result == true)
                {
                    return relatedArtists;
                }
            }
            return null;
        }

        [HttpGet]
        [Route("login")]
        public string GetRedirect(HttpRequestMessage request)
        {
            return _webAPIService.ConstructRedirect();
        }
    }
}