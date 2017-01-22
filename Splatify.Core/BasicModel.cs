using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        public bool HasError()
        {
            return Error != null;
        }
    }
}