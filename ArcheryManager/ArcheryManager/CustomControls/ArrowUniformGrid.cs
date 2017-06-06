using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowUniformGrid : UniformGrid<Arrow>
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
                BorderColor = Color.Black,
            };
            shape.SetBinding(ShapeView.ColorProperty, "Color");

            grid.Children.Add(shape);

            var label = new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            label.SetBinding(Label.TextProperty, "Score");

            grid.Children.Add(label);

            return grid;
        }
    }
}
