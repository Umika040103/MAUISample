using System.Collections.ObjectModel;

namespace MauiApp1;


public class StepImgDataClass
{
    public string Name { get; set; }

    public ImageSource ImgData { get; set; }
    public string ImagePath { get; set; }
    public ImageSource ImgSrc { get { return ImageSource.FromResource(ImagePath); } }
}
public partial class RISTStepImgSamplePage : ContentPage
{
    public ObservableCollection<StepImgDataClass> SampleStepImageDatas { get; private set; }

    public RISTStepImgSamplePage()
	{
		InitializeComponent();

        SampleStepImageDatas = new ObservableCollection<StepImgDataClass>()
            {
                new StepImgDataClass()
                {
                    Name = "Step1",
                    ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.eng.SetupSteps_RISTOpeMode.s1_img.png"),
                    ImagePath = "MauiApp1.Resources.Images.eng.SetupSteps_RISTOpeMode.s1_img.png"
                },
                new StepImgDataClass()
                {
                    Name = "Step2",
                    ImgData = ImageSource.FromResource("MauiApp1.Resources.Images.eng.SetupSteps_RISTOpeMode.s2_img.png"),
                    ImagePath = "MauiApp1.Resources.Images.eng.SetupSteps_RISTOpeMode.s2_img.png",
                },
            };

        this.BindingContext = this;
    }

    private void PreImgButoon_Clicked(object sender, EventArgs e)
    {

    }

    private void NextImgButton_Clicked(object sender, EventArgs e)
    {

    }
}