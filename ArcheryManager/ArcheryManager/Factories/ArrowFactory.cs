using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public abstract class ArrowFactory
    {
        public IArrowSetting Setting { get; internal set; }

        public virtual Arrow Create(Point position)
        {
            string score = ScoreOf(position);
            int value = ValueByScore(score);
            Color color = ColorOf(score);
            var arrow = new Arrow(position, score, value, color);
            return arrow;
        }

        protected abstract Color ColorOf(string value);

        protected abstract int ValueByScore(string score);

        protected abstract string ScoreOf(Point position);
    }
}
