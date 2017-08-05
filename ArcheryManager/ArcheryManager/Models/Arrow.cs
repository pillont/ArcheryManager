using Xamarin.Forms;

namespace ArcheryManager.Models
{
    public class Arrow : BindableObject
    {
        public static readonly BindableProperty IsSelectedProperty =
                      BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Arrow), false);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public int NumberInFlight { get; private set; }
        public double TranslationX { get; private set; }
        public double TranslationY { get; private set; }
        public double TargetSize { get; private set; }
        public int Index { get; private set; }

        public Arrow(int index, int numberInFlight, Point position, double targetSize)
            : this(index, numberInFlight)
        {
            TranslationX = position.X;
            TranslationY = position.Y;

            TargetSize = targetSize;
        }

        public Arrow(int index, int numberInFlight)
        {
            Index = index;
            NumberInFlight = numberInFlight;
        }
    }
}
