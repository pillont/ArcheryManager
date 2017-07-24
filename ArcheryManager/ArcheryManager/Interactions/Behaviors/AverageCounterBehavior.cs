using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Settings;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class AverageCounterBehavior : CustomBehavior<AverageCanvas>
    {
        private Point averageCenter;

        private const int MinArrowForAverage = 2;

        private readonly ScoreCounter Counter;
        private readonly CountSetting CountSetting;

        public AverageCounterBehavior(ScoreCounter scoreCounter, CountSetting countSetting)
        {
            CountSetting = countSetting;
            Counter = scoreCounter;
            Counter.Result.AllArrows.CollectionChanged += AllArrows_CollectionChanged;
        }

        protected override void OnAttachedTo(AverageCanvas bindable)
        {
            base.OnAttachedTo(bindable);

            CountSetting.PropertyChanged += CountSetting_PropertyChanged;
        }

        /// <summary>
        /// update average when AllArrow of the counter changing
        /// </summary>
        private void AllArrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Counter.ArrowsShowed.Count < MinArrowForAverage)
            {
                associatedObject.RemoveAverage();
            }
            else
            {
                UpdateAverage();
            }
        }

        private void CountSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountSetting.ShowAllArrows))
            {
                if (Counter.ArrowsShowed.Count > MinArrowForAverage)
                {
                    UpdateAverage();
                }
            }
        }

        private void UpdateAverage()// TODO make behavior
        {
            UpdateAverageCenter();
            UpdateAverageForm();
        }

        #region average update

        private void UpdateAverageForm()
        {
            double standartDeviationX = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationX));
            double standartDeviationY = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationY));
            associatedObject.ShowAverageVisual(averageCenter, standartDeviationX, standartDeviationY);
        }

        private void UpdateAverageCenter()
        {
            if (Counter.ArrowsShowed.Count == 0)
            {
                throw new InvalidOperationException();
            }

            double averageX = Counter.ArrowsShowed.Average(a => a.TranslationX);
            double averageY = Counter.ArrowsShowed.Average(a => a.TranslationY);
            averageCenter = new Point(averageX, averageY);
        }

        #endregion average update
    }
}
