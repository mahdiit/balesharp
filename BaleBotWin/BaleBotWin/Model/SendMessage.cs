using System.IO;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class SendMessage<T>
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public Body<T> body { get; set; }
        public string service { get; set; }
        public string id { get; set; }
    }
}