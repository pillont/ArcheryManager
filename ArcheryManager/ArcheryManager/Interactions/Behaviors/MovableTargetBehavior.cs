using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class MovableTargetBehavior : CustomBehavior<Target>
    {
        /// <summary>
        /// scale of the target during manipulation to set arrow
        /// </summary>
        public const double TargetScale = 1.35;

        /// <summary>
        /// rate of the target translation during manipulation to set arrow
        /// </summary>
        public const double TargetTranslationRate = -0.3;

        /// <summary>
        /// score counter where add new arrows
        /// </summary>
        private ScoreCounter counter;

        /// <summary>
        /// behavior to add interaction of pan on movable target
        /// </summary>
        /// <param name="counter">score counter where add new arrows</param>
        public MovableTargetBehavior(ScoreCounter counter)
        {
            this.counter = counter;
        }

        protected override void OnAttachedTo(Target bindable)
        {
            base.OnAttachedTo(bindable);

            GestureHelper.AddPanGestureOn(associatedObject.TargetGrid, OnPanUpdated);
        }

        /// <summary>
        /// logic of the pan gesture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPanUpdated(object sender, CustomPanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    StartPanGesture(sender, e);
                    break;

                case GestureStatus.Running:
                    UpdatePanGesture(sender, e);
                    break;

                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    EndPanGesture(sender, e);
                    break;
            }
        }

        /// <summary>
        /// function during end of the pan manipulations
        /// scale and translation reset / arrow setter not visible
        /// </summary>
        private void EndPanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            associatedObject.TargetGrid.Scale = 1;

            var position = new Point(associatedObject.ArrowSetter.TranslationX,
                                        associatedObject.ArrowSetter.TranslationY);

            var numberInFlight = counter.CurrentArrows.Count;
            var arrow = associatedObject.Factory.Create(position, numberInFlight);
            counter.AddArrow(arrow);

            associatedObject.TargetGrid.TranslationX = 0;
            associatedObject.TargetGrid.TranslationY = 0;

            associatedObject.ArrowSetter.TranslationX = 0;
            associatedObject.ArrowSetter.TranslationY = 0;

            associatedObject.ArrowSetter.IsVisible = false;
        }

        /// <summary>
        /// function during update of the pan munipulations
        /// translation update
        /// </summary>
        private void UpdatePanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            associatedObject.TargetGrid.TranslationX = e.TotalX * TargetTranslationRate;
            associatedObject.TargetGrid.TranslationY = e.TotalY * TargetTranslationRate;

            associatedObject.ArrowSetter.TranslationX = e.TotalX;
            associatedObject.ArrowSetter.TranslationY = e.TotalY;
        }

        /// <summary>
        /// function during start of the pan munipulations
        /// scale on the target / arrow setter visible
        /// </summary>
        private void StartPanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            associatedObject.TargetGrid.TranslationX = 0;
            associatedObject.TargetGrid.TranslationY = 0;

            associatedObject.ArrowSetter.TranslationX = 0;
            associatedObject.ArrowSetter.TranslationY = 0;

            associatedObject.ArrowSetter.IsVisible = true;
            associatedObject.TargetGrid.Scale = TargetScale;
        }
    }
}
