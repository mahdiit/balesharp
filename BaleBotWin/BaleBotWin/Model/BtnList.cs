using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class BtnList
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public long? Action { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}