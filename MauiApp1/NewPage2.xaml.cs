namespace MauiApp1;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    private async void BackPageBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void BackHomeBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}