using System.Reflection;
using System.Timers;
using Font = Microsoft.Maui.Graphics.Font;
using IImage = Microsoft.Maui.Graphics.IImage;

#if ANDROID
using Android.Graphics;
#endif
#if IOS || ANDROID || MACCATALYST
using Microsoft.Maui.Graphics.Platform;
#endif
namespace MauiApp1;

public class ImgData
{
    public string Name { get; set; }
    public ImageSource EmbeddedImg { get; set; }
    public Image MAUIImg { get; set; }
}

public partial class NewPage1 : ContentPage
{
    public int Progress = 0;
    private System.Timers.Timer intervalTimer;

    public NewPage1()
	{
		InitializeComponent();
        intervalTimer = new System.Timers.Timer(200);
        intervalTimer.Elapsed += IntervalTimer_Elapsed;

        this.BindingContext = this;
    }

    private void IntervalTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (Progress >= 100)
        {
            Progress = 0;
        }
        else
        {
            Progress += 5;
        }
    }

    private async void BackPageBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        //await Navigation.PopToRootAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //await Navigation.PushModalAsync(new NavigationPage(new NewPage2()));
    }

    private  async void NextPageBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage2());

        await DisplayAlert("Needs permissions", "because!!!", "OK");
    }
}