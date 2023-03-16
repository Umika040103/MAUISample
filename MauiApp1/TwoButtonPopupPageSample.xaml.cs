using MauiPopup;

namespace MauiApp1;

public partial class TwoButtonPopupPageSample : TwoButtonPopupPageTemplate
{
	public TwoButtonPopupPageSample()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void ShowPopupBtn_Clicked(object sender, EventArgs e)
    {
        await PopupAction.DisplayPopup(new SamplePopupPage2());
    }

    private async void ShowNexPageBtn_Clicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Navigation.PushAsync(new NewPage3("hogehoge"));
        });
       
    }
}