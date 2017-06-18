using System.Linq;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.Helpers
{
    public static class ArrowUniformGridHelper
    {
        /// <summary>
        /// function to get the shape of an arrow in uniform grid
        /// </summary>
        public static ShapeView ShapeOfArrow(View view)
        {
            var grid = view as Grid;
            var shape = grid.Children.First() as ShapeView;
            return shape;
        }

        /// <summary>
        /// function to get the text of an arrow in uniform grid
        /// </summary>
        public static Label LabelOfArrow(View view)
        {
            var grid = view as Grid;
            var lbl = grid.Children.Last() as Label;
            return lbl;
        }
    }
}
