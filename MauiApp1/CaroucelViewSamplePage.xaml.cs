using System.Collections.ObjectModel;
namespace MauiApp1;

public class MonkeyTest
{
	public string Name { get; set;}

	public ImageSource ImgData { get; set;}	
}

public partial class CaroucelViewSamplePage : ContentPage
{
    public ObservableCollection<MonkeyTest> MonkeyDatas { get; private set; }

    public CaroucelViewSamplePage()
	{
		InitializeComponent();
		CreateData();

		this.BindingContext= this;
	}

	private void CreateData()
	{
		MonkeyDatas = new ObservableCollection<MonkeyTest>()
		{
            new MonkeyTest()
            {
                Name= "testes",
                ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.eng.SetupSteps_RISTOpeMode.s1_img.png")
            },
            new MonkeyTest()
			{
				Name= "Baboon",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.200px-Papio_anubis.jpg")
			},
			new MonkeyTest()
			{
				Name ="Capuchin Monkey",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.Capuchin_Costa_Rica.jpg")
			},
			new MonkeyTest()
			{
				Name = "Blue Monkey",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.220px-BlueMonkey.jpg")
			},
			new MonkeyTest()
			{
				Name = "Squirrel Monkey",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.Saimiri_sciureus-1_Luc_Viatour.jpg")
			},
			new MonkeyTest()
			{
				Name = "Golden Lion Tamarin",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.Golden_lion_tamarin_portrait3.jpg")
			},
			new MonkeyTest()
			{
				Name = "Howler Monkey",
				ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.200px-Alouatta_guariba.jpg")
			}
		};	
	}

    private void CarouselView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        Console.WriteLine("Scrolled ");
    }

    private void SampleCarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        
    }

    private void SampleCarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
    {
		var currentItemPosition = e.CurrentPosition;
		var previousItemPosition = e.PreviousPosition;
        Console.WriteLine("PositionChanged :");
		Console.WriteLine("		currentItemPos :" + currentItemPosition);
		Console.WriteLine("		preItemPos :" + previousItemPosition);

		if (currentItemPosition >= MonkeyDatas.Count - 1 )
		{
			SampleCarouselView.Position = MonkeyDatas.Count - 1;
        }
    }

}