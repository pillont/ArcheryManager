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
        public IArrowSetting Setting { get; private set; }
        public int Index { get; private set; }

        public string Score
        {
            get
            {
                return Setting.ScoreByIndex(Index);
            }
        }

        public int Value
        {
            get
            {
                return Setting.ValueByScore(Score);
            }
        }

        public Color Color
        {
            get
            {
                return Setting.ColorOf(Score);
            }
        }

        public Arrow(int index, int numberInFlight, Point position, double targetSize, IArrowSetting setting)
            : this(index, numberInFlight, setting)
        {
            TranslationX = position.X;
            TranslationY = position.Y;

            TargetSize = targetSize;
        }

        public Arrow(int index, int numberInFlight, IArrowSetting setting)
        {
            Index = index;
            NumberInFlight = numberInFlight;
            Setting = setting;
        }
    }
}
