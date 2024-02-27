﻿using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Utilities;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Extensions.Logging;

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
                var fontFamily = "OpenSans-Default.ttf";
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

        //ViewModels
        builder.Services.AddTransient<MainPageViewModels>();

        //Services
        builder.Services.AddSingleton<ILoading, Loading>();
        builder.Services.AddSingleton<TodoItemDatabase>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

