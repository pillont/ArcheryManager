﻿using ArcheryManager.CustomControls;
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
        private const string TimeSelectorToolBarItemName = "Time";
        private static readonly Color DefaultbackgroundColor = Color.White;

        private readonly TimerBehavior Behavior;

        public Color Color
        {
            get { return timer.Color; }
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

        public TimerPageSetting TimerSetting { get; private set; }

        public TimerPage()
        {
            TimerSetting = new TimerPageSetting();
            BindingContext = this;
            InitializeComponent();
            Behavior = new TimerBehavior();
            timer.Behaviors.Add(Behavior);
            timer.PropertyChanged += Timer_PropertyChanged;
            AddToolbarItems();

            var recognizer = new TapGestureRecognizer() { Command = new Command(Timer_Tap) };
            timer.GestureRecognizers.Add(recognizer);
        }

        #region toolbar items

        private void AddToolbarItems()
        {
            var waveButton = CreateWaveButton();
            ToolbarItems.Add(waveButton);

            var timeButton = CreateTimeSelectorButton();
            ToolbarItems.Add(timeButton);
        }

        private ToolbarItem CreateTimeSelectorButton()
        {
            var timeButton = new ToolbarItem()
            {
                Command = new Command(TimeSelectorButton_Click),
                BindingContext = TimerSetting,
                Text = TimeSelectorToolBarItemName,
            };

            return timeButton;
        }

        private void TimeSelectorButton_Click(object obj)
        {
            /*
             * 1.- Add a Picker with IsVisible property = false, and add it to your page //  value => biding time!
             * 2.- When the user taps on the button use the focus event of the picker so the user can see it:
             * 3.- picker.Focus();
             */
        }

        private ToolbarItem CreateWaveButton()
        {
            var waveButton = new ToolbarItem()
            {
                Command = new Command(WaveButton_Click),
                BindingContext = TimerSetting,
            };

            waveButton.SetBinding(MenuItem.TextProperty, nameof(TimerSetting.Mode));

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
