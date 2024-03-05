using MAUIMobileStarterKit.Interface.RestApiService;
using Refit;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIMobileStarterKit.ViewModels
{
	public class BaseViewModel: INotifyPropertyChanged
    {
        public INavigation navigation;
        public event PropertyChangedEventHandler PropertyChanged;

        private static IChatResults activityReportsServiceUrl;
        public const string BASEDURL = "https://mychat.free.beeceptor.com/";


        public BaseViewModel()
		{
		}

        public IChatResults RecentChatServiceEndPoint()
        {
            if (activityReportsServiceUrl is null)
            {
                activityReportsServiceUrl = RestService.For<IChatResults>(BASEDURL);
            }
            return activityReportsServiceUrl;
        }

        public async void PushModalAsync(Page page)
        {
            await navigation.PushModalAsync(page);
        }

        public async void PushAsyncPage(Page page)
        {
            await navigation.PushAsync(page);
        }
        public async void PopAsyncy()
        {
            await navigation.PopAsync();
        }
        public async void PopModalAsyncy()
        {
            await navigation.PopModalAsync();
        }
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

