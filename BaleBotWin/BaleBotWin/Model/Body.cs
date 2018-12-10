using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class Body<T>
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public Sender sender { get; set; }
        public string date { get; set; }
        public string randomId { get; set; }
        public Peer peer { get; set; }
        public T message { get; set; }
        public object quotedMessage { get; set; }
    }
}