using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class MainPage : ContentPage
{
    private readonly LoginViewModels vm;

    public MainPage(LoginViewModels viewModel)
	{
		InitializeComponent();
        this.vm = viewModel;
        BindingContext = viewModel;
        vm.Email = "pikachu.ac@yopmail.com";
        vm.Password = "pikachu";
        vm.navigation = Navigation;
    }

    protected override async void OnAppearing()
    {
        var results = await vm.IsUserAlredyLogged();
        if (results)
        {
            vm.NavigateToChatListPage();
        }
        else
        {
            mainlayout.IsVisible = true;
        }

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
