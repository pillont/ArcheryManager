using ArcheryManager.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;
using XFShapeView;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class TargetScoreCounter
    {
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

        private IList<Arrow> arrows;

        public ReadOnlyCollection<Arrow> Arrows
        {
            get
            {
                return new ReadOnlyCollection<Arrow>(arrows);
            }
        }

        public Color ArrowColor { get; private set; }

        public TargetScoreCounter()
        {
            arrows = new List<Arrow>();
        }

        public Arrow AddArrow(View visual, Score score)
        {
            var arrow = new Arrow(visual, score);
            arrows.Add(arrow);

            return arrow;
        }

        public IEnumerable<Arrow> CleanArrows()
        {
            var res = new List<Arrow>(arrows);
            arrows.Clear();
            return res;
        }

        internal Arrow RemoveLastArrow()
        {
            var res = arrows.Last();
            arrows.Remove(res);
            return res;
        }
    }
}
