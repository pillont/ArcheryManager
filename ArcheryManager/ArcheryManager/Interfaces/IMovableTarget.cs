using ArcheryManager.Factories;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.Interfaces
{
    public interface IMovableTarget
    {
        ArrowFactory Factory { get; }

        /// <summary>
        /// grid who content the target
        /// </summary>
        Grid TargetGrid { get; }

        /// <summary>
        /// arrow setter of the target
        /// </summary>
        ShapeView ArrowSetter { get; }

        int TargetSize { get; }
    }
}
