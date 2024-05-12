using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API.Response
{
    public class LoginResponseModal
    {
        [JsonProperty("t")]
        public string t { get; set; }

        [JsonProperty("i")]
        public long i { get; set; }
    }
}
