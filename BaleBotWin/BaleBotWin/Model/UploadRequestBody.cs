using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class UploadRequestBody
    {
        [JsonProperty("crc")]
        public string Crc { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("isServer")]
        public bool IsServer { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }
    }
}