﻿using ArcheryManager.CustomControls;
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
        public static Target Create(IGeneralCounterSetting generalCounterSetting, ScoreCounter counter)
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
            var averagebehavior = new AverageBehavior(counter, generalCounterSetting);
            average.Behaviors.Add(averagebehavior);

            var behavior = new MovableTargetBehavior(generalCounterSetting, counter);
            customTarget.Behaviors.Add(behavior);

            return customTarget;
        }
    }
}
