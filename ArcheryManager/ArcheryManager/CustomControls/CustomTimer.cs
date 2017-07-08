using ArcheryManager.Interactions.Behaviors;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public partial class CustomTimer : ContentView
    {
        private const bool DefaultShowWaitingTime = true;
        /*
         * Sizes
         */
        private const float DefaultBorderWidth = 2f;
        private const float DefaultProgressBorderWidth = 10f;
        private const int DefaultFontSize = 24;
        private const int maxProgress = 100;
        private const int CircleSize = 300; //TODO

        /// <summary>
        /// max of progress in the circle
        /// </summary>
        public int MaxProgress
        {
            get
            { return maxProgress; }
        }

        #region bindable properties

        #region visual properties

        public static readonly BindableProperty FontAttributesProperty =
                      BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(CustomTimer), FontAttributes.Bold);

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        /// <summary>
        /// font size of the label
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
                      BindableProperty.Create(nameof(FontSize), typeof(int), typeof(CustomTimer), DefaultFontSize);

        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        /// <summary>
        /// color of the progress border
        /// </summary>
        public static readonly BindableProperty ProgressBorderColorProperty =
                      BindableProperty.Create(nameof(ProgressBorderColor), typeof(Color), typeof(CustomTimer), TimerBehavior.DefaultProgressBorderColor);

        public Color ProgressBorderColor
        {
            get { return (Color)GetValue(ProgressBorderColorProperty); }
            set { SetValue(ProgressBorderColorProperty, value); }
        }

        /// <summary>
        /// width of the progress border
        /// </summary>
        public static readonly BindableProperty ProgressBorderWidthProperty =
                      BindableProperty.Create(nameof(ProgressBorderWidth), typeof(float), typeof(CustomTimer), DefaultProgressBorderWidth);

        public float ProgressBorderWidth
        {
            get { return (float)GetValue(ProgressBorderWidthProperty); }
            set { SetValue(ProgressBorderWidthProperty, value); }
        }

        private static readonly BindableProperty BorderWidthProperty =
                      BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(CustomTimer), DefaultBorderWidth);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
                     BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomTimer), TimerBehavior.DefaultBorderColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        #endregion visual properties

        #region timer setting

        internal static readonly BindableProperty ShowWaitingTimeProperty =
                      BindableProperty.Create(nameof(ShowWaitingTime), typeof(bool), typeof(CustomTimer), DefaultShowWaitingTime);

        internal bool ShowWaitingTime
        {
            get { return (bool)GetValue(ShowWaitingTimeProperty); }
            set { SetValue(ShowWaitingTimeProperty, value); }
        }

        /// <summary>
        /// limit time of the timer
        /// </summary>
        internal static readonly BindableProperty LimitTimeProperty =
                      BindableProperty.Create(nameof(LimitTime), typeof(int), typeof(CustomTimer), TimerBehavior.DefaultLimitTime);

        internal int LimitTime
        {
            get { return (int)GetValue(LimitTimeProperty); }
            set { SetValue(LimitTimeProperty, value); }
        }

        /// <summary>
        /// color during the waiting time
        /// </summary>
        internal static readonly BindableProperty WaitingColorProperty =
                      BindableProperty.Create(nameof(WaitingColor), typeof(Color), typeof(CustomTimer), TimerBehavior.DefaultWaitingColor);

        internal Color WaitingColor
        {
            get { return (Color)GetValue(WaitingColorProperty); }
            set { SetValue(WaitingColorProperty, value); }
        }

        /// <summary>
        /// time of the wainting period
        /// </summary>
        public static readonly BindableProperty WaitingTimeProperty =
                      BindableProperty.Create(nameof(WaitingTime), typeof(int), typeof(CustomTimer), TimerBehavior.DefaultWaitingTime);

        public int WaitingTime
        {
            get { return (int)GetValue(WaitingTimeProperty); }
            set { SetValue(WaitingTimeProperty, value); }
        }

        public static readonly BindableProperty TimeProperty =
                      BindableProperty.Create(nameof(Time), typeof(int), typeof(CustomTimer), TimerBehavior.DefaultTime);

        /// <summary>
        /// general time of the timer
        /// </summary>
        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set
            {
                SetValue(TimeProperty, value);

                if (IsStopped)
                {
                    Text = Time.ToString();
                }
            }
        }

        #endregion timer setting

        #region values properties

        internal static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(CustomTimer), TimerBehavior.DefaultColor);

        /// <summary>
        /// color of the timer
        /// </summary>
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            internal set
            {
                SetValue(ColorProperty, value);
            }
        }

        internal static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomTimer), TimerBehavior.DefaultTime.ToString());

        /// <summary>
        /// text of the timer
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            internal set { SetValue(TextProperty, value); }
        }

        internal static readonly BindableProperty ProgressProperty =
                      BindableProperty.Create(nameof(Progress), typeof(int), typeof(CustomTimer), 0);

        /// <summary>
        /// Progress of the timer
        /// </summary>
        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            internal set { SetValue(ProgressProperty, value); }
        }

        internal static readonly BindableProperty IsStoppedProperty =
                      BindableProperty.Create(nameof(IsStopped), typeof(bool), typeof(CustomTimer), true);

        public bool IsStopped
        {
            get { return (bool)GetValue(IsStoppedProperty); }
            internal set { SetValue(IsStoppedProperty, value); }
        }

        internal static readonly BindableProperty IsPausedProperty =
                      BindableProperty.Create(nameof(IsPaused), typeof(bool), typeof(CustomTimer), false);

        public bool IsPaused
        {
            get { return (bool)GetValue(IsPausedProperty); }
            internal set { SetValue(IsPausedProperty, value); }
        }

        internal static readonly BindableProperty IsWaitingTimeProperty =
                      BindableProperty.Create(nameof(IsWaitingTime), typeof(bool), typeof(CustomTimer), false);

        public bool IsWaitingTime
        {
            get { return (bool)GetValue(IsWaitingTimeProperty); }
            internal set { SetValue(IsWaitingTimeProperty, value); }
        }

        #endregion values properties

        #endregion bindable properties

        public WaveBehavior WaveBehavior { get; private set; }

        public CustomTimer()
        {
            ShapeView progressCircle = CreateCircle();
            var time = CreateTimeLabel();
            var wave = CreateWaveLabel();

            Grid grid = new Grid();
            grid.Children.Add(progressCircle);
            grid.Children.Add(time);
            grid.Children.Add(wave);

            Content = grid;
        }

        #region visuals generation

        /// <summary>
        /// function to create the circle
        /// </summary>
        /// <returns></returns>
        private ShapeView CreateCircle()
        {
            var progressCircle = new ShapeView
            {
                HeightRequest = CircleSize,
                WidthRequest = CircleSize,
                ShapeType = ShapeType.ProgressCircle,
                BorderColor = BorderColor,
                BorderWidth = BorderWidth,
                ProgressBorderWidth = ProgressBorderWidth,
                ProgressBorderColor = ProgressBorderColor,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = "timerCircle",
            };

            progressCircle.SetBinding(ShapeView.ColorProperty, nameof(Color));
            progressCircle.SetBinding(ShapeView.ProgressProperty, nameof(Progress));
            progressCircle.BindingContext = this;
            return progressCircle;
        }

        /// <summary>
        /// function to create label
        /// </summary>
        /// <returns></returns>
        private View CreateTimeLabel()
        {
            var timeLabel = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = FontSize,
                FontAttributes = FontAttributes,
                AutomationId = "TimerLabel",
            };

            timeLabel.SetBinding(Label.TextProperty, nameof(Text));
            timeLabel.SetBinding(Label.FontSizeProperty, nameof(FontSize));
            timeLabel.SetBinding(Label.FontAttributesProperty, nameof(FontAttributes));
            timeLabel.BindingContext = this;

            return timeLabel;
        }

        /// <summary>
        /// function to create label
        /// </summary>
        /// <returns></returns>
        private View CreateWaveLabel()
        {
            var label = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = FontSize,
                FontAttributes = FontAttributes,
                AutomationId = "WaveText",
                TranslationY = CircleSize / 4,
            };

            label.SetBinding(Label.FontSizeProperty, nameof(FontSize));
            label.SetBinding(Label.FontAttributesProperty, nameof(FontAttributes));
            label.BindingContext = this;

            WaveBehavior = new WaveBehavior();
            label.Behaviors.Add(WaveBehavior);

            return label;
        }

        #endregion visuals generation
    }
}
