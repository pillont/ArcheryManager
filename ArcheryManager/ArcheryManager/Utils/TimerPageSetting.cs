﻿using Xamarin.Forms;
using static ArcheryManager.Pages.TimerPage;

namespace ArcheryManager.Utils
{
    public class TimerPageSetting : BindableObject
    {
        private const int DefaultWaitingTime = 10;
        private const int DefaultTime = 120;

        public static readonly BindableProperty TimeProperty =
                      BindableProperty.Create(nameof(Time), typeof(int), typeof(TimerPageSetting), DefaultTime);

        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty ModeProperty =
                      BindableProperty.Create(nameof(Mode), typeof(TimerMode), typeof(TimerPageSetting), default(TimerMode));

        public TimerMode Mode
        {
            get { return (TimerMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly BindableProperty WaitingTimeProperty =
                      BindableProperty.Create(nameof(WaitingTime), typeof(int), typeof(TimerPageSetting), DefaultWaitingTime);

        public int WaitingTime
        {
            get { return (int)GetValue(WaitingTimeProperty); }
            set { SetValue(WaitingTimeProperty, value); }
        }
    }
}