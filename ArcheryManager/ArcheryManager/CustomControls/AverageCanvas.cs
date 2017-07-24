using ArcheryManager.Settings;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    /// <summary>
    /// need target setting in binding context
    /// </summary>
    public class AverageCanvas : ContentView
    {
        public AverageCanvas(IGeneralCounterSetting generalCounterSetting)
        {
            var countSetting = generalCounterSetting.CountSetting;
            BindingContext = countSetting;
        }

        public void ShowAverageVisual(Point averageCenter, double standartDeviationX, double standartDeviationY)
        {
            var grid = CreateAverageVisual(averageCenter, standartDeviationX, standartDeviationY);
            Content = grid;
        }

        private static Grid CreateAverageVisual(Point averageCenter, double standartDeviationX, double standartDeviationY)
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

        public void RemoveAverage()
        {
            Content = null;
        }
    }
}
