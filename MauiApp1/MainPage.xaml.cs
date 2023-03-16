#if ANDROID
using Android.Service.Autofill;
#endif
using MauiApp1.Tabbedpage;
using MauiPopup;
using System.Runtime.InteropServices;

namespace MauiApp1;

public class PickerDataSampleClass
{
	public  string StrData { get; set; }
}

public partial class MainPage : ContentPage
{
	int count = 0;

	public List<PickerDataSampleClass> PickerData;

	private readonly ProgressArc _progressArc;
	private DateTime _startTime;
	private readonly int _duration = 5;
	private double _progress;
	private CancellationTokenSource _cancellationTokenSource = new();

	public MainPage()
	{
		InitializeComponent();

		//BackgroundImage.Source = ImageSource.FromResource("MauiApp1.Resources.Images.common.startup_background.png");
		//DecorationImage.Source = ImageSource.FromResource("MauiApp1.Resources.Images.common.startup_decoration.png");

		PickerData = new List<PickerDataSampleClass>()
		{
			new PickerDataSampleClass() 
			{
                StrData = "One",
            },
			new PickerDataSampleClass()
			{
				StrData = "Two",
			},
			new PickerDataSampleClass()
			{
				StrData = "Three",
			}
		};

		SamplePicker.ItemsSource= PickerData;
		SamplePicker.SelectedItem = SamplePicker.ItemsSource[0];
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private async void NextPageBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage1());
    }

    protected override void OnAppearing()
    {

        base.OnAppearing();
		/*
		Dispatcher.Dispatch(async() =>
		{
            await Navigation.PushModalAsync(new NavigationPage(new NewPage1()));
        });
		*/
    }

    private async void ShowPopupBtn_Clicked(object sender, EventArgs e)
    {
		await PopupAction.DisplayPopup(new TwoButtonPopupPageSample());
		Console.WriteLine("Popup Closed");
    }

    private void AppExitBtn_Clicked(object sender, EventArgs e)
    {
		//new AppExitService().Exit();
#if IOS
		exit(0);
#else
		Application.Current.Quit();
#endif

	}

    private async void ShowTabbedPageBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AppTabbedPage());
    }

    private void SamplePicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private async void CaroucelPageBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new RISTStepImgSamplePage());
    }

    private void ProgressButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ResetButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void SwitchContentSamplePageBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new SwitchContentSamplePage());
    }

#if IOS
     [DllImport("__Internal", EntryPoint = "exit")]
     public static extern void exit(int status);
#endif
}

