using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splatify.Core
{
    public class AppSettingKeys
    {
        public string Name { get; set; }
        public AppSettingKeys(string name)
        {
            this.Name = name;
        }
        public static readonly AppSettingKeys SpotifyWebAPIBaseURL = new AppSettingKeys("SpotifyWebAPIBaseURL");
        public static readonly AppSettingKeys SpotifyUserID = new AppSettingKeys("SpotifyUserID");
        public static readonly AppSettingKeys EncodedHeader = new AppSettingKeys("EncodedHeader");
        public static readonly AppSettingKeys SpotifyUserName = new AppSettingKeys("SpotifyUserName");
        public static readonly AppSettingKeys SpotifyClientID = new AppSettingKeys("SpotifyClientID");
        public static readonly AppSettingKeys SpotifyClientSecret = new AppSettingKeys("SpotifyClientSecret");
        public static readonly AppSettingKeys SpotifyRedirectURI = new AppSettingKeys("SpotifyRedirectURI");
    }
}