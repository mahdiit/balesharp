using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class GeneralMessage
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
