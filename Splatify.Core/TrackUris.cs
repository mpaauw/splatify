﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public class TrackUris
    {
        [JsonProperty("uris")]
        public string[] uris { get; set; }
    }
}
