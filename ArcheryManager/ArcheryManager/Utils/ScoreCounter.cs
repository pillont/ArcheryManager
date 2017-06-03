using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using ArcheryManager.Factories;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        public static readonly BindableProperty ArrowsProperty =
                      BindableProperty.Create(nameof(Arrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

        private readonly ArrowFactory arrowFactory;

        public ObservableCollection<Arrow> Arrows
        {
            get { return (ObservableCollection<Arrow>)GetValue(ArrowsProperty); }
            set
            {
                if (Arrows != null)
                {
                    Arrows.CollectionChanged -= Arrows_CollectionChanged;
                }

                SetValue(ArrowsProperty, value);
                value.CollectionChanged += Arrows_CollectionChanged;
            }
        }

        public ScoreCounter(ArrowFactory arrowFactory)
        {
            this.arrowFactory = arrowFactory;
            Arrows = new ObservableCollection<Arrow>();
        }

        private void Arrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        public void AddArrow(Point position)
        {
            Arrow arrow = arrowFactory.Create(position);

            Arrows?.Add(arrow);
        }

        public void ClearArrow()
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
