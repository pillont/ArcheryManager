using ArcheryManager.Helpers;
using ArcheryManager.Settings;
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
        public new CountSetting BindingContext
        {
            get
            {
                if (base.BindingContext is CountSetting)
                {
                    return base.BindingContext as CountSetting;
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

        public virtual View CreateAverageVisual(double standartDeviationX, double standartDeviationY, Point center)
        {
            var centerVisual = new ShapeView()
            {
                ShapeType = ShapeType.Circle,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TranslationX = center.X,
                TranslationY = center.Y,
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
                TranslationX = center.X,
                TranslationY = center.Y,
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
            grid.Children.Add(centerVisual);

            return grid;
        }
    }
}
