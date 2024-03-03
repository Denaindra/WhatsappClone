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
}