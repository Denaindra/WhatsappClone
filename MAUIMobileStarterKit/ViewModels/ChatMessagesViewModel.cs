using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.RestApiService;
using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
using MAUIMobileStarterKit.Models.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class ChatMessagesViewModel:BaseViewModel
    {
        private readonly IThreadResults threadResults;
        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;

        private ObservableCollection<MessageThreadModal> messageThreadModalList;

        public ObservableCollection<MessageThreadModal> MessageThreadModalList
        {
            get { return messageThreadModalList; }
            set { messageThreadModalList = value;
                NotifyPropertyChanged(nameof(MessageThreadModalList));
            }
        }

        public ChatMessagesViewModel(ILoading loading, ILocalStorage localStorage)
        {
            threadResults = GetAllThareadInfos();
            this.localStorage = localStorage;
            this.loading = loading;
        }

        public async void LoadindChatThreads()
        {
            try
            {
                loading.StartIndicator();
                var threadRequest = new ThreadInfoRequestModel()
                {
                    t = await localStorage.GetAsync("token"),
                    i = Int32.Parse(await localStorage.GetAsync("loggedUserID")),
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                };
                ThreadInfoResponseModel[] threadInfoResponse =  await  threadResults.GetThreadInfo(threadRequest);
                if (threadInfoResponse.Any())
                {
                    MessageThreadModalList = new ObservableCollection<MessageThreadModal>();
                   foreach (var threadItem in threadInfoResponse)
                    {
                        var threadInfoRequest = new GetOneThreadRequestMopdal()
                        {
                            t = await localStorage.GetAsync("token"),
                            idT = threadItem.idT,
                            idCU = threadItem.idCU,
                            f = await localStorage.GetAsync("fingerPrintLoggingId"),
                        };

                        GetOneThreadResponseModal currectThreadResponse = await threadResults.GetOneThread(threadInfoRequest);
                        var messageThread = new MessageThreadModal()
                        {
                            ThreadID = threadItem.idT,
                            ChatUserId = threadItem.idCU,
                            OtherUserId = threadItem.idOU,
                            ProfilePicId = currectThreadResponse.idP,
                            ThreadNote = currectThreadResponse.note,
                            ThreadName = currectThreadResponse.name,
                            ThreadTitle = currectThreadResponse.title,
                            IsGroupChat = currectThreadResponse.duo == 0 ? true : false,
                            LastUpdate = DateTime.Parse(currectThreadResponse.last_update).ToString("MM/dd/yyyy hh:mm tt")
                        };
                        MessageThreadModalList.Add(messageThread);
                    }
                }
                loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
            }
        }
    }
}
