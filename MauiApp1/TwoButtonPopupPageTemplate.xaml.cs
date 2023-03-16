using MauiPopup;
using MauiPopup.Views;

namespace MauiApp1;

public partial class TwoButtonPopupPageTemplate : BasePopupPage
{
    #region ChildContent BindableProperty
    public static readonly BindableProperty ChildContentProperty =
        BindableProperty.Create(
            nameof(ChildContent),
            typeof(View),
            typeof(TwoButtonPopupPageTemplate),
            null,
            defaultBindingMode: BindingMode.TwoWay,     //バインド方向
            null,                                       //バリデーションメソッド
            propertyChanged: (bindable, oldValue, newValue) =>
                      ((TwoButtonPopupPageTemplate)bindable).ChildContent = (View)newValue
            );

    public View ChildContent
    {
        get { return (View)GetValue(ChildContentProperty); }
        set
        {
            if (value != null)
            {
                SetValue(ChildContentProperty, value);
                ContentsGrid.Children.Add(value);
            }
        }
    }
    #endregion

    #region PopupTitle BindableProperty
    public static readonly BindableProperty PopupTitleProperty =
        BindableProperty.Create(
            nameof(PopupTitle),
            typeof(string),
            typeof(TwoButtonPopupPageTemplate),
            null,
            defaultBindingMode: BindingMode.TwoWay,     //バインド方向
            null,                                       //バリデーションメソッド
            propertyChanged: (bindable, oldValue, newValue) =>
                      ((TwoButtonPopupPageTemplate)bindable).PopupTitle = (string)newValue
            );

    public string PopupTitle
    {
        get { return (string)GetValue(PopupTitleProperty); }
        set
        {
            if (value != null)
            {
                SetValue(PopupTitleProperty, value);
                TitleLabel.Text = value;
            }
        }
    }
    #endregion


    #region CancelButtonLabel BindableProperty
    public static readonly BindableProperty CancelButtonLabelProperty =
        BindableProperty.Create(
            nameof(CancelButtonLabel),
            typeof(string),
            typeof(TwoButtonPopupPageTemplate),
            null,
            defaultBindingMode: BindingMode.TwoWay,     //バインド方向
            null,                                       //バリデーションメソッド
            propertyChanged: (bindable, oldValue, newValue) =>
                      ((TwoButtonPopupPageTemplate)bindable).CancelButtonLabel = (string)newValue
            );

    public string CancelButtonLabel
    {
        get { return (string)GetValue(CancelButtonLabelProperty); }
        set
        {
            if (value != null)
            {
                SetValue(CancelButtonLabelProperty, value);
                CancelButton.Text = value;
            }
        }
    }
    #endregion

    #region ExecuteButtonLabel BindableProperty
    public static readonly BindableProperty ExecuteButtonLabelProperty =
        BindableProperty.Create(
            nameof(ExecuteButtonLabel),
            typeof(string),
            typeof(TwoButtonPopupPageTemplate),
            null,
            defaultBindingMode: BindingMode.TwoWay,     //バインド方向
            null,                                       //バリデーションメソッド
            propertyChanged: (bindable, oldValue, newValue) =>
                      ((TwoButtonPopupPageTemplate)bindable).ExecuteButtonLabel = (string)newValue
            );

    public string ExecuteButtonLabel
    {
        get { return (string)GetValue(ExecuteButtonLabelProperty); }
        set
        {
            if (value != null)
            {
                SetValue(ExecuteButtonLabelProperty, value);
                ExecuteButton.Text = value;
            }
        }
    }
    #endregion

    #region ExecuteButtonColor BindableProperty
    public static readonly BindableProperty ExecuteButtonColorProperty =
        BindableProperty.Create(
            nameof(ExecuteButtonColor),
            typeof(Color),
            typeof(TwoButtonPopupPageTemplate),
            App.Current.Resources["ColorOrange"]
            );

    public Color ExecuteButtonColor
    {
        get { return (Color)GetValue(ExecuteButtonColorProperty); }
        set
        {
            if (value != null)
            {
                SetValue(ExecuteButtonColorProperty, value);
                ExecuteButton.BackgroundColor = value;
            }
        }
    }
    #endregion

    public int ButtonCornerRadius { get; private set; }
    public int ButtonHeightRequest { get; private set; }
    public TwoButtonPopupPageTemplate()
	{
		InitializeComponent();

        var fontsize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        ButtonHeightRequest = (int)fontsize * 2;
        ButtonCornerRadius = (int)fontsize;


        //this.BindingContext = this;
    }

    protected virtual async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await PopupAction.ClosePopup(false);
    }


    protected virtual async void ExecuteButton_Clicked(object sender, EventArgs e)
    {
        await PopupAction.ClosePopup(true);
    }

    public async Task ClosePopupPage()
    {
        await PopupAction.ClosePopup(false);
    }
}