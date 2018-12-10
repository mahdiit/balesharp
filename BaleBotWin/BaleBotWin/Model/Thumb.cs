using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class Thumb
    {
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbThumb { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }
    }
}