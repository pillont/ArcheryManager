using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.Interfaces
{
    public interface ITarget
    {
        /// <summary>
        /// grid who content the target
        /// </summary>
        Grid TargetGrid { get; }

        /// <summary>
        /// arrow setter of the target
        /// </summary>
        ShapeView ArrowSetter { get; }

        /// <summary>
        /// add new arrow
        /// </summary>
        /// <param name="position"></param>
        void AddArrow(Point position);

        /// <summary>
        ///clean the arrows in the target
        /// </summary>
        void CleanArrows();

        /// <summary>
        /// remove last arrow added
        /// </summary>
        void RemoveLastArrow();
    }
}
