using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using RestSharp.Authenticators;
using Splatify.Core;
using Newtonsoft.Json;
using System.Configuration;

namespace Splatify.Services
{

    public class DataObject
    {
        public string Name { get; set; }
    }

    public class WebAPIService
    {
        //private const string URL = "https://sub.domain.com/objects.json";

        private const string IMPLICIT_GRANT_FLOW_REDIRECT = "https://accounts.spotify.com/authorize";
        private string _encodedHeader;
        private string _clientId;
        private string _redirectURI;
        private string[] _authenticationScopes;

        public WebAPIService()
        {
            _encodedHeader = ConfigurationManager.AppSettings[AppSettingKeys.EncodedHeader.Name].ToString();
            _clientId = ConfigurationManager.AppSettings[AppSettingKeys.SpotifyClientID.Name].ToString();
            _redirectURI = ConfigurationManager.AppSettings[AppSettingKeys.SpotifyRedirectURI.Name].ToString();
            _authenticationScopes = new string[] { "playlist-modify-public" };
        }

        public string GetAccessToken()
        {
            try
            {
                SpotifyToken token = new SpotifyToken();
                string postString = string.Format("grant_type=client_credentials");
                byte[] byteArray = Encoding.UTF8.GetBytes(postString);

                string url = "https://accounts.spotify.com/api/token";

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("Authorization", "Basic " + _encodedHeader);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                string responseFromServer = reader.ReadToEnd();
                                token = JsonConvert.DeserializeObject<SpotifyToken>(responseFromServer);
                            }
                        }
                    }
                }
                return token.access_token;
            }
            catch(Exception e)
            {
                return null;
            }        
        }

        public async Task<T> GetSpotifyType<T>(string token, string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json; charset=utf-8";

                T type = default(T);

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);
                        
                        }
                    }
                }
                return type;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> PostSpotifyType<T>(string token, string url, string rawData)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json; charset=utf-8";

                byte[] encodedData = new ASCIIEncoding().GetBytes(rawData);
                Stream inputDataStream = request.GetRequestStream();
                inputDataStream.Write(encodedData, 0, encodedData.Length);
                inputDataStream.Close();

                T type = default(T);

                using (WebResponse response = request.GetResponse())
                {
                    /////
                    var test = response.ResponseUri;

                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);

                        }
                    }
                }
                return type;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string ConstructRedirect()
        {
            string modifiedRedirectURI = _redirectURI.Replace("/", "%2F");
            string redirectString = IMPLICIT_GRANT_FLOW_REDIRECT + "?client_id=" + _clientId + "&redirect_uri=" + modifiedRedirectURI + "&response_type=token";
            if(_authenticationScopes.Length > 0)
            {
                redirectString += "&scope=";
                foreach(string scope in _authenticationScopes)
                {
                    redirectString += scope;
                    redirectString += " ";
                }
            } 

            return redirectString;
        }
    }
}
