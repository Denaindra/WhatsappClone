using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.UI
{
    public class MessageThreadModal
    {
        public long ThreadID { get; set; }
        public long ChatUserId { get; set; }
        public long[] OtherUserId { get; set; }
        public long ProfilePicId { get; set; }
        public string ThreadNote { get; set; }
        public string ThreadName { get; set; }
        public string ThreadTitle { get; set; }
        public string LastUpdate { get; set; }
        public bool IsGroupChat { get; set; }
    }
}
