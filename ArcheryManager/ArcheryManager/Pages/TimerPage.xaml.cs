using ArcheryManager.CustomControls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private const string DefaultPauseReplayText = PauseText;
        private const string PauseText = "Pause";
        private const string ReplayText = "Replay";
        private static readonly Color DefaultbackgroundColor = Color.White;

        public Color Color
        {
            get { return timer.Color; }
        }

        public static readonly BindableProperty IsStartEnabledProperty =
                      BindableProperty.Create(nameof(IsStartEnabled), typeof(bool), typeof(TimerPage), true);

        public bool IsStartEnabled
        {
            get { return (bool)GetValue(IsStartEnabledProperty); }
            set { SetValue(IsStartEnabledProperty, value); }
        }

        public static readonly BindableProperty PauseReplayTextProperty =
                      BindableProperty.Create(nameof(PauseReplayText), typeof(string), typeof(TimerPage), DefaultPauseReplayText);

        public string PauseReplayText
        {
            get { return (string)GetValue(PauseReplayTextProperty); }
            set { SetValue(PauseReplayTextProperty, value); }
        }

        public static readonly BindableProperty IsPauseEnabledProperty =
                      BindableProperty.Create(nameof(IsPauseEnabled), typeof(bool), typeof(TimerPage), false);

        public bool IsPauseEnabled
        {
            get { return (bool)GetValue(IsPauseEnabledProperty); }
            set { SetValue(IsPauseEnabledProperty, value); }
        }

        public static readonly BindableProperty IsStopEnabledProperty =
                      BindableProperty.Create(nameof(IsStopEnabled), typeof(bool), typeof(TimerPage), false);

        public bool IsStopEnabled
        {
            get { return (bool)GetValue(IsStopEnabledProperty); }
            set { SetValue(IsStopEnabledProperty, value); }
        }

        public TimerPage()
        {
            this.BindingContext = this;
            InitializeComponent();
            timer.PropertyChanged += Timer_PropertyChanged;
        }

        private void Timer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var timer = sender as CustomTimer;

            switch (e.PropertyName)
            {
                case nameof(timer.IsStopped):

                    IsStartEnabled = timer.IsStopped;
                    IsStopEnabled = !timer.IsStopped;

                    IsPauseEnabled = GetPauseEnabledValue(timer);
                    break;

                case nameof(timer.IsPaused):

                    if (timer.IsPaused)
                    {
                        PauseReplayText = ReplayText;
                    }
                    else
                    {
                        PauseReplayText = PauseText;
                    }
                    break;

                case nameof(timer.IsWaitingTime):
                    IsPauseEnabled = GetPauseEnabledValue(timer);
                    break;

                case nameof(timer.Color):
                    OnPropertyChanged(nameof(timer.Color));
                    break;
            }
        }

        private static bool GetPauseEnabledValue(CustomTimer timer)
        {
            return !timer.IsStopped && !timer.IsWaitingTime;
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void ButtonPause_Clicked(object sender, EventArgs e)
        {
            if (timer.IsPaused)
                timer.Continue();
            else if (!timer.IsStopped)
                timer.Pause();
        }
    }
}
