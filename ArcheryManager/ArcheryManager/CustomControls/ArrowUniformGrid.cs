using System.Linq;
using System.Runtime.CompilerServices;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;
using System.ComponentModel;
using System.Collections.Specialized;
using ArcheryManager.Helpers;
using ArcheryManager.Settings.ArrowSettings;

namespace ArcheryManager.CustomControls
{
    public class ArrowUniformGrid : UniformGrid<Arrow>
    {
        private const int WidthOfSelectedBorder = 10;

        public static readonly BindableProperty SettingProperty =
                      BindableProperty.Create(nameof(ArrowSetting), typeof(IArrowSetting), typeof(ArrowUniformGrid), null);

        public IArrowSetting ArrowSetting
        {
            get { return (IArrowSetting)GetValue(SettingProperty); }
            set { SetValue(SettingProperty, value); }
        }

        public const int DefaultBorderWidth = 1;
        public static readonly Color DefaultBorderColor = Color.Black;

        protected override View CreateItemContainer(Arrow arrow)
        {
            var grid = new Grid();
            int index = arrow.Index;
            string score = ArrowSetting.ScoreByIndex(index);
            var shape = new ShapeView()
            {
                Margin = new Thickness(2),
                HeightRequest = 20,
                WidthRequest = 20,
                ShapeType = ShapeType.Circle,
                BorderWidth = DefaultBorderWidth,
                BorderColor = DefaultBorderColor,
                Color = ArrowSetting.ColorOf(score),
            };

            var label = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = ArrowSetting.ScoreByIndex(index),
            };

            //NOTE : ArrowUniformGridController is helper to find element in the kind of container
            //       If this structure change, think to change in the helper to
            grid.Children.Add(shape);
            grid.Children.Add(label);

            arrow.PropertyChanged += Arrow_PropertyChanged;

            return grid;
        }

        private void Arrow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Arrow.IsSelected))
            {
                var arrow = sender as Arrow;
                var container = FindContainer(arrow);

                if (arrow.IsSelected)
                {
                    SelectArrow(container);
                }
                else
                {
                    UnSelectArrow(container);
                }
            }
        }

        private void SelectArrow(View container)
        {
            var shape = ArrowUniformGridHelper.ShapeOfArrow(container);

            shape.BorderColor = CommonConstant.DefaultSelectedArrowColor;
            shape.BorderWidth = WidthOfSelectedBorder;
        }

        private void UnSelectArrow(View container)
        {
            var shape = ArrowUniformGridHelper.ShapeOfArrow(container);
            shape.BorderColor = ArrowUniformGrid.DefaultBorderColor;
            shape.BorderWidth = ArrowUniformGrid.DefaultBorderWidth;
        }
    }
}
