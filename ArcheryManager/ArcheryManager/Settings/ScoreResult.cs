using ArcheryManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ArcheryManager.Settings
{
    public class ScoreResult : BindableObject
    {
        public event Action ArrowsChanged;

        public void OnArrowsChanged()
        {
            ArrowsChanged?.Invoke();
        }

        #region Arrows list

        public static readonly BindableProperty LastTotalProperty =
                      BindableProperty.Create(nameof(LastTotal), typeof(int), typeof(ScoreResult), 0);

        public int LastTotal
        {
            get { return (int)GetValue(LastTotalProperty); }
            set { SetValue(LastTotalProperty, value); }
        }

        public static readonly BindableProperty FlightSavedProperty =
                      BindableProperty.Create(nameof(FlightsSaved), typeof(List<Flight>), typeof(ScoreResult), null);

        public List<Flight> FlightsSaved
        {
            get { return (List<Flight>)GetValue(FlightSavedProperty); }
            private set { SetValue(FlightSavedProperty, value); }
        }

        public static readonly BindableProperty CurrentArrowsProperty =
                      BindableProperty.Create(nameof(CurrentArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreResult), null);

        public ObservableCollection<Arrow> CurrentArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(CurrentArrowsProperty); }
            set { SetValue(CurrentArrowsProperty, value); }
        }

        public static readonly BindableProperty PreviousArrowsProperty =
                      BindableProperty.Create(nameof(PreviousArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreResult), null);

        public ObservableCollection<Arrow> PreviousArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(PreviousArrowsProperty); }
            set { SetValue(PreviousArrowsProperty, value); }
        }

        public static readonly BindableProperty AllArrowsProperty =
                      BindableProperty.Create(nameof(AllArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreResult), null);

        public ObservableCollection<Arrow> AllArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(AllArrowsProperty); }
            set { SetValue(AllArrowsProperty, value); }
        }

        #endregion Arrows list

        public static readonly BindableProperty FlightScoreProperty =
                      BindableProperty.Create(nameof(FlightScore), typeof(int), typeof(ScoreResult), 0);

        public int FlightScore
        {
            get { return (int)GetValue(FlightScoreProperty); }
            set
            {
                SetValue(FlightScoreProperty, value);
            }
        }

        public static readonly BindableProperty TotalScoreProperty =
                      BindableProperty.Create(nameof(TotalScore), typeof(int), typeof(ScoreResult), 0);

        public int TotalScore
        {
            get { return (int)GetValue(TotalScoreProperty); }
            set
            {
                SetValue(TotalScoreProperty, value);
            }
        }

        public ScoreResult()
        {
            CurrentArrows = new ObservableCollection<Arrow>();
            AllArrows = new ObservableCollection<Arrow>();
            PreviousArrows = new ObservableCollection<Arrow>();

            FlightsSaved = new List<Flight>();
        }
    }
}
