namespace MauiApp1;

public partial class NewPage3 : ContentPage
{
	public string DisplayLabel { get; set; }

	public NewPage3(string DisplayLabel)
	{
		InitializeComponent();
		this.DisplayLabel = DisplayLabel;

		this.BindingContext = this;
	}
}