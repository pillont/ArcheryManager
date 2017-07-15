using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class TargetFactory
    {
        /// <summary>
        /// create Target
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="targetSetting"></param>
        /// <param name="arrowSetting"></param>
        /// <returns></returns>
        public static Target Create(ScoreCounter counter, TargetSetting targetSetting)
        {
            var customTarget = new Target() { MinimumHeightRequest = 1200, MinimumWidthRequest = 1200 };

            customTarget.ArrowGrid.Items = counter.CurrentArrows;
            customTarget.PreviousArrowGrid.Items = counter.PreviousArrows;

            var lastArrowsGrid = customTarget.PreviousArrowGrid;
            lastArrowsGrid.BindingContext = targetSetting;
            lastArrowsGrid.SetBinding(View.IsVisibleProperty, nameof(TargetSetting.ShowAllArrows));

            var average = customTarget.AverageCanvas;
            average.BindingContext = targetSetting;
            average.SetBinding(View.IsVisibleProperty, nameof(TargetSetting.AverageIsVisible));
            average.Counter = counter;
            customTarget.Setting = counter.ArrowSetting;

            var behavior = new MovableTargetBehavior(counter, targetSetting);
            customTarget.Behaviors.Add(behavior);

            return customTarget;
        }
    }
}
