using System;
using Controls.UserDialogs.Maui;
using Plugin.Fingerprint.Abstractions;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.RestApiService;
using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
using MAUIMobileStarterKit.Screens;
using static SQLite.SQLite3;

namespace MAUIMobileStarterKit.ViewModels
{
	public class LoginViewModels: BaseViewModel
    {
        private readonly ILoading loading;
        private readonly IFingerprint fingerprint;
        private readonly ILocalStorage localStorage;
        private IUserAuthonticator userAuthonticator;

        private string email;
        private string password;

        private ChatListPage chatListPage;

        public LoginViewModels(ILoading loading, IFingerprint fingerprint, ILocalStorage localStorage, ChatListPage chatListPage)
		{
            this.loading = loading;
            this.fingerprint = fingerprint;
            this.localStorage = localStorage;
            this.chatListPage = chatListPage;
            userAuthonticator = GetMyAppAuthonticatorEndpoint();
        }
        #region properties

        public string Password
        {
            get { return password; }
            set { password = value;
                NotifyPropertyChanged(Password);
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value;
                NotifyPropertyChanged(Email);
            }
        }

        #endregion
        public void StartLoading()
        {
            loading.StartIndicator();
        }

        public void EndLoading()
        {
            loading.EndIndiCator();
        }

        public async Task<bool> IsUserAlredyLogged()
        {
            var token = await localStorage.GetAsync("token");
            if (!string.IsNullOrEmpty(token))
            {
               return true;
            }
            return false;
        }
        public async Task<bool> CheckBioMetrixAuthontication()
        {
            var request = new AuthenticationRequestConfiguration("Validate that you have fingers", "Because without them you will not be able to access");
            var result = await fingerprint.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> CheckUserAuthonticator()
        {
            try
            {
                loading.StartIndicator();
                string loginID = DateTime.Now.ToString();
                var loginRequest = new LoginRequestModal()
                {
                    e = Email,
                    f = loginID,
                    p = Password
                };
                var results = await userAuthonticator.AuthonticateUser(loginRequest);
                if(results.t != null)
                {
                    localStorage.SetAsync("token",results.t);
                    localStorage.SetAsync("loggedUserID", results.i.ToString());
                    localStorage.SetAsync("fingerPrintLoggingId", loginID);
                    loading.EndIndiCator();
                    return true;
                }
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
            loading.EndIndiCator();
            return false;
        }
        public void NavigateToChatListPage()
        {
            PushAsyncPage(chatListPage);
        }
    }
}

