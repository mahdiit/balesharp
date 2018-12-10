using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class MoneyRequestType
    {
        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}