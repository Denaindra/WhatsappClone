using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.API.Response
{
    public class ChatConversionResponseModal
    {
        public int id { get; set; }
        public int idCT { get; set; }
        public int idCU { get; set; }
        public string msg { get; set; }
        public int deleted { get; set; }
        public string auto_timestamp { get; set; }
        public string last_update { get; set; }
        public string date_formatted { get; set; }
        public bool self { get; set; }
        public bool is_seen { get; set; }
    }
}
