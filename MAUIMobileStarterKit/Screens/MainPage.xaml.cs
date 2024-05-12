using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class MainPage : ContentPage
{
	private readonly IUserDialogs userDialogs;
    private readonly LoginViewModels vm;

    public MainPage(LoginViewModels viewModel, IUserDialogs userDialogs)
	{
		InitializeComponent();
		this.userDialogs = userDialogs;
        this.vm = viewModel;
        BindingContext = viewModel;
        vm.Email = "pikachu.ac@yopmail.com";
        vm.Password = "pikachu";
        vm.navigation = Navigation;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    public async void UserAuthontication(System.Object sender, System.EventArgs e)
    {
        var result = await vm.CheckUserAuthonticator();
        if (!result)
        {
            await DisplayAlert("Login", "Please enter correct credentials", "Cancle");
        }
        else
        {
            vm.NavigateToChatListPage();
        }
    }
}
