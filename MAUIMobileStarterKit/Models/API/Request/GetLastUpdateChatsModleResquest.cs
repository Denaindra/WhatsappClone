using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API.Request
{
    public class GetLastUpdateChatsModleResquest
    {
        [JsonProperty("t")]
        public string t { get; set; }

        [JsonProperty("f")]
        public string f { get; set; }

        [JsonProperty("idT")]
        public long idT { get; set; }
    }

    public class GetLastUpdatredChatsResponse
    {
        [JsonProperty("lU")]
        public string lU { get; set; }
    }
}
