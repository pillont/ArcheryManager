using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface ITargetWithInteraction
    {
        /// <summary>
        /// add new arrow
        /// </summary>
        /// <param name="position"></param>
        void AddArrow(Point position);

        /// <summary>
        ///clean the arrows in the target
        /// </summary>
        void ClearArrows();

        /// <summary>
        /// remove last arrow added
        /// </summary>
        void RemoveLastArrow();
    }
}
