using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowUniformGrid : UniformGrid<Arrow>
    {
        public const int DefaultBorderWidth = 1;
        public static readonly Color DefaultBorderColor = Color.Black;

        protected override View CreateItemContainer(Arrow arrow)
        {
            var grid = new Grid();

            var shape = new ShapeView()
            {
                Margin = new Thickness(2),
                HeightRequest = 20,
                WidthRequest = 20,
                ShapeType = ShapeType.Circle,
                BorderWidth = DefaultBorderWidth,
                BorderColor = DefaultBorderColor,
            };
            shape.SetBinding(ShapeView.ColorProperty, "Color");

            var label = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            label.SetBinding(Label.TextProperty, "Score");

            //NOTE : ArrowUniformGridController is helper to find element in the kind of container
            //       If this structure change, think to change in the helper to
            grid.Children.Add(shape);
            grid.Children.Add(label);
            return grid;
        }
    }
}
