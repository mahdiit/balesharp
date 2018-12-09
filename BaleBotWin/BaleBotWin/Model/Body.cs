using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class Body
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public Sender sender { get; set; }
        public string date { get; set; }
        public string randomId { get; set; }
        public Peer peer { get; set; }
        public Message message { get; set; }
        public object quotedMessage { get; set; }
    }
}