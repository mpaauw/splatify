using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public class SearchMultipleArtists
    {
        [JsonProperty("artists")]
        public SMAObject Artists { get; set; }
    }

    public class SMAObject
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        
        [JsonProperty("items")]
        public Artist[] Items { get; set; }
    }
}
