using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
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
        private readonly CountedShoot Shoot;
        private readonly Target Target;
        public Point? AverageCenter { get; private set; }

        public AverageBehavior(CounterManager manager, Target target)
        {
            Shoot = manager.CurrentShoot;
            Counter = manager.Counter;
            Target = target;
        }

        protected override void OnAttachedTo(AverageCanvas bindable)
        {
            base.OnAttachedTo(bindable);
            Shoot.PropertyChanged += Setting_PropertyChanged;
            Counter.PropertyChanged += Counter_PropertyChanged;

            Target.PropertyChanged += Target_PropertyChanged;
        }

        protected override void OnDetachingFrom(AverageCanvas bindable)
        {
            Shoot.PropertyChanged -= Setting_PropertyChanged;
            Counter.PropertyChanged -= Counter_PropertyChanged;
        }

        private void Counter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Counter.CurrentArrows))
            {
                UpdateAverage();
            }
        }

        /// <summary>
        /// update average during AllArrowShowed changing
        /// </summary>
        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountedShoot.ShowAllArrows)
            || e.PropertyName == nameof(CountedShoot.AverageIsVisible))
            {
                UpdateAverage();
            }
        }

        private void Target_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Target.TargetSize))
            {
                UpdateAverage();
            }
        }

        #region average update

        private object AverageIsUpdatingLocker = new object();

        /// <summary>
        /// update average when AllArrow of the counter changing
        /// </summary>
        public void UpdateAverage()
        {
            bool seeAverage = Shoot.AverageIsVisible
                            && Counter.ArrowsShowed.Count() >= MinArrowForAverage;

            if (seeAverage)
            {
                UpdateAverageAsync();
            }
            else
            {
                RemoveAverage();
            }
        }

        public void UpdateAverageCenter(List<Arrow> list)
        {
            if (list.Count == 0)
            {
                AverageCenter = null;
            }
            else
            {
                double averageX = list.Average(a => ArrowTranslationHelper.TranslationXOf(a, Target.TargetSize));
                double averageY = list.Average(a => ArrowTranslationHelper.TranslationYOf(a, Target.TargetSize));
                AverageCenter = new Point(averageX, averageY);
            }
        }

        private void ComputeAverage()
        {
            var list = Counter.ArrowsShowed.ToList();

            UpdateAverageCenter(list);
            double standartDeviationX = StatisticHelper.CalculateStdDev(list.Select(a => ArrowTranslationHelper.TranslationXOf(a, Target.TargetSize)));
            double standartDeviationY = StatisticHelper.CalculateStdDev(list.Select(a => ArrowTranslationHelper.TranslationYOf(a, Target.TargetSize)));

            if (!AverageCenter.HasValue)
            {
                throw new NullReferenceException("average center hasn't value");
            }

            var visual = AssociatedObject.CreateAverageVisual(standartDeviationX, standartDeviationY, AverageCenter.Value);
            Device.BeginInvokeOnMainThread(() =>
                                        AssociatedObject.Content = visual);
        }

        private void RemoveAverage()
        {
            Task.Run(() =>
            {
                lock (AverageIsUpdatingLocker)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        RemoveVisualOfAverage();
                    });
                }
            });
        }

        private void RemoveVisualOfAverage()
        {
            AssociatedObject.Content = null;
        }

        private async void UpdateAverageAsync()
        {
            await Task.Run(() =>
            {
                lock (AverageIsUpdatingLocker)
                {
                    ComputeAverage();
                }
            });
        }

        #endregion average update
    }
}
