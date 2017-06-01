using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : BindableObject
    {
        public static readonly BindableProperty ArrowsProperty =
                      BindableProperty.Create(nameof(Arrows), typeof(ObservableCollection<Arrow>), typeof(ScoreCounter), null);

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

        public Color ArrowColor { get; private set; }

        public ScoreCounter()
        {
            Arrows = new ObservableCollection<Arrow>();
        }

        private void Arrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        public void AddArrow(Arrow a)
        {
            Arrows?.Add(a);
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
