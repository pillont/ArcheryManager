using System;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public partial class CustomTimer : ContentView
    {
        /*
         * Sizes
         */
        private const float DefaultBorderWidth = 2f;
        private const float DefaultProgressBorderWidth = 10f;
        private const int DefaultFontSize = 24;

        /*
         * Times
         */
        private const int DefaultTime = 120;
        private const int MaxProgress = 100;
        private const int DefaultWaitingTime = 10;
        private const int DefaultLimitTime = 30;

        /*
         * Colors
         */
        private static readonly Color DefaultColor = Color.Red;
        private static readonly Color DefaultProgressBorderColor = Color.Gray;
        private static readonly Color DefaultBorderColor = Color.Gray;
        private static readonly Color DefaultWaitingColor = Color.Red;
        private static readonly Color GeneralTimeColor = Color.Green;
        private static readonly Color LimitTimeColor = Color.Orange;
        private static readonly Color StopTimeColor = Color.Red;

        #region bindable properties

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
        /// limit time of the timer
        /// </summary>
        public static readonly BindableProperty LimitTimeProperty =
                      BindableProperty.Create(nameof(LimitTime), typeof(int), typeof(CustomTimer), DefaultLimitTime);

        public int LimitTime
        {
            get { return (int)GetValue(LimitTimeProperty); }
            set { SetValue(LimitTimeProperty, value); }
        }

        /// <summary>
        /// color during the waiting time
        /// </summary>
        public static readonly BindableProperty WaitingColorProperty =
                      BindableProperty.Create(nameof(WaitingColor), typeof(Color), typeof(CustomTimer), DefaultWaitingColor);

        public Color WaitingColor
        {
            get { return (Color)GetValue(WaitingColorProperty); }
            set { SetValue(WaitingColorProperty, value); }
        }

        /// <summary>
        /// time of the wainting period
        /// </summary>
        public static readonly BindableProperty WaitingTimeProperty =
                      BindableProperty.Create(nameof(WaitingTime), typeof(int), typeof(CustomTimer), DefaultWaitingTime);

        public int WaitingTime
        {
            get { return (int)GetValue(WaitingTimeProperty); }
            set { SetValue(WaitingTimeProperty, value); }
        }

        /// <summary>
        /// color of the progress border
        /// </summary>
        public static readonly BindableProperty ProgressBorderColorProperty =
                      BindableProperty.Create(nameof(ProgressBorderColor), typeof(Color), typeof(CustomTimer), DefaultProgressBorderColor);

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
                     BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomTimer), DefaultBorderColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty TimeProperty =
                      BindableProperty.Create(nameof(Time), typeof(int), typeof(CustomTimer), DefaultTime);

        /// <summary>
        /// general time of the timer
        /// </summary>
        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(CustomTimer), DefaultColor);

        /// <summary>
        /// color of the timer
        /// </summary>
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomTimer), DefaultTime.ToString());

        /// <summary>
        /// text of the timer
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ProgressProperty =
                      BindableProperty.Create(nameof(Progress), typeof(int), typeof(CustomTimer), 0);

        /// <summary>
        /// Progress of the timer
        /// </summary>
        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public static readonly BindableProperty IsStoppedProperty =
                      BindableProperty.Create(nameof(IsStopped), typeof(bool), typeof(CustomTimer), true);

        public bool IsStopped
        {
            get { return (bool)GetValue(IsStoppedProperty); }
            private set { SetValue(IsStoppedProperty, value); }
        }

        public static readonly BindableProperty IsPausedProperty =
                      BindableProperty.Create(nameof(IsPaused), typeof(bool), typeof(CustomTimer), false);

        public bool IsPaused
        {
            get { return (bool)GetValue(IsPausedProperty); }
            private set { SetValue(IsPausedProperty, value); }
        }

        public static readonly BindableProperty IsWaitingTimeProperty =
                      BindableProperty.Create(nameof(IsWaitingTime), typeof(bool), typeof(CustomTimer), false);

        public bool IsWaitingTime
        {
            get { return (bool)GetValue(IsWaitingTimeProperty); }
            private set { SetValue(IsWaitingTimeProperty, value); }
        }

        #endregion bindable properties

        #region timer properties

        /// <summary>
        /// current time to show
        /// </summary>
        private int Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
                Text = value.ToString();
                Progress = current * MaxProgress / currentMax;
            }
        }

        private int current;
        private int currentMax;

        #endregion timer properties

        public CustomTimer()
        {
            ShapeView progressCircle = CreateCircle();
            Label textLabel = CreateLabel();

            Grid grid = new Grid();
            grid.Children.Add(progressCircle);
            grid.Children.Add(textLabel);

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
                HeightRequest = 300, //TODO
                WidthRequest = 300, //TODO
                ShapeType = ShapeType.ProgressCircle,
                BorderColor = BorderColor,
                BorderWidth = BorderWidth,
                ProgressBorderWidth = ProgressBorderWidth,
                ProgressBorderColor = ProgressBorderColor,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
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
        private Label CreateLabel()
        {
            var textLabel = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = FontSize,
                FontAttributes = FontAttributes
            };

            textLabel.SetBinding(Label.TextProperty, nameof(Text));
            textLabel.SetBinding(Label.FontSizeProperty, nameof(FontSize));
            textLabel.SetBinding(Label.FontAttributesProperty, nameof(FontAttributes));
            textLabel.BindingContext = this;
            return textLabel;
        }

        #endregion visuals generation

        #region function to manage the timer

        public void Start()
        {
            if (!IsStopped)
                return;

            IsWaitingTime = true;
            IsStopped = false;
            IsPaused = false;
            currentMax = WaitingTime;
            Current = WaitingTime;
            Device.StartTimer(TimeSpan.FromSeconds(1), WaitingTimerFunction);
        }

        public void Stop()
        {
            IsStopped = true;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Continue()
        {
            if (IsPaused && !IsStopped)
            {
                IsPaused = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            }
        }

        #endregion function to manage the timer

        #region timer function

        /// <summary>
        /// function of the timer to make the waiting period
        /// </summary>
        private bool WaitingTimerFunction()
        {
            if (IsStopped || IsPaused) // timer was stop
            {
                SettingStop();
                return false;
            }

            Color = WaitingColor;
            Current--;

            var res = ShouldContinueTimer(avoidZero: true);

            if (!res) // start timerFunction in the end of this function
            {
                currentMax = Time;
                Current = Time;
                UpdateColor();
                IsWaitingTime = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            }
            return res;
        }

        /// <summary>
        /// function of the timer to make the time period
        /// </summary>
        private bool TimerFunction()
        {
            if (IsStopped) // timer was stop
            {
                SettingStop();
                return false;
            }

            if (IsPaused) // timer was paused
            {
                return false;
            }

            Current--;
            UpdateColor();

            var res = ShouldContinueTimer();
            if (!res) // stop the timer in the end of this function
                SettingStop();

            return res;
        }

        private void SettingStop()
        {
            IsStopped = true;
            IsPaused = false;
            Current = Time;
            Color = StopTimeColor;
        }

        /// <summary>
        /// function to update the color during the time period
        /// </summary>
        private void UpdateColor()
        {
            // general time
            if (Current > LimitTime)
                Color = Color.Green;
            // limit time
            else if (ShouldContinueTimer())
                Color = LimitTimeColor;
            // stop time
            else
                Color = StopTimeColor;
        }

        /// <summary>
        /// function to know if the timer must stop of not
        /// </summary>
        /// <returns></returns>
        private bool ShouldContinueTimer(bool avoidZero = false)
        {
            if (avoidZero)
                return Current > 0; // end of the timer
            else
                return Current >= 0; // end of the timer
        }

        #endregion timer function
    }
}
