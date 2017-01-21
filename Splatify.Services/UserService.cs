using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splatify.Core;

namespace Splatify.Services
{
    public class UserService
    {
        private WebAPIService _apiService;

        public UserService()
        {
            _apiService = new WebAPIService();
        }

        public async Task<User> GetUser(string token)
        {
            string url = string.Format("https://api.spotify.com/v1/me");
            User user = await this._apiService.GetSpotifyType<User>(token, url);

            return user; //lol
        }
    }
}
