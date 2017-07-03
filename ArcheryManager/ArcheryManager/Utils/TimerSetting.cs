using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ArcheryManager.Pages.TimerPage;

namespace ArcheryManager.Utils
{
    public class TimerSetting : BindableObject
    {
        private const int DefaultWaitingTime = 10;
        private const int DefaultTime = 120;

        public static readonly BindableProperty TimeProperty =
                      BindableProperty.Create(nameof(Time), typeof(int), typeof(TimerSetting), DefaultTime);

        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty ModeProperty =
                      BindableProperty.Create(nameof(Mode), typeof(TimerMode), typeof(TimerSetting), default(TimerMode));

        public TimerMode Mode
        {
            get { return (TimerMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly BindableProperty WaitingTimeProperty =
                      BindableProperty.Create(nameof(WaitingTime), typeof(int), typeof(TimerSetting), DefaultWaitingTime);

        public int WaitingTime
        {
            get { return (int)GetValue(WaitingTimeProperty); }
            set { SetValue(WaitingTimeProperty, value); }
        }
    }
}
