using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class FileRequest<T>
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public T Body { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }
}