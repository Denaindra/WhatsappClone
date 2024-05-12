using MAUIMobileStarterKit.CustomViews.Controls;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
namespace MAUIMobileStarterKit;

public partial class App : Application
{
    public App(MainPage mainPage, ILocalStorage localStorage)
    {
        InitializeComponent();
        //var navigationBarColour = new NavigationPage(mainPage);
      //  navigationBarColour.BarBackgroundColor = Color.FromArgb("#128c7e");
        MainPage = new NavigationPage(mainPage);
        InititateAllCutomUICmsponets();
    }

    private void InititateAllCutomUICmsponets()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
#if __ANDROID__
            if (view is NoUnderlineEntry)
            {
                handler.PlatformView.Background = null;
            }
#endif

#if IOS
                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }
}

