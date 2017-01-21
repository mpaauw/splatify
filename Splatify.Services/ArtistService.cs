using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splatify.Core;
using System.Net;
using Newtonsoft.Json;

namespace Splatify.Services
{
    public class ArtistService
    {
        private WebAPIService _apiService;
        private SearchService _searchService;

        public ArtistService()
        {
            _apiService = new WebAPIService();
            _searchService = new SearchService();
        }

        public async Task<MultipleArtists> GetRelatedArtists(string input)
        {
            try
            {
                Task<Artist> artist = _searchService.SearchArtist(input);
                string url = string.Format("https://api.spotify.com/v1/artists/{0}/related-artists", artist.Result.Uri.Split(':')[2]);
                MultipleArtists relatedArtists = await this._apiService.GetSpotifyType<MultipleArtists>(_apiService.GetAccessToken(), url);
                return relatedArtists;
            }
            catch(Exception e)
            {
                return null;
            }
        } 

        public async Task<List<Track>> GetArtistTopTracks(string artistId, string token)
        {
            List<Track> trackList = new List<Track>();

            string url = string.Format("https://api.spotify.com/v1/artists/{0}/top-tracks", artistId);
            url += "?country=US";
            MultipleTracks topTracks = await this._apiService.GetSpotifyType<MultipleTracks>(token, url);
            trackList = topTracks.Tracks.ToList();

            return trackList;
        }
    }
}
