using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splatify.Core;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using System.Web.Script.Serialization;

namespace Splatify.Services
{
    public class PlaylistService
    {
        private WebAPIService _apiService;
        private UserService _userService;

        public PlaylistService()
        {
            _apiService = new WebAPIService();
            _userService = new UserService();
        }

        public async Task<Playlist> GetPlaylist(string token, string userID, string playlistID)
        {
            string url = string.Format("https://api.spotify.com/v1/users/{0}/playlists/{1}", userID, playlistID);
            Playlist playList = await this._apiService.GetSpotifyType<Playlist>(token, url);
            return playList;
        }

        //Return playlist Id:
        public async Task<string> CreateRelatedArtistsPlaylist(string artist, List<Artist> relatedArtists, string token)
        {
            Task<User> user = _userService.GetUser(token);

            NewPlaylist newPlayList = new NewPlaylist()
            {
                name = artist + ": Related Artists"
            };

            string serializedData = new JavaScriptSerializer().Serialize(newPlayList);

            string url = string.Format("https://api.spotify.com/v1/users/{0}/playlists", user.Result.Id);
            Playlist playlist = await this._apiService.PostSpotifyType<Playlist>(token, url, serializedData);

            return playlist.Id;
        }

        public async Task<bool> PopulatePlaylist(string playlistId, List<Track> playlistTracks, string token)
        {
            try
            {
                Task<User> user = _userService.GetUser(token);
                string url = string.Format("https://api.spotify.com/v1/users/{0}/playlists/{1}/tracks", user.Result.Id, playlistId);
                List<string> uris = new List<string>();
                foreach (Track track in playlistTracks)
                {
                    uris.Add(track.Uri);
                }
                TrackUris trackUris = new TrackUris();
                trackUris.uris = uris.ToArray();
                string serializedData = new JavaScriptSerializer().Serialize(trackUris);
                //string result = await this._apiService.PostSpotifyType<string>(token, url, serializedData);
                PlaylistResponse result = await this._apiService.PostSpotifyType<PlaylistResponse>(token, url, serializedData);

                return true;
            }
            catch(Exception e)
            {
                //Catch exception here...
                return false;
            }
        }
    }
}
