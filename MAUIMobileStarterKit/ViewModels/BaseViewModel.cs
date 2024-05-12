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

        private static IThreadResults threadResults;
        private static IUserAuthonticator userAuthonticatorServiceUrl;

        public const string BASEDURL = "https://www.archivecontrol.com/dev/api";
  

        public BaseViewModel()
		{
		}

        public IThreadResults GetAllThareadInfos()
        {
            if (threadResults is null)
            {
                threadResults = RestService.For<IThreadResults>(BASEDURL);
            }
            return threadResults;
        }

        public IUserAuthonticator GetMyAppAuthonticatorEndpoint()
        {
            if (userAuthonticatorServiceUrl is null)
            {
                userAuthonticatorServiceUrl = RestService.For<IUserAuthonticator>(Constant.MYAPPBASEDURL);
            }
            return userAuthonticatorServiceUrl;
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

