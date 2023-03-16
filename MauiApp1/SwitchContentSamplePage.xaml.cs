using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1;

public partial class SwitchContentSamplePage : ContentPage, INotifyPropertyChanged
{
	public enum EDISPLAY_TYPE
	{
		eALL,eTYPE1, eTYPE2
	}

	public class SampleListData
	{
		public string DisplayLabel { get; set; } = string.Empty;

		public EDISPLAY_TYPE DisplayType { get; set; } = EDISPLAY_TYPE.eTYPE1;

        public Command NextCommand { get; set; } = new Command(() => { });
    }

    private readonly ObservableCollection<SampleListData> _listdata;

    private IEnumerable<SampleListData> _data = new List<SampleListData>();
	public ObservableCollection<SampleListData> Data
    {
        get { return  (ObservableCollection<SampleListData>)_data; }
        set
        {
            _data = value;
            
            OnPropertyChanged(nameof(Data));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Data)));
        }
    }

    private EDISPLAY_TYPE userSelectedDisplayType = EDISPLAY_TYPE.eALL;

    public SwitchContentSamplePage()
	{
		InitializeComponent();

        _listdata = new ObservableCollection<SampleListData>()
        {
            new SampleListData()
            {
                DisplayLabel = "Data1",
                
                NextCommand = new Command( async() =>
                {
                    await Navigation.PushAsync(new NewPage3("Data1"));
                })
            },
            new SampleListData()
            {
                DisplayLabel = "Data2",
                DisplayType = EDISPLAY_TYPE.eTYPE2,
                NextCommand = new Command( async() =>
                {
                    await Navigation.PushAsync(new NewPage3("Data2"));
                })
            },
            new SampleListData()
            {
                DisplayLabel = "Data3",
                NextCommand = new Command( async() =>
                {
                    await Navigation.PushAsync(new NewPage3("Data3"));
                })
            }
        };


        Data = _listdata;

        this.BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //UpdateListData(userSelectedDisplayType);
    }

    private void UpdateListData(EDISPLAY_TYPE displayType)
    {
        switch (displayType)
        {
            case EDISPLAY_TYPE.eALL:
                userSelectedDisplayType = EDISPLAY_TYPE.eALL;
                Data = new ObservableCollection<SampleListData>(_listdata); 
                AllBtn.BackgroundColor = Colors.SkyBlue;
                Type1Btn.BackgroundColor = Colors.LightGray;
                Type2Btn.BackgroundColor = Colors.LightGray;
                break;
            case EDISPLAY_TYPE.eTYPE1:
                userSelectedDisplayType = EDISPLAY_TYPE.eTYPE1;
                Data = new ObservableCollection<SampleListData>(_listdata.Where(x => x.DisplayType == displayType));
                //Data.Add(new SampleListData { DisplayLabel = "Data4", });
                AllBtn.BackgroundColor = Colors.LightGray;
                Type1Btn.BackgroundColor = Colors.SkyBlue;
                Type2Btn.BackgroundColor = Colors.LightGray;
                break;
            case EDISPLAY_TYPE.eTYPE2:
                userSelectedDisplayType = EDISPLAY_TYPE.eTYPE2;
                Data = new ObservableCollection<SampleListData>(_listdata.Where(x => x.DisplayType == displayType));
                AllBtn.BackgroundColor = Colors.LightGray;
                Type1Btn.BackgroundColor = Colors.LightGray;
                Type2Btn.BackgroundColor = Colors.SkyBlue;
                break;
        }
    }

    private void AllBtn_Clicked(object sender, EventArgs e)
    {
        UpdateListData(EDISPLAY_TYPE.eALL);
    }

    private void Type1_Clicked(object sender, EventArgs e)
    {
        UpdateListData(EDISPLAY_TYPE.eTYPE1);
    }

    private void Type2Btn_Clicked(object sender, EventArgs e)
    {
        UpdateListData(EDISPLAY_TYPE.eTYPE2);
    }
}