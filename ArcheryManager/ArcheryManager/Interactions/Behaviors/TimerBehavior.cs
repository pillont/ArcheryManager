using ArcheryManager.CustomControls;
using ArcheryManager.Services;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    internal class TimerBehavior : CustomBehavior<CustomTimer>
    {
        /*
         * Times
         */
        public const int DefaultLimitTime = 30;
        public const int DefaultTime = 120;
        public const int DefaultWaitingTime = 10;
        /*
         * Colors
         */
        public static readonly Color DefaultBorderColor = Color.Gray;
        public static readonly Color DefaultColor = Color.Red;
        public static readonly Color DefaultProgressBorderColor = Color.Gray;
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
        private bool _playSong;

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
                AssociatedObject.Text = value.ToString();
                if (_currentMax != 0)
                {
                    AssociatedObject.Progress = _current * AssociatedObject.MaxProgress / _currentMax;
                }
                else
                {
                    AssociatedObject.Progress = 0;
                }
            }
        }

        #endregion logical properties

        private readonly TimerPageSetting Setting;

        private WaveBehavior _waveBehavior;

        public TimerBehavior(TimerPageSetting setting)
        {
            this.Setting = setting;
        }

        protected override void OnAttachedTo(CustomTimer bindable)
        {
            base.OnAttachedTo(bindable);
            _waveBehavior = AssociatedObject.WaveBehavior;
        }

        #region public function

        public void Continue()
        {
            if (AssociatedObject.IsPaused && !AssociatedObject.IsStopped)
            {
                AssociatedObject.IsPaused = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            }
        }

        public void Pause()
        {
            AssociatedObject.IsPaused = true;
            //TODO wait one second to be sure the current timer while paused
        }

        public void PlaySong()
        {
            string songFileName = Setting.SongFileName;
            DependencyService.Get<IAudioPlayer>().PlayAudioFile(songFileName);
        }

        public void Start()
        {
            if (AssociatedObject.IsStopped)
            {
                if (AssociatedObject.ShowWaitingTime)
                {
                    StartWaitingFunction();
                }
                else
                {
                    StartTimerFunction();
                }
            }
        }

        public void Stop(bool playSong = true)
        {
            _playSong = playSong;
            AssociatedObject.IsStopped = true;
            //TODO wait one second to be sure the current timer while stopped

            _waveBehavior.NextWave();
        }

        private void PlaySongIfNeeded()
        {
            if (_playSong)
            {
                PlaySong();
            }
        }

        private void StartWaitingFunction()
        {
            _playSong = true;
            AssociatedObject.IsWaitingTime = true;
            AssociatedObject.IsStopped = false;
            AssociatedObject.IsPaused = false;
            _currentMax = AssociatedObject.WaitingTime;
            this.Current = AssociatedObject.WaitingTime;
            Device.StartTimer(TimeSpan.FromSeconds(1), WaitingTimerFunction);
            PlaySongIfNeeded();
        }

        #endregion public function

        #region private functions

        private void SettingStop()
        {
            AssociatedObject.IsStopped = true;
            AssociatedObject.IsPaused = false;
            this.Current = AssociatedObject.Time;
            AssociatedObject.Color = StopTimeColor;
        }

        /// <summary>
        /// function to know if the timer must stop of not
        /// </summary>
        /// <returns></returns>
        private bool ShouldContinueTimer(bool avoidZero = false)
        {
            if (avoidZero)
                return this.Current > 0; // end of the timer
            else
                return this.Current >= 0; // end of the timer
        }

        private void StartTimerFunction()
        {
            _playSong = true;
            AssociatedObject.IsStopped = false;
            _currentMax = AssociatedObject.Time;
            this.Current = AssociatedObject.Time;
            UpdateColor();
            AssociatedObject.IsWaitingTime = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerFunction);
            PlaySongIfNeeded();
        }

        /// <summary>
        /// function of the timer to make the time period
        /// </summary>
        private bool TimerFunction()
        {
            if (AssociatedObject.IsStopped) // timer was stop
            {
                SettingStop();
                PlaySongIfNeeded();
                return false;
            }

            if (AssociatedObject.IsPaused) // timer was paused
            {
                return false;
            }

            this.Current--;
            UpdateColor();

            var res = ShouldContinueTimer();
            if (!res) // stop the timer in the end of this function
            {
                SettingStop();

                _waveBehavior.NextWave();
                PlaySongIfNeeded();
            }

            return res;
        }

        /// <summary>
        /// function to update the color during the time period
        /// </summary>
        private void UpdateColor()
        {
            // general time
            if (this.Current > AssociatedObject.LimitTime)
                AssociatedObject.Color = Color.Green;
            // limit time
            else if (ShouldContinueTimer())
                AssociatedObject.Color = LimitTimeColor;
            // stop time
            else
                AssociatedObject.Color = StopTimeColor;
        }

        /// <summary>
        /// function of the timer to make the waiting period
        /// </summary>
        private bool WaitingTimerFunction()
        {
            if (AssociatedObject.IsStopped || AssociatedObject.IsPaused) // timer was stop
            {
                SettingStop();
                PlaySongIfNeeded();
                return false;
            }

            AssociatedObject.Color = AssociatedObject.WaitingColor;
            this.Current--;

            bool res = ShouldContinueTimer(avoidZero: true);

            if (!res) // start timerFunction in the end of this function
            {
                PlaySongIfNeeded();
                StartTimerFunction();
            }
            return res;
        }

        #endregion private functions
    }
}
