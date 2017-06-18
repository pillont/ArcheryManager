using Xamarin.Forms;

namespace ArcheryManager.Interactions
{
    public class CustomPanUpdatedEventArgs : PanUpdatedEventArgs
    {
        public Point StartPoint { get; private set; }

        public CustomPanUpdatedEventArgs(GestureStatus type, int gestureId)
            : base(type, gestureId)
        {
        }

        public CustomPanUpdatedEventArgs(GestureStatus type, int gestureId, double totalx, double totaly, Point startPoint)
            : base(type, gestureId, totalx, totaly)
        {
            StartPoint = startPoint;
        }
    }
}
