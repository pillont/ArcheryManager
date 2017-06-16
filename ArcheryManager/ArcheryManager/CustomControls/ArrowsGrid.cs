using ArcheryManager.Settings;
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

        public static readonly BindableProperty ArrowWidthProperty =
                      BindableProperty.Create(nameof(ArrowWidth), typeof(double), typeof(ArrowsGrid), DefaultArrowWidth);

        public double ArrowWidth
        {
            get { return (double)GetValue(ArrowWidthProperty); }
            set { SetValue(ArrowWidthProperty, value); }
        }

        public static readonly BindableProperty ArrowColorProperty =
                      BindableProperty.Create(nameof(ArrowColor), typeof(Color), typeof(ArrowsGrid), CommonConstant.DefaultArrowColor);

        public Color ArrowColor
        {
            get { return (Color)GetValue(ArrowColorProperty); }
            set { SetValue(ArrowColorProperty, value); }
        }

        public static readonly BindableProperty SelectedArrowColorProperty =
                      BindableProperty.Create(nameof(SelectedArrowColor), typeof(Color), typeof(ArrowsGrid), CommonConstant.DefaultSelectedArrowColor);

        public Color SelectedArrowColor
        {
            get { return (Color)GetValue(SelectedArrowColorProperty); }
            set { SetValue(SelectedArrowColorProperty, value); }
        }

        public ArrowsGrid()
        {
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

        public void SelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            container.Color = SelectedArrowColor;
        }

        public void UnSelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            container.Color = ArrowColor;
        }

        public void ResetSelection()
        {
            foreach (var arrow in Items)
            {
                var container = FindContainer(arrow) as ShapeView;
                container.Color = ArrowColor;
            }
        }
    }
}
