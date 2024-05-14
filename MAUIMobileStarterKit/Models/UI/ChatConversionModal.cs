using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.UI
{
    public class ChatConversionModal
    {
        public long ChatId { get; set; }
        public long ChatUserId { get; set; }
        public long ChatThread { get; set; }
        public bool IsLogginUser {  get; set; }
        public string DateFormatted { get; set; }
        public string ChatMessage { get; set; }
        
    }
    public class ChatUser
    {
        public long UserId { get; set;}
        public string UserName { get; set; }
        public long ProfilePicId { get; set; }
    }

}
