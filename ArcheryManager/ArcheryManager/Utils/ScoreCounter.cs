using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        #region properties

        #region Arrows list

        public static readonly BindableProperty CurrentArrowsProperty =
                      BindableProperty.Create(nameof(CurrentArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        public ObservableCollection<Arrow> CurrentArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(CurrentArrowsProperty); }
            private set
            {
                if (CurrentArrows != null)
                {
                    CurrentArrows.CollectionChanged -= Arrows_CollectionChanged;
                }

                SetValue(CurrentArrowsProperty, value);
                value.CollectionChanged += Arrows_CollectionChanged;
            }
        }

        public ObservableCollection<Arrow> ArrowsShowed
        {
            get
            {
                if (setting.ShowAllArrows)
                {
                    return AllArrows;
                }
                else
                {
                    return CurrentArrows;
                }
            }
        }

        public static readonly BindableProperty PreviousArrowsProperty =
                      BindableProperty.Create(nameof(PreviousArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        public ObservableCollection<Arrow> PreviousArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(PreviousArrowsProperty); }
            set { SetValue(PreviousArrowsProperty, value); }
        }

        public static readonly BindableProperty AllArrowsProperty =
                      BindableProperty.Create(nameof(AllArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        public ObservableCollection<Arrow> AllArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(AllArrowsProperty); }
            set { SetValue(AllArrowsProperty, value); }
        }

        #endregion Arrows list

        #region bindable prop

        public static readonly BindableProperty FlightScoreProperty =
                      BindableProperty.Create(nameof(FlightScore), typeof(int), typeof(ScoreCounter), 0);

        public int FlightScore
        {
            get { return (int)GetValue(FlightScoreProperty); }
            private set { SetValue(FlightScoreProperty, value); }
        }

        public static readonly BindableProperty TotalScoreProperty =
                      BindableProperty.Create(nameof(TotalScore), typeof(int), typeof(ScoreCounter), 0);

        public int TotalScore
        {
            get { return (int)GetValue(TotalScoreProperty); }
            private set { SetValue(TotalScoreProperty, value); }
        }

        #endregion bindable prop

        private readonly List<Flight> FlightsSaved = new List<Flight>();

        private int lastTotal = 0;
        private readonly TargetSetting setting;

        #endregion properties

        /// <summary>
        /// counter without target
        /// example : buttons page
        /// </summary>
        public ScoreCounter() // TODO : make FlightSetting ancestor of Target setting =>remove this ctor and change the second to accept FlightSetting
        {
            CurrentArrows = new ObservableCollection<Arrow>();
            AllArrows = new ObservableCollection<Arrow>();
            PreviousArrows = new ObservableCollection<Arrow>();
        }

        /// <summary>
        /// score counter with associated target
        /// </summary>
        /// <param name="setting"></param>
        public ScoreCounter(TargetSetting setting)
            : this()
        {
            this.setting = setting;
        }

        #region toolbar item

        public List<ToolbarItem> AssociatedToolbarItem
        {
            get
            {
                return new List<ToolbarItem>()
                {
                    new ToolbarItem()
                    {
                        Text = "Remove last",
                        Order = ToolbarItemOrder.Primary,
                        Command = new Command(RemoveLastArrow)
                    },

                    new ToolbarItem()
                    {
                        Text = "Remove all",
                        Order = ToolbarItemOrder.Primary,
                        Command = new Command(ClearArrows)
                    },

                    new ToolbarItem()
                    {
                        Text = "New Flight",
                        Order = ToolbarItemOrder.Primary,
                        Command = new Command(NewFlight)
                    },
                };
            }
        }

        #endregion toolbar item

        #region update when arrows change

        private void Arrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateAllArrow();
            UpdateLastArrow();
            UpdateTotal();
        }

        private void UpdateLastArrow()
        {
            var all = GetArrows(getCurrent: false);

            PreviousArrows.Clear();

            foreach (var a in all)
            {
                PreviousArrows.Add(a);
            }
        }

        private void UpdateTotal()
        {
            FlightScore = 0;
            foreach (var a in CurrentArrows)
            {
                FlightScore += a.Value;
            }

            TotalScore = lastTotal;
            TotalScore += FlightScore;
        }

        #endregion update when arrows change

        #region AllArrow

        private void UpdateAllArrow()
        {
            var all = GetArrows(getCurrent: true);

            AllArrows.Clear();

            foreach (var a in all)
            {
                AllArrows.Add(a);
            }
        }

        private List<Arrow> GetArrows(bool getCurrent)
        {
            List<Arrow> all;
            if (getCurrent)
            {
                all = new List<Arrow>(CurrentArrows);
            }
            else
            {
                all = new List<Arrow>();
            }

            foreach (var f in FlightsSaved)
            {
                all.AddRange(f);
            }

            return all;
        }

        #endregion AllArrow

        #region interaction

        public void NewFlight()
        {
            FlightsSaved.Add(new Flight(CurrentArrows) { Number = FlightsSaved.Count + 1 });

            lastTotal += FlightScore;
            FlightScore = 0;
            CurrentArrows.Clear();
        }

        public void AddArrow(Arrow arrow)
        {
            CurrentArrows?.Add(arrow);
        }

        public void ClearArrows()
        {
            CurrentArrows?.Clear();
        }

        public void RemoveLastArrow()
        {
            if (CurrentArrows.Count > 0)
            {
                CurrentArrows.RemoveAt(CurrentArrows.Count - 1);
            }
        }

        #endregion interaction
    }
}
