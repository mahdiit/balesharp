using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public partial class SendMeMoney
    {
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Amount { get; set; }

        [JsonProperty("accountNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        public SendPhoto Msg { get; set; }

        [JsonProperty("$type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("moneyRequestType", NullValueHandling = NullValueHandling.Ignore)]
        public MoneyRequestType MoneyRequestType { get; set; }

        [JsonProperty("regexAmount", NullValueHandling = NullValueHandling.Ignore)]
        public string RegexAmount { get; set; }
    }
}
