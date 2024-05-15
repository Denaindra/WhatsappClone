using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.RestApiService;
using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
using MAUIMobileStarterKit.Models.UI;
using MAUIMobileStarterKit.Screens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class ChatMessagesViewModel : BaseViewModel
    {
        private string newMessage;

        private readonly IThreadResults threadResults;
        private readonly IChatResults chatResults;
        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;

        private MessagingListPage MessagingListPage;
        private ForgotPasswordPage forgotPasswordPage;

        private ObservableCollection<MessageThreadModal> messageThreadModalList;
        public ObservableCollection<ChatConversionModal> chatConversionModalList;

        public ChatMessagesViewModel(ILoading loading, ILocalStorage localStorage, MessagingListPage messagingListPage, ForgotPasswordPage forgotPasswordPage)
        {
            threadResults = GetAllThareadInfos();
            chatResults = GetChatConversionResults();
            this.localStorage = localStorage;
            this.loading = loading;
            this.MessagingListPage = messagingListPage;
            this.forgotPasswordPage = forgotPasswordPage;
        }

        public ObservableCollection<MessageThreadModal> MessageThreadModalList
        {
            get { return messageThreadModalList; }
            set
            {
                messageThreadModalList = value;
                NotifyPropertyChanged(nameof(MessageThreadModalList));
            }
        }

        public ObservableCollection<ChatConversionModal> ChatConversionModalList
        {
            get
            {
                return chatConversionModalList;
            }
            set
            {
                chatConversionModalList = value;
                NotifyPropertyChanged(nameof(ChatConversionModalList));
            }
        }

        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                newMessage = value;
                NotifyPropertyChanged(nameof(NewMessage));
            }
        }

        public void DownloadOntimeChatList()
        {
            if (!Constant.IsChatListDownloaded)
            {
                LoadindChatThreads(true);
            }
        }
        public async void LoadindChatThreads(bool customRefresh)
        {
            try
            {
                if (customRefresh)
                {
                    loading.StartIndicator();
                }
                var threadRequest = new ThreadInfoRequestModel()
                {
                    t = await localStorage.GetAsync("token"),
                    i = Int32.Parse(await localStorage.GetAsync("loggedUserID")),
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                };
                ThreadInfoResponseModel[] threadInfoResponse = await threadResults.GetThreadInfo(threadRequest);
                if (threadInfoResponse.Any())
                {
                    MessageThreadModalList = new ObservableCollection<MessageThreadModal>();
                    foreach (var threadItem in threadInfoResponse)
                    {
                        var threadInfoRequest = new GetOneThreadRequestModal()
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
                    Constant.IsChatListDownloaded = true;
                }
                if (customRefresh)
                {
                    loading.EndIndiCator();
                }
            }
            catch (Exception ex)
            {
                if (customRefresh)
                {
                    loading.EndIndiCator();
                }
            }
        }
        public async Task<bool> LoadSelectedChatList(object item)
        {
            try
            {
                loading.StartIndicator();
                var selectedThread = (MessageThreadModal)item;
                localStorage.SetAsync("thredID", selectedThread.ThreadID.ToString());
                localStorage.SetAsync("chatUserId", selectedThread.ChatUserId.ToString());

                var threadRequest = new ChatConversionRequestModal()
                {
                    t = await localStorage.GetAsync("token"),
                    idCU = selectedThread.ChatUserId,
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                    idT = selectedThread.ThreadID,
                    fU = true,
                };

                var chatCoversionResults = await chatResults.GetChatMessages(threadRequest);
                if (chatCoversionResults.Any())
                {
                    ChatConversionModalList = new ObservableCollection<ChatConversionModal>();
                    foreach (var chat in chatCoversionResults)
                    {
                        ChatConversionModalList.Add(new ChatConversionModal()
                        {
                            ChatId = chat.id,
                            ChatUserId = chat.idCU,
                            ChatMessage = chat.msg,
                            ChatThread = selectedThread.ThreadID,
                            IsLogginUser = chat.idCU == selectedThread.ChatUserId ? true : false,
                            DateFormatted = chat.date_formatted
                        });
                    }
                }
                loading.EndIndiCator();
                return true;
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
        }
        public void NavigateToChatsListPage()
        {
            MessagingListPage.vm = this;
            PushAsyncPage(MessagingListPage);
        }
        public async Task<bool> SendMessage()
        {
            try
            {
                var chatMessage = new ChatMessageRequest()
                {
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                    idCU = long.Parse(await localStorage.GetAsync("chatUserId")),
                    idT = long.Parse(await localStorage.GetAsync("thredID")),
                    m = NewMessage,
                    t = await localStorage.GetAsync("token"),
                };
                var chatCoversionResults = await chatResults.SentChatMessage(chatMessage);
                if (chatCoversionResults.status)
                {
                    return true;
                }
                return false;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public async Task<bool> UpdateTheChatsList()
        {
            try
            {
                var testmodal = new GetLastUpdateChatsModleResquest()
                {
                    t = await localStorage.GetAsync("token"),
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                    idT = long.Parse(await localStorage.GetAsync("thredID"))
                };
                var getsLastupdateChats = await chatResults.GetLastUpdateChats(testmodal);
                var dateTime = DateTime.ParseExact(getsLastupdateChats.lU, "yyyy-MM-dd HH:mm:ss", null);
                DateTime newDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
                string newDateTimeString = newDateTime.ToString("yyyy-MM-dd HH:mm:ss");


                var threadRequest = new ChatConversionRequestModal()
                {
                    t = await localStorage.GetAsync("token"),
                    idCU = long.Parse(await localStorage.GetAsync("chatUserId")),
                    f = await localStorage.GetAsync("fingerPrintLoggingId"),
                    idT = long.Parse(await localStorage.GetAsync("thredID")),
                    fU = false,
                    lU = newDateTimeString
                };

                var getLatestsUpdatedChats = await chatResults.GetChatMessages(threadRequest);

                if (getLatestsUpdatedChats != null)
                {
                    foreach (var chat in getLatestsUpdatedChats)
                    {
                        var isExsiting = ChatConversionModalList.Any(chatId => chatId.ChatId == chat.id);
                        if (!isExsiting)
                        {
                            ChatConversionModalList.Add(new ChatConversionModal()
                            {
                                ChatId = chat.id,
                                ChatUserId = chat.idCU,
                                ChatMessage = chat.msg,
                                ChatThread = long.Parse(await localStorage.GetAsync("thredID")),
                                IsLogginUser = chat.idCU == long.Parse(await localStorage.GetAsync("chatUserId")) ? true : false,
                                DateFormatted = chat.date_formatted
                            });
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AlertSheetActions(string action)
        {
            switch (action)
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
