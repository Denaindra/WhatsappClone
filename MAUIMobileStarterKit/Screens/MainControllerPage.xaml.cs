using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class MainControllerPage : ContentPage
{
	private ControllerViewModel controllerVM;
	public MainControllerPage(ControllerViewModel controllerViewModel)
	{
		InitializeComponent();
		this.controllerVM = controllerViewModel;
	    BindingContext = controllerViewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		controllerVM.LoadRecentChatList();
    }

    private async void SettingClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Foget Password", "setting 1", "setting 2");
    }
}