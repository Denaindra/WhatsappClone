using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API.Response
{
    public class ChatMessageResponse
    {
        [JsonProperty("status")]
        public bool status { get; set; }
    }
}
