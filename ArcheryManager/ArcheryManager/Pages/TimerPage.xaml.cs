using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public enum TimerMode
        {
            ABC,
            ABCD,
            Shootout
        };

        private const int ShootoutTime = 40;
        private const string DefaultPauseReplayText = PauseText;
        private const string PauseText = "Pause";
        private const string ReplayText = "Replay";
        private static readonly Color DefaultbackgroundColor = Color.White;

        private readonly TimerBehavior Behavior;

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

        public TimerPageSetting TimerSetting { get; private set; }

        public TimerPage()
        {
            TimerSetting = new TimerPageSetting();
            this.BindingContext = this;
            InitializeComponent();
            Behavior = new TimerBehavior();
            timer.Behaviors.Add(Behavior);
            timer.PropertyChanged += Timer_PropertyChanged;

            var waveButton = new ToolbarItem()
            {
                Command = new Command(WaveButton_Click),
                BindingContext = TimerSetting,
            };

            waveButton.SetBinding(MenuItem.TextProperty, nameof(TimerSetting.Mode));
            ToolbarItems.Add(waveButton);
        }

        private void WaveButton_Click()
        {
            TimerSetting.Mode = (TimerMode)(((int)TimerSetting.Mode + 1) % 3);

            switch (TimerSetting.Mode)
            {
                case TimerMode.ABC:
                    timer.Time = TimerSetting.Time;
                    timer.ShowWaitingTime = true;
                    timer.WaveControl.StopWave();
                    break;

                case TimerMode.ABCD:
                    timer.WaveControl.StartWave();
                    timer.Time = TimerSetting.Time;
                    timer.ShowWaitingTime = true;

                    break;

                case TimerMode.Shootout:
                    timer.Time = ShootoutTime;
                    timer.ShowWaitingTime = false;
                    timer.WaveControl.StopWave();
                    break;
            }
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
            Behavior.Start();
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            Behavior.Stop();
        }

        private void ButtonPause_Clicked(object sender, EventArgs e)
        {
            if (timer.IsPaused)
                Behavior.Continue();
            else if (!timer.IsStopped)
                Behavior.Pause();
        }
    }
}
