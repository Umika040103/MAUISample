namespace MauiApp1;

public partial class ProgressRing : Grid
{
    private RingProgressArc _ringProgressArc;
    private RingBackground _ringBackground;

    #region RingThickness Property
    public static readonly BindableProperty RingThicknessProperty =
        BindableProperty.Create(
            nameof(RingThickness),
            typeof(int),
            typeof(ProgressRing),
            10,
            defaultBindingMode: BindingMode.TwoWay,
            null,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((ProgressRing)bindable).RingThickness = (int)newValue);


    public int RingThickness
    {
        set
        {
            SetValue(RingThicknessProperty, value);
            _ringBackground.Thickness = value;
            _ringProgressArc.Thickness = value;
            RingBackgroundView.Invalidate();
            RingProgressView.Invalidate();
        }
        get
        {
            return (int)GetValue(RingThicknessProperty);
        }
    }
    #endregion

    #region RingBaseColor Property

    public static readonly BindableProperty RingBaseColorsProperty =
    BindableProperty.Create(
        nameof(RingBaseColor),
        typeof(Color),
        typeof(ProgressRing),
        Colors.Gray,
        defaultBindingMode: BindingMode.TwoWay,
        null,
        propertyChanged: (bindable, oldValue, newValue) =>
        ((ProgressRing)bindable).RingBaseColor = (Color)newValue);

    public Color RingBaseColor
    {
        set
        {
            SetValue(RingBaseColorsProperty, value);
            _ringBackground.BackgroundColor = value;
            RingBackgroundView.Invalidate();
        }
        get { return (Color)GetValue(RingBaseColorsProperty); }
    }

    #endregion

    #region RingProgressColor Property

    public static readonly BindableProperty RingProgressColorProperty =
    BindableProperty.Create(
        nameof(RingProgressColor),
        typeof(Color),
        typeof(ProgressRing),
        Colors.Red,
        defaultBindingMode: BindingMode.TwoWay,
        null,
        propertyChanged: (bindable, oldValue, newValue) =>
        ((ProgressRing)bindable).RingProgressColor = (Color)newValue);

    public Color RingProgressColor
    {
        set
        {
            SetValue(RingProgressColorProperty, value);
            _ringProgressArc.ProgressColor = value;
            RingProgressView.Invalidate();
        }
        get
        {
            return (Color)GetValue(RingProgressColorProperty);
        }
    }
    #endregion

    #region Progress Property
    public static readonly BindableProperty ProgressProperty =
    BindableProperty.Create(
        nameof(Progress),
        typeof(int),
        typeof(ProgressRing),
        100,
        defaultBindingMode: BindingMode.TwoWay,
        null,
        propertyChanged: (bindable, oldValue, newValue) =>
        ((ProgressRing)bindable).Progress = (int)newValue);

    public int Progress
    {
        set
        {
            SetValue(ProgressProperty, value);
            _ringProgressArc.Progress = value;
            RingProgressView.Invalidate();
        }
        get { return (int)GetValue(ProgressProperty); }
    }

    #endregion

    #region ProgressClockwise Property
    public bool ProgressClockwise
    {
        set
        {
            _ringProgressArc.ProgressClockwise = value;
            RingProgressView.Invalidate();
        }
        get { return _ringProgressArc.ProgressClockwise; }
    }

    #endregion

    public ProgressRing()
    {
        InitializeComponent();

        // Setup ring background 
        _ringBackground = new RingBackground();
        RingBackgroundView.Drawable = _ringBackground;

        // Setup progressring
        _ringProgressArc = new RingProgressArc();
        RingProgressView.Drawable = _ringProgressArc;
    }

    private class RingBackground : IDrawable
    {
        public int Thickness { get; set; }
        public Color BackgroundColor { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = BackgroundColor;
            canvas.StrokeSize = Thickness;
            var shift = (int)(Thickness / 2);
            canvas.DrawEllipse(shift, shift, (dirtyRect.Width - Thickness), (dirtyRect.Height - Thickness));
        }
    }

    private class RingProgressArc : IDrawable
    {
        public int Thickness { get; set; }
        public Color ProgressColor { get; set; }

        public int Progress { get; set; }

        public bool ProgressClockwise { get; set; } = true;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Angle of the arc in degrees
            var endAngle = 90 - (int)(Progress * 360 / 100);
            // Drawing code goes here
            canvas.StrokeColor = ProgressColor;
            canvas.StrokeSize = Thickness;

            var shift = (int)(Thickness / 2);
            if (Progress < 100)
            {
                canvas.DrawArc(shift, shift, (dirtyRect.Width - Thickness), (dirtyRect.Height - Thickness), 90, endAngle, ProgressClockwise, false);
            }
            else
            {
                canvas.DrawEllipse(shift, shift, (dirtyRect.Width - Thickness), (dirtyRect.Height - Thickness));
            }
        }
    }
}