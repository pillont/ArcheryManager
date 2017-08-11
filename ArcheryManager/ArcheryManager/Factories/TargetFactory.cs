using System;
using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Settings;
using Xamarin.Forms;
using System.ComponentModel;

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
        public static Target Create(IGeneralCounterSetting generalCounterSetting, ScoreCounter counter, View gestureMoveTarget)
        {
            var countSetting = generalCounterSetting.CountSetting;
            var result = generalCounterSetting.ScoreResult;
            var arrowSetting = generalCounterSetting.ArrowSetting;

            var customTarget = new Target() { MinimumHeightRequest = 1200, MinimumWidthRequest = 1200 };

            customTarget.ArrowGrid.Items = result.CurrentArrows;
            customTarget.PreviousArrowGrid.Items = result.PreviousArrows;

            var lastArrowsGrid = customTarget.PreviousArrowGrid;
            lastArrowsGrid.BindingContext = countSetting;
            lastArrowsGrid.SetBinding(View.IsVisibleProperty, nameof(CountSetting.ShowAllArrows));

            var average = customTarget.AverageCanvas;
            average.BindingContext = countSetting;
            average.SetBinding(View.IsVisibleProperty, nameof(CountSetting.AverageIsVisible));
            var averagebehavior = new AverageBehavior(customTarget, counter, generalCounterSetting);
            average.Behaviors.Add(averagebehavior);

            var behavior = new MovableTargetBehavior(generalCounterSetting, counter, gestureMoveTarget);
            customTarget.Behaviors.Add(behavior);

            PropertyChangedEventHandler arg = null;
            arg = (t, e) => updateAverageWhenTargetSizeChange(e, averagebehavior);
            customTarget.PropertyChanged += arg;
            return customTarget;
        }

        private static void updateAverageWhenTargetSizeChange(PropertyChangedEventArgs e, AverageBehavior behavior)
        {
            if (e.PropertyName == nameof(Target.TargetSize))
            {
                behavior.UpdateAverage();
            }
        }
    }
}
