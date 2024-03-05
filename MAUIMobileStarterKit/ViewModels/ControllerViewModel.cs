using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.RestApiService;
using MAUIMobileStarterKit.Models.UI;
using MAUIMobileStarterKit.Screens;
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

        private readonly ForgotPasswordPage forgotPasswordPage;

        public ControllerViewModel(ILoading loading, ForgotPasswordPage forgotPasswordPage)
        {
            this.loading = loading;
            activityReportsServiceUrl = RecentChatServiceEndPoint();
            this.forgotPasswordPage = forgotPasswordPage;
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
                    RecentChatList = new ObservableCollection<RecentChatListModal>();
                    foreach (var result in results)
                    {
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

        public void AlertSheetActions(string action)
        {
            switch(action)
            {
                case "Foget Password":
                    PushAsyncPage(forgotPasswordPage);
                    break;

                case "test12":
                    break;

                case "test234":
                    break;
            }
        }
    }
}
