using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class Caption
    {
        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}