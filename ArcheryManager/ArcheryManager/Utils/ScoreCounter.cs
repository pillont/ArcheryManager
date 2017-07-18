using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ArcheryManager.Resources;
using ArcheryManager.Interfaces;
using System;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        public readonly IArrowSetting ArrowSetting;
        private const string NewFlightText = "New Flight";
        private const string ScoreFormat = "{0}/{1}";

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
            private set
            {
                SetValue(FlightScoreProperty, value);
                OnPropertyChanged(nameof(FlightScoreString));
            }
        }

        public string FlightScoreString
        {
            get
            {
                return ScoreString(FlightScore, CurrentArrows);
            }
        }

        public static readonly BindableProperty TotalScoreProperty =
                      BindableProperty.Create(nameof(TotalScore), typeof(int), typeof(ScoreCounter), 0);

        public int TotalScore
        {
            get { return (int)GetValue(TotalScoreProperty); }
            private set
            {
                SetValue(TotalScoreProperty, value);
                OnPropertyChanged(nameof(TotalScoreString));
            }
        }

        public string TotalScoreString
        {
            get
            {
                return ScoreString(TotalScore, AllArrows);
            }
        }

        private string ScoreString(int score, ObservableCollection<Arrow> arrows)
        {
            int maxScore = arrows.Count * ArrowSetting.MaxScore;
            return string.Format(ScoreFormat, score, maxScore);
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
        public ScoreCounter(TargetSetting setting, IList<ToolbarItem> toolbarItems, IArrowSetting ArrowSetting)// TODO : make FlightSetting ancestor of Target setting =>remove this ctor and change the second to accept FlightSetting
        {
            this.ArrowSetting = ArrowSetting;
            CurrentArrows = new ObservableCollection<Arrow>();
            AllArrows = new ObservableCollection<Arrow>();
            PreviousArrows = new ObservableCollection<Arrow>();

            this.toolbarItems = toolbarItems;
            this.setting = setting;

            setting.PropertyChanged += Setting_PropertyChanged;
            setting.CountSetting.PropertyChanged += CountSetting_PropertyChanged;
        }

        private void CountSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(setting.CountSetting.HaveMaxArrowsCount)
                || e.PropertyName == nameof(setting.CountSetting.ArrowsCount))
            {
                RemoveNewFlightButton();
                AddNewFlightIfCanValidFlight();
            }
        }

        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(setting.IsDecreasingOrder))
            {
                UpdateOrder();
            }
        }

        #region toolbar item

        public void AddDefaultToolbarItems()
        {
            toolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.RemoveLast,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(RemoveLastArrow)
            });

            toolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.RemoveAll,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => AskValidation(AppResources.RemoveAllQuestion, ClearArrows))
            });

            toolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.Restart,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => AskValidation(AppResources.RestartQuestion, RestartCount))
            });
        }

        private void AddNewFlightButton()
        {
            toolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.NewFlight,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => AskValidation(AppResources.NewFlightQuestion, NewFlight)),
            });
        }

        private bool ContainsNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            return button != null;
        }

        private ToolbarItem GetCurrentNewFlightButton()
        {
            string newFlightText = AppResources.NewFlight;
            return toolbarItems.Where(i => i.Text == newFlightText).FirstOrDefault();
        }

        private void RemoveNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            if (button != null)
            {
                toolbarItems.Remove(button);
            }
        }

        private async void AskValidation(string message, Action action)
        {
            var valid = await App.NavigationPage.DisplayAlert(AppResources.Question, message, AppResources.Yes, AppResources.No);
            if (valid)
            {
                action?.Invoke();
            }
        }

        #endregion toolbar item

        #region update when arrows change

        private void Arrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateAllArrow();
            UpdatePreviousArrow();
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
                (!setting.CountSetting.HaveMaxArrowsCount)
                || CurrentArrows.Count >= setting.CountSetting.ArrowsCount);
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

        private void UpdatePreviousArrow()
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
                FlightScore += ValueOf(a);
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

        public void RestartCount()
        {
            lastTotal = 0;
            FlightsSaved.Clear();
            CurrentArrows.Clear();
            UpdatePreviousArrow();
            UpdateAllArrow();
            UpdateTotal();
        }

        public void NewFlight()
        {
            FlightsSaved.Add(new Flight(CurrentArrows) { Number = FlightsSaved.Count + 1 });

            lastTotal += FlightScore;
            FlightScore = 0;
            CurrentArrows.Clear();
        }

        public void AddArrow(Arrow arrow)
        {
            bool canAddArrow = (!setting.CountSetting.HaveMaxArrowsCount) ||
                                CurrentArrows.Count < setting.CountSetting.ArrowsCount;
            if (canAddArrow)
            {
                CurrentArrows?.Add(arrow);
                UpdateOrder();
            }
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

        private string ScoreOf(Arrow a)
        {
            return ArrowSetting.ScoreByIndex(a.Index);
        }

        private int ValueOf(Arrow a)
        {
            return ArrowSetting.ValueByScore(ScoreOf(a));
        }

        private Color ColorOf(Arrow a)
        {
            return ArrowSetting.ColorOf(ScoreOf(a));
        }
    }
}
