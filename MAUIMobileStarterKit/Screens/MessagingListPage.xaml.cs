using MAUIMobileStarterKit.ViewModels;
using System.Collections.ObjectModel;

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
        LoadToLastElement();
    }

    private void LoadToLastElement()
    {
      var lastItem = vm.ChatConversionModalList[vm.ChatConversionModalList.Count() - 1];     
      listview.ScrollTo(lastItem, ScrollToPosition.End, false);
    }

    private void SendMsgBtnClicked(object sender, EventArgs e)
    {
        LoadToLastElement();
    }
}