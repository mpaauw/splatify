using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Splatify.Core
{
    public class PlaylistResponse
    {
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }
    }
}
