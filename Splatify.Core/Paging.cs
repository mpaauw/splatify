﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public class Paging<T>
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public T[] Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public bool HasNextPage()
        {
            return Next != null;
        }

        public bool HasPreviousPage()
        {
            return Next != null;
        }
    }
}
