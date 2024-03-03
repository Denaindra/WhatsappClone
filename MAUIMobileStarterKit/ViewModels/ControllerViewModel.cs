using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.RestApiService;
using MAUIMobileStarterKit.Models.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class ControllerViewModel:BaseViewModel
    {
        private ILoading loading; 
        private ObservableCollection<RecentChatListModal> recentChatList;
        private readonly IChatResults activityReportsServiceUrl;

        public ControllerViewModel(ILoading loading)
        {
            this.loading = loading;
            activityReportsServiceUrl = RecentChatServiceEndPoint();
        }
        public ObservableCollection<RecentChatListModal> RecentChatList
        {
            get {
                return recentChatList; 
            }
            set { 
                recentChatList = value;
                NotifyPropertyChanged(nameof(RecentChatList));
            }
        }

        public async void LoadRecentChatList()
        {
            loading.StartIndicator();
            try
            {
                var results = await activityReportsServiceUrl.GetUserRecentChat();
                if (results.Any())
                {
                    foreach (var result in results)
                    {
                        RecentChatList = new ObservableCollection<RecentChatListModal>();
                        RecentChatList.Add(new RecentChatListModal
                        {
                            Id = result.Id,
                            IsSeenLastChat = result.IsSeenLastChat,
                            LastChatMessage = result.LastChatMessage,
                            Profilepic = result.Profilepic
                        });
                    }
                }
            }
            catch (Exception ex)
            {

            }finally
            {
                loading.EndIndiCator();
            }
        }
    }
}
