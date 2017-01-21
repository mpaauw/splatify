using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splatify.Core;
using Splatify.Services;
using System.Configuration;

namespace Splatify.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //...
                WebAPIService _service = new WebAPIService();
                PlaylistService _playlistService = new PlaylistService();
                string _userID = ConfigurationManager.AppSettings[AppSettingKeys.SpotifyUserName.Name].ToString();

                string token = _service.GetAccessToken();
                string test_playlist = "3LeWNYvsiCCZS0vpEKmeLr";
                Task<Playlist> playlists = _playlistService.GetPlaylist(token, _userID, test_playlist);

                //_service.TestRestSharp();
            }
            catch (Exception e)
            {
                //Catch exception here...
            }


        }
    }
}
