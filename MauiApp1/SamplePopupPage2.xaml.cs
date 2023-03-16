using MauiPopup;
using MauiPopup.Views;

namespace MauiApp1;

public partial class SamplePopupPage2 : BasePopupPage
{
	public SamplePopupPage2()
	{
		InitializeComponent();
	}

    private async void CloseBtn_Clicked(object sender, EventArgs e)
    {
		await PopupAction.ClosePopup();
    }
}