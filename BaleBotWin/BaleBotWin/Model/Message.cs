using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class Message
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string text { get; set; }
    }
}