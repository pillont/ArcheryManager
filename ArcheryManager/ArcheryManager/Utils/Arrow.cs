using Xamarin.Forms;
using static ArcheryManager.Utils.TargetScoreCounter;

namespace ArcheryManager.Utils
{
    public class Arrow
    {
        public double TranslationX { get; private set; }
        public double TranslationY { get; private set; }
        public Score ScoreArrow { get; private set; }
        public Color Color { get; private set; }

        public Arrow(double translationX, double translationY, Score score, Color color)
        {
            TranslationX = translationX;
            TranslationY = translationY;
            ScoreArrow = score;
            Color = color;
        }

        public enum Score
        {
            Miss = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Height = 8,
            Nine = 9,
            Ten = 10,
            XTen = 11,
        }
    }
}
