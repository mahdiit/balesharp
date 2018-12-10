using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class Image
    {
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("fileLocation", NullValueHandling = NullValueHandling.Ignore)]
        public FileLocation FileLocation { get; set; }

        [JsonProperty("fileSize", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileSize { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }
    }
}