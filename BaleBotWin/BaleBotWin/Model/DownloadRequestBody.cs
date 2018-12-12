using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaleBotWin.Model
{
    public class DownloadRequestBody
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("isServer")]
        public bool IsServer { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty("fileVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileStorageVersion { get; set; }

        [JsonProperty("accessHash", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessHash { get; set; }

        [JsonProperty("isResumeUpload", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsResumeUpload { get; set; }
    }
}
