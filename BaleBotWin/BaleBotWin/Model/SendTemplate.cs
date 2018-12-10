using System.Collections.Generic;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class SendTemplate
    {
        [JsonProperty("templateMessageId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TemplateMessageId { get; set; }

        [JsonProperty("generalMessage", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralMessage GeneralMessage { get; set; }

        [JsonProperty("btnList", NullValueHandling = NullValueHandling.Ignore)]
        public List<BtnList> BtnList { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}