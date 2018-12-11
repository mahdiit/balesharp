using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.BinTools.MediaInfoMeta.Model
{
    public partial class AudioMediaInfo
    {
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public Media Media { get; set; }
    }
}
