using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowCustomGrid : UniformGrid<Arrow>
    {
        protected override View CreateItemContainer(Arrow arrow)
        {
            var grid = new Grid();

            var shape = new ShapeView()
            {
                Margin = new Thickness(2),
                HeightRequest = 20,
                WidthRequest = 20,
                ShapeType = ShapeType.Circle,
                BorderWidth = 1,
            };
            shape.SetBinding(ShapeView.BorderColorProperty, "Color");
            shape.SetBinding(ShapeView.ColorProperty, "Color");

            grid.Children.Add(shape);

            var label = new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            label.SetBinding(Label.TextProperty, "Score");

            grid.Children.Add(label);

            return grid;
        }
    }
}
