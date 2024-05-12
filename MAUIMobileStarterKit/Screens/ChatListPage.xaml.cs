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
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.LoadindChatThreads();
    }
}