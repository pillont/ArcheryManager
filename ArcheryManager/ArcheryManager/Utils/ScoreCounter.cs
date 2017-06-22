using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using XFShapeView;
using System;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        #region properties

        #region bindable prop

        public static readonly BindableProperty AllArrowsProperty =
                      BindableProperty.Create(nameof(AllArrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        public ObservableCollection<Arrow> AllArrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(AllArrowsProperty); }
            set { SetValue(AllArrowsProperty, value); }
        }

        private readonly List<Flight> FlightsSaved = new List<Flight>();

        public static readonly BindableProperty FlightProperty =
                      BindableProperty.Create(nameof(Flight), typeof(int), typeof(ScoreCounter), 0);

        public int Flight
        {
            get { return (int)GetValue(FlightProperty); }
            private set { SetValue(FlightProperty, value); }
        }

        public static readonly BindableProperty TotalProperty =
                      BindableProperty.Create(nameof(Total), typeof(int), typeof(ScoreCounter), 0);

        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            private set { SetValue(TotalProperty, value); }
        }

        public static readonly BindableProperty ArrowsProperty =
                      BindableProperty.Create(nameof(Arrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        public ObservableCollection<Arrow> Arrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(ArrowsProperty); }
            private set
            {
                if (Arrows != null)
                {
                    Arrows.CollectionChanged -= Arrows_CollectionChanged;
                }

                SetValue(ArrowsProperty, value);
                value.CollectionChanged += Arrows_CollectionChanged;
            }
        }

        #endregion bindable prop

        private int lastTotal = 0;

        #endregion properties

        public ScoreCounter()
        {
            Arrows = new ObservableCollection<Arrow>();
            AllArrows = new ObservableCollection<Arrow>();
        }

        #region toolbar item

        public List<ToolbarItem> AssociatedToolbarItem()
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

        #endregion toolbar item

        #region update when arrows change

        private void Arrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateTotal();
            UpdateAllArrow();
        }

        private void UpdateTotal()
        {
            Flight = 0;
            foreach (var a in Arrows)
            {
                Flight += a.Value;
            }

            Total = lastTotal;
            Total += Flight;
        }

        #endregion update when arrows change

        #region AllArrow

        private void UpdateAllArrow()
        {
            var all = GetAllArrow();

            AllArrows.Clear();

            foreach (var a in all)
            {
                AllArrows.Add(a);
            }
        }

        private List<Arrow> GetAllArrow()
        {
            var all = new List<Arrow>(Arrows);
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
            FlightsSaved.Add(new Flight(Arrows) { Number = FlightsSaved.Count + 1 });

            lastTotal += Flight;
            Flight = 0;
            Arrows.Clear();
        }

        public void AddArrow(Arrow arrow)
        {
            Arrows?.Add(arrow);
        }

        public void ClearArrows()
        {
            Arrows?.Clear();
        }

        public void RemoveLastArrow()
        {
            if (Arrows.Count > 0)
            {
                Arrows.RemoveAt(Arrows.Count - 1);
            }
        }

        #endregion interaction
    }
}
