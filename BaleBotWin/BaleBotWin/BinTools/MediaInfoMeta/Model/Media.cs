using System.Collections.Generic;
using Newtonsoft.Json;

namespace BaleBotWin.BinTools.MediaInfoMeta.Model
{
    public partial class Media
    {
        [JsonProperty("@ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty("track", NullValueHandling = NullValueHandling.Ignore)]
        public List<Track> Track { get; set; }
    }
}