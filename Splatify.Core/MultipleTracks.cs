using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public class MultipleTracks
    {
        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }
    }
}
