using MauiApp1.Tabbedpage;

namespace MauiApp1;

public partial class App : Application
{
    public double ScreenWidth { get; private set; }
    public double ScreenHeight { get; private set; }

    public App()
	{
        InitializeComponent();

        var displaysize = DeviceDisplay.MainDisplayInfo;
        ScreenWidth = displaysize.Width;
        ScreenHeight = displaysize.Height;

        //MainPage = new NavigationPage(new MainPage());
        MainPage = new NavigationPage(new CountdownDisplayPage());
    }

    protected override void OnResume()
    {
        base.OnResume();
        Console.WriteLine("App.xaml.cs OnResume");
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        Console.WriteLine("App.xaml.cs OnSleep");
    }
}
