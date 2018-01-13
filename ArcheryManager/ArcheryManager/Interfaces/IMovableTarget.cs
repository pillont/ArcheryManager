using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.Interfaces
{
    public interface IMovableTarget
    {
        /// <summary>
        /// arrow setter of the target
        /// </summary>
        ShapeView ArrowSetter { get; }

        /// <summary>
        /// grid who content the target
        /// </summary>
        Grid TargetGrid { get; }

        double TargetSize { get; }
    }
}
