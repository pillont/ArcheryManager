using ArcheryManager.Resources;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class TimerPageSetting : BindableObject
    {
        public static readonly Dictionary<string, string> AllSongFiles = new Dictionary<string, string>
        {
            {    AppResources.Coq , coqFileName },
            {    AppResources.Duck, DuckFileName },
            {    AppResources.EndPoint,EndPointFileName },
            {    AppResources.NotKiddin,NotKiddingFileName },
            {    AppResources.Strike,StrikeFileName },
            {    AppResources.Train,TrainFileName },
        };

        public static readonly BindableProperty ModeProperty =
                      BindableProperty.Create(nameof(Mode), typeof(string), typeof(TimerPageSetting), string.Empty);

        public static readonly BindableProperty SongFileNameProperty =
                          BindableProperty.Create(nameof(SongFileName), typeof(string), typeof(TimerPageSetting), DefaultSongFileName);

        public static readonly BindableProperty TimeProperty =
                      BindableProperty.Create(nameof(Time), typeof(int), typeof(TimerPageSetting), DefaultTime);

        public static readonly List<string> TimerModes = new List<string>
        {
            AppResources.ABC,
            AppResources.ABCD,
            AppResources.Duel,
            AppResources.ShootOut,
        };

        public static readonly BindableProperty WaitingTimeProperty =
                      BindableProperty.Create(nameof(WaitingTime), typeof(int), typeof(TimerPageSetting), DefaultWaitingTime);

        private const string coqFileName = "coq.mp3";
        private const string DefaultSongFileName = coqFileName;
        private const int DefaultTime = 120;
        private const int DefaultWaitingTime = 10;
        private const string DuckFileName = "duck.mp3";
        private const string EndPointFileName = "end_point.mp3";
        private const string NotKiddingFileName = "not_kiddin.mp3";
        private const string StrikeFileName = "strike.mp3";
        private const string TrainFileName = "train.mp3";

        public static List<string> AllSongFilesNames
        {
            get
            {
                return AllSongFiles.Keys.ToList();
            }
        }

        public string Mode
        {
            get { return (string)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public string SongFileName
        {
            get { return (string)GetValue(SongFileNameProperty); }
            set { SetValue(SongFileNameProperty, value); }
        }

        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public int WaitingTime
        {
            get { return (int)GetValue(WaitingTimeProperty); }
            set { SetValue(WaitingTimeProperty, value); }
        }

        public TimerPageSetting()
        {
            Mode = AppResources.ABC;
        }
    }
}
