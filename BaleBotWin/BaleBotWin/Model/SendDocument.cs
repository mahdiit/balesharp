using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class SendDocument
    {
        [JsonProperty("ext")]
        public object Ext { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public Caption Caption { get; set; }

        [JsonProperty("accessHash", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? AccessHash { get; set; }

        [JsonProperty("fileSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FileSize { get; set; }

        [JsonProperty("checkSum", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckSum { get; set; }

        [JsonProperty("thumb")]
        public object Thumb { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("fileStorageVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileStorageVersion { get; set; }

        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty("mimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string MimeType { get; set; }

        [JsonProperty("algorithm", NullValueHandling = NullValueHandling.Ignore)]
        public string Algorithm { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}