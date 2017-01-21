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
    public class SearchService
    {
        private string _searchBaseUrl;
        private WebAPIService _apiService;

        public SearchService()
        {
            _searchBaseUrl = "https://api.spotify.com/v1/search";
            _apiService = new WebAPIService();
        }

        public async Task<Artist> SearchArtist(string artist)
        {
            string url = BuildSearch("artist", artist);
            SearchMultipleArtists results = await this._apiService.GetSpotifyType<SearchMultipleArtists>(_apiService.GetAccessToken(), url);
            return results.Artists.Items[0];
        }

        //Possible types: album, artist, playlist, or track.
        public string BuildSearch(string type, string parameter)
        {
            string query = string.Format(_searchBaseUrl + "?q=");
            string convertedParam = parameter.Replace(' ', '+');
            query += "\"" + convertedParam + "\"" + "&type=" + type;
            return query;           
        }
    }
}
