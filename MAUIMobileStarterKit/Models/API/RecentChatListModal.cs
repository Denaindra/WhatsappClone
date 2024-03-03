using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API
{
    public class RecentChatListModal
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lastChatMessage")]
        public string LastChatMessage { get; set; }

        [JsonProperty("IsSeenLastChat")]
        public bool IsSeenLastChat { get; set; }

        [JsonProperty("profilepic")]
        public Uri Profilepic { get; set; }
    }
}
