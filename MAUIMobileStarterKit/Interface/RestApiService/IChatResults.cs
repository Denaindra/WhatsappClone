using MAUIMobileStarterKit.Models.API;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.RestApiService
{
    public interface IChatResults
    {
        [Get("/getUserChats")]
        Task<RecentChatListModal[]> GetUserRecentChat();
    }
}
