using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class SendSticker
    {
        [JsonProperty("fastPreview")]
        public object FastPreview { get; set; }

        [JsonProperty("image256", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image256 { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("stickerId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? StickerId { get; set; }

        [JsonProperty("image512", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image512 { get; set; }

        [JsonProperty("stickerCollectionId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? StickerCollectionId { get; set; }

        [JsonProperty("stickerCollectionAccessHash", NullValueHandling = NullValueHandling.Ignore)]
        public string StickerCollectionAccessHash { get; set; }
    }
}
