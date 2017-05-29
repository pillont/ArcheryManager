using System;
using Xamarin.Forms;
using ArcheryManager.Interfaces;

namespace ArcheryManager.Behaviors
{
    public class TimerBehavior<T> : Behavior<T> where T : BindableObject, ITimer
    {
        /*
         * Times
         */
        public const int DefaultTime = 120;
        public const int DefaultWaitingTime = 10;
        public const int DefaultLimitTime = 30;

        /*
         * Colors
         */
        public static readonly Color DefaultColor = Color.Red;
        public static readonly Color DefaultProgressBorderColor = Color.Gray;
        public static readonly Color DefaultBorderColor = Color.Gray;
        public static readonly Color DefaultWaitingColor = Color.Red;
        public static readonly Color GeneralTimeColor = Color.Green;
        public static readonly Color LimitTimeColor = Color.Orange;
        public static readonly Color StopTimeColor = Color.Red;

        /// <summary>
        /// timer associated to the behavior
        /// </summary>
        protected T associatedTimer;

        #region logical properties

        private int current;
        private int currentMax;

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
                associatedTimer.Text = value.ToString();
                associatedTimer.Progress = current * associatedTimer.MaxProgress / currentMax;
            }
        }

        #endregion logical properties

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            associatedTimer = bindable;
        }

        #region public function

        public void Start()
        {
            if (!associatedTimer.IsStopped)
                return;

            associatedTimer.IsWaitingTime = true;
            associatedTimer.IsStopped = false;
            associatedTimer.IsPaused = false;
            currentMax = associatedTimer.WaitingTime;
            Current = associatedTimer.WaitingTime;
            Device.StartTimer(TimeSpan.FromSeconds(1), WaitingTimerFunction);
        }

        public void Stop()
        {
            associatedTimer.IsStopped = true;
            //TODO wait one second to be sure the current timer while stopped
        }

        public void Pause()
        {
            associatedTimer.IsPaused = true;
            //TODO wait one second to be sure the current timer while paused
        }

        public void Continue()
        {
            if (associatedTimer.IsPaused && !associatedTimer.IsStopped)
            {
                associatedTimer.IsPaused = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            }
        }

        #endregion public function

        #region private functions

        /// <summary>
        /// function of the timer to make the waiting period
        /// </summary>
        private bool WaitingTimerFunction()
        {
            if (associatedTimer.IsStopped || associatedTimer.IsPaused) // timer was stop
            {
                SettingStop();
                return false;
            }

            associatedTimer.Color = associatedTimer.WaitingColor;
            Current--;

            var res = ShouldContinueTimer(avoidZero: true);

            if (!res) // start timerFunction in the end of this function
            {
                currentMax = associatedTimer.Time;
                Current = associatedTimer.Time;
                UpdateColor();
                associatedTimer.IsWaitingTime = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            }
            return res;
        }

        /// <summary>
        /// function of the timer to make the time period
        /// </summary>
        private bool TimerFunction()
        {
            if (associatedTimer.IsStopped) // timer was stop
            {
                SettingStop();
                return false;
            }

            if (associatedTimer.IsPaused) // timer was paused
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
            associatedTimer.IsStopped = true;
            associatedTimer.IsPaused = false;
            Current = associatedTimer.Time;
            associatedTimer.Color = StopTimeColor;
        }

        /// <summary>
        /// function to update the color during the time period
        /// </summary>
        private void UpdateColor()
        {
            // general time
            if (Current > associatedTimer.LimitTime)
                associatedTimer.Color = Color.Green;
            // limit time
            else if (ShouldContinueTimer())
                associatedTimer.Color = LimitTimeColor;
            // stop time
            else
                associatedTimer.Color = StopTimeColor;
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

        #endregion private functions
    }
}
