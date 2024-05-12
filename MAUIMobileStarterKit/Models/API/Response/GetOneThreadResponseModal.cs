using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API.Response
{
    public class GetOneThreadResponseModal
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("idP")]
        public long idP { get; set; }

        [JsonProperty("duo")]
        public long duo { get; set; }

        [JsonProperty("note")]
        public string note { get; set; }

        [JsonProperty("last_update")]
        public string last_update { get; set; }
    }
}
