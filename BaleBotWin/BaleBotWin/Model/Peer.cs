using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class Peer
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string accessHash { get; set; }
        public string id { get; set; }
    }
}
