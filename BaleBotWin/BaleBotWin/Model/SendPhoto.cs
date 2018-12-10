using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class SendPhoto
    {
        [JsonProperty("checkSum", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckSum { get; set; }

        [JsonProperty("mimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string MimeType { get; set; }

        [JsonProperty("fileSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FileSize { get; set; }

        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty("algorithm", NullValueHandling = NullValueHandling.Ignore)]
        public string Algorithm { get; set; }

        [JsonProperty("fileStorageVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileStorageVersion { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("accessHash", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? AccessHash { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public Caption Caption { get; set; }

        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public Thumb Thumb { get; set; }

        [JsonProperty("ext", NullValueHandling = NullValueHandling.Ignore)]
        public Ext Ext { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}