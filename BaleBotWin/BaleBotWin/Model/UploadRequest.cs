using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class UploadRequest
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public UploadRequestBody Body { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }
}