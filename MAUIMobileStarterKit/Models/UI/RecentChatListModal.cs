using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.UI
{
    public class RecentChatListModal
    {
        public long Id { get; set; }
        public string LastChatMessage { get; set; }
        public bool IsSeenLastChat { get; set; }
        public Uri Profilepic { get; set; }
    }
}
