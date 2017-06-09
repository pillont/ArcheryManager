using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowsGrid : ItemsGrid<Arrow>
    {
        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        private const double DefaultArrowWidth = 10;

        /// <summary>
        /// color of the arrows in the target
        /// </summary>
        private static readonly Color DefaultArrowColor = Color.Green;

        public static readonly BindableProperty ArrowWidthProperty =
                      BindableProperty.Create(nameof(ArrowWidth), typeof(double), typeof(ArrowsGrid), DefaultArrowWidth);

        public double ArrowWidth
        {
            get { return (double)GetValue(ArrowWidthProperty); }
            set { SetValue(ArrowWidthProperty, value); }
        }

        public static readonly BindableProperty ArrowColorProperty =
                      BindableProperty.Create(nameof(ArrowColor), typeof(Color), typeof(ArrowsGrid), DefaultArrowColor);

        public Color ArrowColor
        {
            get { return (Color)GetValue(ArrowColorProperty); }
            set { SetValue(ArrowColorProperty, value); }
        }

        protected override View CreateItemContainer(Arrow arrow)
        {
            var ctn = new ShapeView
            {
                HeightRequest = ArrowWidth,
                WidthRequest = ArrowWidth,
                ShapeType = ShapeType.Circle,
                BorderColor = Color.Black,
                Color = ArrowColor,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            ctn.SetBinding(View.TranslationXProperty, nameof(Arrow.TranslationX));
            ctn.SetBinding(View.TranslationYProperty, nameof(Arrow.TranslationY));

            return ctn;
        }
    }
}
