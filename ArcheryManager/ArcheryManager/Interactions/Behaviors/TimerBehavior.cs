using System;
using Xamarin.Forms;
using ArcheryManager.CustomControls;
using ArcheryManager.Services;

namespace ArcheryManager.Interactions.Behaviors
{
    internal class TimerBehavior : CustomBehavior<CustomTimer>
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

        #region logical properties

        private int _current;
        private int _currentMax;

        /// <summary>
        /// current time to show
        /// </summary>
        private int Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
                associatedObject.Text = value.ToString();
                if (_currentMax != 0)
                {
                    associatedObject.Progress = _current * associatedObject.MaxProgress / _currentMax;
                }
                else
                {
                    associatedObject.Progress = 0;
                }
            }
        }

        #endregion logical properties

        private WaveControl _waveLabel;

        protected override void OnAttachedTo(CustomTimer bindable)
        {
            base.OnAttachedTo(bindable);
            _waveLabel = associatedObject.WaveControl;
        }

        #region public function

        public void Start()
        {
            if (!associatedObject.IsStopped)
                return;

            if (associatedObject.ShowWaitingTime)
            {
                StartWaitingFunction();
                PlaySong();
            }
            else
            {
                StartTimerFunction();
                PlaySong();
            }
        }

        private void StartWaitingFunction()
        {
            associatedObject.IsWaitingTime = true;
            associatedObject.IsStopped = false;
            associatedObject.IsPaused = false;
            _currentMax = associatedObject.WaitingTime;
            Current = associatedObject.WaitingTime;
            Device.StartTimer(TimeSpan.FromSeconds(1), WaitingTimerFunction);
        }

        public void Stop()
        {
            associatedObject.IsStopped = true;
            //TODO wait one second to be sure the current timer while stopped

            _waveLabel.NextWave();
            PlaySong();
        }

        private void PlaySong()
        {
            DependencyService.Get<IAudioPlayer>().PlayAudioFile("coq.mp3");
        }

        public void Pause()
        {
            associatedObject.IsPaused = true;
            //TODO wait one second to be sure the current timer while paused
        }

        public void Continue()
        {
            if (associatedObject.IsPaused && !associatedObject.IsStopped)
            {
                associatedObject.IsPaused = false;
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
            if (associatedObject.IsStopped || associatedObject.IsPaused) // timer was stop
            {
                SettingStop();
                return false;
            }

            associatedObject.Color = associatedObject.WaitingColor;
            Current--;

            var res = ShouldContinueTimer(avoidZero: true);

            if (!res) // start timerFunction in the end of this function
            {
                PlaySong();
                StartTimerFunction();
            }
            return res;
        }

        private void StartTimerFunction()
        {
            associatedObject.IsStopped = false;
            _currentMax = associatedObject.Time;
            Current = associatedObject.Time;
            UpdateColor();
            associatedObject.IsWaitingTime = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
        }

        /// <summary>
        /// function of the timer to make the time period
        /// </summary>
        private bool TimerFunction()
        {
            if (associatedObject.IsStopped) // timer was stop
            {
                SettingStop();
                return false;
            }

            if (associatedObject.IsPaused) // timer was paused
            {
                return false;
            }

            Current--;
            UpdateColor();

            var res = ShouldContinueTimer();
            if (!res) // stop the timer in the end of this function
            {
                SettingStop();
                _waveLabel.NextWave();
                PlaySong();
            }

            return res;
        }

        private void SettingStop()
        {
            associatedObject.IsStopped = true;
            associatedObject.IsPaused = false;
            Current = associatedObject.Time;
            associatedObject.Color = StopTimeColor;
        }

        /// <summary>
        /// function to update the color during the time period
        /// </summary>
        private void UpdateColor()
        {
            // general time
            if (Current > associatedObject.LimitTime)
                associatedObject.Color = Color.Green;
            // limit time
            else if (ShouldContinueTimer())
                associatedObject.Color = LimitTimeColor;
            // stop time
            else
                associatedObject.Color = StopTimeColor;
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
