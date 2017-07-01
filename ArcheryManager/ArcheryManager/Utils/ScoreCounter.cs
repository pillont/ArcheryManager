using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        private const string NewFlightText = "New Flight";

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
        private readonly IList<ToolbarItem> toolbarItems;

        #endregion properties

        /// <summary>
        /// score counter with associated target
        /// </summary>
        /// <param name="setting"></param>
        public ScoreCounter(TargetSetting setting, IList<ToolbarItem> toolbarItems)// TODO : make FlightSetting ancestor of Target setting =>remove this ctor and change the second to accept FlightSetting
        {
            CurrentArrows = new ObservableCollection<Arrow>();
            AllArrows = new ObservableCollection<Arrow>();
            PreviousArrows = new ObservableCollection<Arrow>();

            this.toolbarItems = toolbarItems;
            this.setting = setting;

            setting.PropertyChanged += Setting_PropertyChanged;
        }

        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(setting.IsDecreasingOrder))
            {
                UpdateOrder();
            }
            else if (e.PropertyName == nameof(setting.HaveMaxArrowsCount)
                || e.PropertyName == nameof(setting.ArrowsCount))
            {
                RemoveNewFlightButton();
                AddNewFlightIfCanValidFlight();
            }
        }

        #region toolbar item

        public void AddDefaultToolbarItems()
        {
            toolbarItems.Add(new ToolbarItem()
            {
                Text = "Remove last",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(RemoveLastArrow)
            });

            toolbarItems.Add(new ToolbarItem()
            {
                Text = "Remove all",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(ClearArrows)
            });
        }

        private void AddNewFlightButton()
        {
            toolbarItems.Add(new ToolbarItem()
            {
                Text = NewFlightText,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(NewFlight),
            });
        }

        private bool ContainsNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            return button != null;
        }

        private ToolbarItem GetCurrentNewFlightButton()
        {
            return toolbarItems.Where(i => i.Text == NewFlightText).FirstOrDefault();
        }

        private void RemoveNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            if (button != null)
            {
                toolbarItems.Remove(button);
            }
        }

        #endregion toolbar item

        #region update when arrows change

        private void Arrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateAllArrow();
            UpdateLastArrow();
            UpdateTotal();

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddNewFlightIfCanValidFlight();
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove
                || e.Action == NotifyCollectionChangedAction.Reset)
            {
                RemoveNewFlightIfCantValidFlight();
            }
        }

        private void RemoveNewFlightIfCantValidFlight()
        {
            if (!CanValidFlight())
            {
                RemoveNewFlightButton();
            }
        }

        private void AddNewFlightIfCanValidFlight()
        {
            if (CanValidFlight())
            {
                if (!ContainsNewFlightButton())
                {
                    AddNewFlightButton();
                }
            }
        }

        private bool CanValidFlight()
        {
            return CurrentArrows.Count > 0 && (
                (!setting.HaveMaxArrowsCount) || CurrentArrows.Count >= setting.ArrowsCount);
        }

        public void UpdateOrder()
        {
            IEnumerable<Arrow> orderedList;
            if (setting.IsDecreasingOrder)
            {
                orderedList = CurrentArrows.OrderByDescending(a => a.Index).ToList();
            }
            else
            {
                orderedList = CurrentArrows.OrderBy(a => a.NumberInFlight).ToList();
            }

            CurrentArrows.Clear();
            foreach (var a in orderedList)
            {
                CurrentArrows.Add(a);
            }
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
            UpdateOrder();
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
