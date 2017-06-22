using ArcheryManager.Utils;
using System;
using System.Linq;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class AverageCanvas : ContentView
    {
        private ScoreCounter counter;
        private Point averageCenter;

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

        private void AllArrows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Counter.AllArrows.Count < 2)
            {
                Content = null;
            }
            else
            {
                UpdateAverageCenter();
                UpdateAverageForm();
            }
        }

        private void UpdateAverageForm()
        {
            var standartDeviationX = StatisticHelper.CalculateStdDev(Counter.AllArrows.Select(a => a.TranslationX));
            var standartDeviationY = StatisticHelper.CalculateStdDev(Counter.AllArrows.Select(a => a.TranslationY));
            Content = CreateAverageVisual(standartDeviationX, standartDeviationY);
        }

        private View CreateAverageVisual(double standartDeviationX, double standartDeviationY)
        {
            return new ShapeView()
            {
                ShapeType = ShapeType.Oval,

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
        }

        private void UpdateAverageCenter()
        {
            if (Counter.AllArrows.Count == 0)
            {
                throw new InvalidOperationException();
            }

            double averageX = Counter.AllArrows.Average(a => a.TranslationX);
            double averageY = Counter.AllArrows.Average(a => a.TranslationY);
            averageCenter = new Point(averageX, averageY);
        }
    }
}
