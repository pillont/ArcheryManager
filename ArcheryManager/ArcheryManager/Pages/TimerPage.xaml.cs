using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private const int ShootoutTime = 40;
        private const int MinTime = 40;
        private const int MaxTime = 300;
        private const int StepTime = 5;
        private static readonly Color DefaultbackgroundColor = Color.White;

        private readonly TimerBehavior Behavior;

        public Color Color
        {
            get { return timer.Color; }
        }

        public string Mode
        {
            get
            {
                return TimerSetting.Mode;
            }
        }

        public static readonly BindableProperty PauseReplayTextProperty =
                      BindableProperty.Create(nameof(PauseReplayText), typeof(string), typeof(TimerPage), string.Empty);

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

        public TimerPageSetting TimerSetting { get; private set; }

        public TimerPage()
        {
            TimerSetting = new TimerPageSetting();
            TimerSetting.PropertyChanged += TimerSetting_PropertyChanged;

            BindingContext = this;
            InitializeComponent();
            Behavior = new TimerBehavior(TimerSetting);
            timer.Behaviors.Add(Behavior);
            timer.PropertyChanged += Timer_PropertyChanged;

            var recognizer = new TapGestureRecognizer() { Command = new Command(Timer_Tap) };
            timer.GestureRecognizers.Add(recognizer);

            PauseReplayText = AppResources.Pause;

            var behavior = new NumericPickerBehavior(MinTime, MaxTime, StepTime);
            timePicker.Behaviors.Add(behavior);

            AddToolbarItems();
        }

        private void TimerSetting_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TimerSetting.Time))
            {
                timer.Time = TimerSetting.Time;
            }
            else if (e.PropertyName == nameof(TimerSetting.Mode))
            {
                OnPropertyChanged(e.PropertyName);
            }
        }

        #region toolbar items

        private void AddToolbarItems()
        {
            var songButton = CreateSongSelectorButton();
            ToolbarItems.Add(songButton);

            var timeButton = CreateTimeSelectorButton();
            ToolbarItems.Add(timeButton);

            var waveButton = CreateWaveButton();
            ToolbarItems.Add(waveButton);
        }

        private ToolbarItem CreateSongSelectorButton()
        {
            var songButton = new ToolbarItem()
            {
                Command = new Command(SongSelectorButton_Click),
                BindingContext = TimerSetting,
                Text = AppResources.Song,
            };

            var list = timePicker.ItemsSource as List<double>;
            int index = list.FindIndex(i => i == timer.Time);
            timePicker.SelectedIndex = index;

            return songButton;
        }

        private void SongSelectorButton_Click(object obj)
        {
            songPicker.Focus();
        }

        private ToolbarItem CreateTimeSelectorButton()
        {
            var timeButton = new ToolbarItem()
            {
                Command = new Command(TimeSelectorButton_Click),
                BindingContext = TimerSetting,
                Text = AppResources.Time,
            };

            var list = timePicker.ItemsSource as List<double>;
            int index = list.FindIndex(i => i == timer.Time);
            timePicker.SelectedIndex = index;

            return timeButton;
        }

        private void TimeSelectorButton_Click(object obj)
        {
            timePicker.Focus();
        }

        private ToolbarItem CreateWaveButton()
        {
            var waveButton = new ToolbarItem()
            {
                Text = AppResources.Mode,
                Command = new Command(WaveButton_Click),
                BindingContext = TimerSetting,
            };

            return waveButton;
        }

        private void Timer_Tap(object obj)
        {
            if (timer.IsStopped)
            {
                ButtonStart_Clicked(timer, null);
            }
            else
            {
                ButtonStop_Clicked(timer, null);
            }
        }

        private void WaveButton_Click()
        {
            modePicker.Focus();
        }

        #endregion toolbar items

        private void Timer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var timer = sender as CustomTimer;

            switch (e.PropertyName)
            {
                case nameof(timer.IsStopped):

                    IsPauseEnabled = GetPauseEnabledValue(timer);
                    break;

                case nameof(timer.IsPaused):

                    if (timer.IsPaused)
                    {
                        PauseReplayText = AppResources.Replay;
                    }
                    else
                    {
                        PauseReplayText = AppResources.Pause;
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

        private void TimerPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TimerSetting.Time = Convert.ToInt32(timePicker.ItemsSource[timePicker.SelectedIndex]);
            }
            catch (Exception)
            {
                DisplayAlert("Error", "error during the change of time", "OK");
            }
        }

        private void SongPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = songPicker.ItemsSource[songPicker.SelectedIndex] as string;
            string fileName = TimerPageSetting.AllSongFiles.Where(pair => pair.Key == name).First().Value;
            TimerSetting.SongFileName = fileName;

            Behavior.PlaySong();
        }

        private void modePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = modePicker.SelectedItem as string;
            TimerSetting.Mode = mode;

            SetupWaveMode();
        }

        private void SetupWaveMode()
        {
            Behavior.Stop();
            if (TimerSetting.Mode == AppResources.ABC)
            {
                timer.Time = TimerSetting.Time;
                timer.ShowWaitingTime = true;
                timer.WaveBehavior.StopWave();
            }
            else if (TimerSetting.Mode == AppResources.ABCD)
            {
                timer.WaveBehavior.StartWave();
                timer.WaveBehavior.DuelMode = false;
                timer.Time = TimerSetting.Time;
                timer.ShowWaitingTime = true;
            }
            else if (TimerSetting.Mode == AppResources.Duel)
            {
                timer.WaveBehavior.StartWave();
                timer.WaveBehavior.DuelMode = true;
                timer.Time = TimerSetting.Time;
                timer.ShowWaitingTime = true;
            }
            else if (TimerSetting.Mode == AppResources.ShootOut)
            {
                timer.Time = ShootoutTime;
                timer.ShowWaitingTime = false;
                timer.WaveBehavior.StopWave();
            }
        }
    }
}
