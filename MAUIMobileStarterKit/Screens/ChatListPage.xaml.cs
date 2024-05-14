using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class ChatListPage : ContentPage
{
    private ChatMessagesViewModel vm;
    public ChatListPage(ChatMessagesViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        vm.navigation = Navigation;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.DownloadOntimeChatList();
    }

    private void ChatListRefreshing(object sender, EventArgs e)
    {
        vm.LoadindChatThreads(false);
        listView.IsRefreshing = false;

    }

    private async void ChatThreadItemTapped(object sender, ItemTappedEventArgs e)
    {
        var isChatsLoaded = await vm.SelectedChat(e.Item);
       if (isChatsLoaded)
        {
            vm.NavigateToChatsListPage();
        }
    }
}