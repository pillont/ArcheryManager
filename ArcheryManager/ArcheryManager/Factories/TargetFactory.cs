using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Settings;
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
        public static Target Create(IGeneralCounterSetting generalCounterSetting)
        {
            var countSetting = generalCounterSetting.CountSetting;
            var counter = generalCounterSetting.ScoreCounter;
            var arrowSetting = generalCounterSetting.ArrowSetting;

            var customTarget = new Target(generalCounterSetting) { MinimumHeightRequest = 1200, MinimumWidthRequest = 1200 };

            customTarget.ArrowGrid.Items = counter.CurrentArrows;
            customTarget.PreviousArrowGrid.Items = counter.PreviousArrows;

            var lastArrowsGrid = customTarget.PreviousArrowGrid;
            lastArrowsGrid.BindingContext = countSetting;
            lastArrowsGrid.SetBinding(View.IsVisibleProperty, nameof(CountSetting.ShowAllArrows));

            var average = customTarget.AverageCanvas;
            average.BindingContext = countSetting;
            average.SetBinding(View.IsVisibleProperty, nameof(CountSetting.AverageIsVisible));

            var behavior = new MovableTargetBehavior(generalCounterSetting);
            customTarget.Behaviors.Add(behavior);

            return customTarget;
        }
    }
}
