using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class MessagingListPage : ContentPage
{
	public ChatMessagesViewModel vm;

    public MessagingListPage()
	{
		InitializeComponent();
		
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;
    }
}