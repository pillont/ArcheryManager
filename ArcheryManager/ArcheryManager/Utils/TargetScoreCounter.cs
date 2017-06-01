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
        private IList<Arrow> arrows;

        public ReadOnlyCollection<Arrow> Arrows
        {
            get
            {
                return new ReadOnlyCollection<Arrow>(arrows);
            }
        }

        public Color ArrowColor { get; private set; }

        public TargetScoreCounter(IList<Arrow> list)
        {
            arrows = list;
        }

        public void AddArrow(Arrow arrow)
        {
            arrows.Add(arrow);
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
