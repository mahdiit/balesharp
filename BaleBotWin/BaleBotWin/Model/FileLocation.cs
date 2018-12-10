using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class FileLocation
    {
        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty("fileStorageVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileStorageVersion { get; set; }

        [JsonProperty("accessHash", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessHash { get; set; }
    }
}