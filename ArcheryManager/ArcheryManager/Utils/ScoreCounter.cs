using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using ArcheryManager.Factories;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
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

        private readonly ArrowFactory arrowFactory;
        private int lastTotal = 0;

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

        internal void NewFlight()
        {
            lastTotal += Flight;
            Flight = 0;
            Arrows.Clear();
        }

        public ScoreCounter(ArrowFactory arrowFactory)
        {
            this.arrowFactory = arrowFactory;
            Arrows = new ObservableCollection<Arrow>();
        }

        private void Arrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Flight = 0;
            foreach (var a in Arrows)
            {
                Flight += a.Value;
            }

            Total = lastTotal;
            Total += Flight;
        }

        public void AddArrow(Point position)
        {
            Arrow arrow = arrowFactory.Create(position);

            Arrows?.Add(arrow);
        }

        public void ClearArrows()
        {
            Arrows?.Clear();
        }

        public void RemoveLastArrow()
        {
            var res = Arrows.LastOrDefault();
            if (res != null)
                Arrows.Remove(res);
        }
    }
}
