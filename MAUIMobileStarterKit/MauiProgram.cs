using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Utilities;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Extensions.Logging;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace MAUIMobileStarterKit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseUserDialogs(true, () =>
            {
#if ANDROID
                var fontFamily = "OpenSans-Regular.ttf";
#else
                var fontFamily = "OpenSans-Regular";
#endif
                AlertConfig.DefaultMessageFontFamily = fontFamily;
                AlertConfig.DefaultUserInterfaceStyle = UserInterfaceStyle.Dark;
                AlertConfig.DefaultPositiveButtonTextColor = Colors.Purple;
                ConfirmConfig.DefaultMessageFontFamily = fontFamily;
                ActionSheetConfig.DefaultMessageFontFamily = fontFamily;
                ToastConfig.DefaultMessageFontFamily = fontFamily;
                SnackbarConfig.DefaultMessageFontFamily = fontFamily;
                HudDialogConfig.DefaultMessageFontFamily = fontFamily;
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Views
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainControllerPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<ChatListPage>();

        //ViewModels
        builder.Services.AddTransient<LoginViewModels>();
        builder.Services.AddTransient<ControllerViewModel>();
        builder.Services.AddTransient<ChatMessagesViewModel>();

        //Services
        builder.Services.AddSingleton<ILoading, Loading>();
        builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
        builder.Services.AddSingleton<TodoItemDatabase>();
        builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);




#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

