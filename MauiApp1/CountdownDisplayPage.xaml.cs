

using MauiPopup;

namespace MauiApp1;

public partial class CountdownDisplayPage : ContentPage
{
    public enum ETRANSITION_TYPE
    {
        eNavigationPage, ePopupPage
    }

    private readonly int countdownMax = 10;
    private int countdown = 0;
    public int Countdown
    {
        get
        { return countdown; }
        set
        {
            countdown = value;
            OnPropertyChanged(nameof(Countdown));
        }
    } 

    private System.Timers.Timer timer;

    private ETRANSITION_TYPE transitionType = ETRANSITION_TYPE.eNavigationPage;
    public CountdownDisplayPage()
	{
		InitializeComponent();
        this.BindingContext = this;

        timer = new System.Timers.Timer(1000);
        timer.Elapsed += Timer_Elapsed;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Console.WriteLine("CountdonwPage: OnAppearing");
    }

    private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Countdown--;
        Console.WriteLine("CountDown:" + Countdown);
        if(Countdown <= 0)
        {
            timer.Stop();
            MainThread.BeginInvokeOnMainThread(async() =>
            {
                switch (transitionType)
                {
                    case ETRANSITION_TYPE.eNavigationPage:
                        Console.WriteLine("DisplayNavigationPage");
                        try
                        {
                            await Navigation.PushAsync(new NewPage3("NewPage3"));
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        break;
                    case ETRANSITION_TYPE.ePopupPage:
                        Console.WriteLine("DIsplay PopupPage");
                        await PopupAction.DisplayPopup(new TwoButtonPopupPageSample());
                        break;
                    default:
                        break;
                }
            });

        }
    }


    private void DisplayNextPageBtn_Clicked(object sender, EventArgs e)
    {
        Countdown = countdownMax;
        transitionType = ETRANSITION_TYPE.eNavigationPage;
        timer.Start();

    }

    private void DisplayPopupPageBtn_Clicked(object sender, EventArgs e)
    {
        Countdown = countdownMax;
        transitionType = ETRANSITION_TYPE.ePopupPage;
        timer.Start();
    }
}