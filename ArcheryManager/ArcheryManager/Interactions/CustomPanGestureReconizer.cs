using System;
using Xamarin.Forms;

namespace ArcheryManager.Interactions
{
    public class CustomPanGestureReconizer : PanGestureRecognizer
    {
        public new event EventHandler<CustomPanUpdatedEventArgs> PanUpdated;

        private int countUpdate;

        private bool isCancel;

        private Point startPosition;

        /// <summary>
        /// start position of the pan
        /// Not sure if the move is very fast
        /// </summary>
        public Point StartTapPosition { get; set; }

        public CustomPanGestureReconizer()
        {
            base.PanUpdated += OnPanUpdated;
        }

        public void CancelGesture()
        {
            isCancel = true;
        }

        private void CallEventPanGesture(object sender, PanUpdatedEventArgs e)
        {
            var newArgs = new CustomPanUpdatedEventArgs(e.StatusType, e.GestureId, e.TotalX, e.TotalY, StartTapPosition);
            this.PanUpdated?.Invoke(sender, newArgs);
        }

        private void InitPanGesture(object sender, PanUpdatedEventArgs e)
        {
            StartTapPosition = default(Point);
            countUpdate = 0;
            isCancel = false;
        }

        /// <summary>
        /// logic of the pan gesture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    InitPanGesture(sender, e);
                    CallEventPanGesture(sender, e);
                    break;

                case GestureStatus.Running:
                    if (!isCancel)
                    {
                        UpdatePanGesture(sender, e);
                    }
                    break;

                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    if (!isCancel)
                    {
                        CallEventPanGesture(sender, e);
                    }
                    break;
            }
        }

        private void UpdatePanGesture(object sender, PanUpdatedEventArgs e)
        {
            CustomPanUpdatedEventArgs newArgs;
            countUpdate++;

            switch (countUpdate)
            {
                case 0:
                case 1:
                case 2:
                    break; //NOTE : remove the first update to avoid difference in position

                case 3:
                    startPosition = new Point(e.TotalX, e.TotalY);
                    StartTapPosition = new Point(-e.TotalX * 3.65, -e.TotalY * 3.65);
                    newArgs = new CustomPanUpdatedEventArgs(e.StatusType, e.GestureId, 0, 0, StartTapPosition);
                    break;

                default:
                    double transformX = e.TotalX - startPosition.X;
                    double transformY = e.TotalY - startPosition.Y;
                    newArgs = new CustomPanUpdatedEventArgs(e.StatusType, e.GestureId, transformX, transformY, StartTapPosition);
                    this.PanUpdated?.Invoke(sender, newArgs);
                    break;
            }
        }
    }
}
