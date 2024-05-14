﻿using MAUIMobileStarterKit.Models.API;
using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
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

        [Post("/get_messages.php")]
        Task<ChatConversionResponseModal[]> GetChatMessages(ChatConversionRequestModal chatConversionRequest);
    }
}
