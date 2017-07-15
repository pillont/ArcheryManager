using ArcheryManager.Interfaces;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class Arrow
    {
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
