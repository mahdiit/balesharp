using System;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class SendMessage
    {
        public static string GetMessage(string message, Peer peer)
        {
            var obj = new SendMessage()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = new Message() { type = "Text", text = message },
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        [JsonProperty("$type")]
        public string type { get; set; }
        public Body body { get; set; }
        public string service { get; set; }
        public string id { get; set; }
    }
}