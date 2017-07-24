using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class AverageBehavior : CustomBehavior<AverageCanvas>
    {
        private const int MinArrowForAverage = 2;
        private readonly ScoreCounter Counter;
        private Point AverageCenter;
        private readonly IGeneralCounterSetting GeneralCounterSetting;

        private ScoreResult Result
        {
            get
            {
                return GeneralCounterSetting.ScoreResult;
            }
        }

        private CountSetting CountSetting
        {
            get
            {
                return GeneralCounterSetting.CountSetting;
            }
        }

        public AverageBehavior(ScoreCounter counter, IGeneralCounterSetting generalCounterSetting)
        {
            Counter = counter;
            GeneralCounterSetting = generalCounterSetting;
        }

        protected override void OnAttachedTo(AverageCanvas bindable)
        {
            base.OnAttachedTo(bindable);
            CountSetting.PropertyChanged += Setting_PropertyChanged;
            Result.AllArrows.CollectionChanged += AllArrows_CollectionChanged;
        }

        protected override void OnDetachingFrom(AverageCanvas bindable)
        {
            CountSetting.PropertyChanged -= Setting_PropertyChanged;
            Result.AllArrows.CollectionChanged -= AllArrows_CollectionChanged;
        }

        /// <summary>
        /// update average during AllArrowShowed changing
        /// </summary>
        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == nameof(CountSetting.ShowAllArrows))
                {
                    if (Counter.ArrowsShowed.Count > MinArrowForAverage)
                    {
                        UpdateAverageAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region average update

        private async void UpdateAverageAsync()// TODO make behavior
        {
            var list = Counter.ArrowsShowed.ToList();

            await Task.Run(() =>
            {
                try
                {
                    if (list.Count != 0)
                    {
                        UpdateAverageCenter(list);
                        double standartDeviationX = StatisticHelper.CalculateStdDev(list.Select(a => a.TranslationX));
                        double standartDeviationY = StatisticHelper.CalculateStdDev(list.Select(a => a.TranslationY));

                        Device.BeginInvokeOnMainThread(() =>
                            AssociatedObject.Content = AssociatedObject.CreateAverageVisual(standartDeviationX, standartDeviationY, AverageCenter));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            });
        }

        public void UpdateAverageCenter(List<Arrow> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            double averageX = list.Average(a => a.TranslationX);
            double averageY = list.Average(a => a.TranslationY);
            AverageCenter = new Point(averageX, averageY);
        }

        /// <summary>
        /// update average when AllArrow of the counter changing
        /// </summary>
        private void AllArrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Counter.ArrowsShowed.Count < MinArrowForAverage)
            {
                AssociatedObject.Content = null;
            }
            else
            {
                UpdateAverageAsync();
            }
        }

        #endregion average update
    }
}
