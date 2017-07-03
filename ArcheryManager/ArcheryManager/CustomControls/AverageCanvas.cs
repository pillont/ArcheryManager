using ArcheryManager.Utils;
using System;
using System.Linq;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    /// <summary>
    /// need target setting in binding context
    /// </summary>
    public class AverageCanvas : ContentView
    {
        private const int MinArrowForAverage = 2;
        private ScoreCounter counter;
        private Point averageCenter;
        private TargetSetting Setting;

        public new TargetSetting BindingContext
        {
            get
            {
                if (base.BindingContext is TargetSetting)
                {
                    return base.BindingContext as TargetSetting;
                }
                else
                {
                    throw new InvalidCastException("binding target of average canvas must be Target setting");
                }
            }
            set
            {
                base.BindingContext = value;
            }
        }

        public ScoreCounter Counter
        {
            get
            {
                return counter;
            }
            set
            {
                if (counter != null)
                {
                    counter.AllArrows.CollectionChanged -= AllArrows_CollectionChanged;
                }
                counter = value;
                if (value != null)
                {
                    counter.AllArrows.CollectionChanged += AllArrows_CollectionChanged;
                }
            }
        }

        #region target setting

        /// <summary>
        /// get target setting by bindingcontext
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (Setting != null)
            {
                Setting.PropertyChanged -= Setting_PropertyChanged;
            }

            Setting = BindingContext;
            Setting.PropertyChanged += Setting_PropertyChanged;
        }

        /// <summary>
        /// update average during AllArrowShowed changing
        /// </summary>
        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == nameof(TargetSetting.ShowAllArrows))
                {
                    if (Counter.ArrowsShowed.Count > MinArrowForAverage)
                    {
                        UpdateAverage();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion target setting

        /// <summary>
        /// update average when AllArrow of the counter changing
        /// </summary>
        private void AllArrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Counter.ArrowsShowed.Count < MinArrowForAverage)
            {
                Content = null;
            }
            else
            {
                UpdateAverage();
            }
        }

        #region average update

        private void UpdateAverage()// TODO make behavior
        {
            UpdateAverageCenter();
            UpdateAverageForm();
        }

        private void UpdateAverageForm()
        {
            double standartDeviationX = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationX));
            double standartDeviationY = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationY));
            Content = CreateAverageVisual(standartDeviationX, standartDeviationY);
        }

        private View CreateAverageVisual(double standartDeviationX, double standartDeviationY)
        {
            var center = new ShapeView()
            {
                ShapeType = ShapeType.Circle,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TranslationX = averageCenter.X,
                TranslationY = averageCenter.Y,
                Color = Color.HotPink,
                BorderWidth = 2,
                BorderColor = Color.HotPink,
                HeightRequest = 15,
                WidthRequest = 15,
            };

            var big = new ShapeView()
            {
                ShapeType = ShapeType.Oval,
                Opacity = 0.8,
                HeightRequest = standartDeviationY * 2,
                WidthRequest = standartDeviationX * 2,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TranslationX = averageCenter.X,
                TranslationY = averageCenter.Y,
                Color = Color.LightPink,
                BorderWidth = 2,
                BorderColor = Color.HotPink,
            };

            var grid = new Grid()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            grid.Children.Add(big);
            grid.Children.Add(center);

            return grid;
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
