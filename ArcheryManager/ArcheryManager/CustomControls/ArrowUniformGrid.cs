using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowUniformGrid : UniformGrid<Arrow>
    {
        public const int DefaultBorderWidth = 1;

        public static readonly BindableProperty ArrowSettingProperty =
                      BindableProperty.Create(nameof(ArrowSetting), typeof(IArrowSetting), typeof(ArrowUniformGrid), null);

        public static readonly Color DefaultBorderColor = Color.Black;
        private const int ShapeSize = 20;
        private const int WidthOfSelectedBorder = 10;

        public IArrowSetting ArrowSetting
        {
            get { return (IArrowSetting)GetValue(ArrowSettingProperty); }
            set { SetValue(ArrowSettingProperty, value); }
        }

        public ArrowUniformGrid()
        {
            PropertyChanged += ArrowUniformGrid_PropertyChanged;
        }

        protected override View CreateItemContainer(Arrow arrow)
        {
            if (ArrowSetting != null)
            {
                var grid = new Grid();
                int index = arrow.Index;

                string score = ArrowSetting.ScoreByIndex(index);
                var shape = new ShapeView()
                {
                    Margin = new Thickness(2),
                    HeightRequest = ShapeSize,
                    WidthRequest = ShapeSize,
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
            return null;
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

        private void ArrowUniformGrid_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ArrowSetting))
            {
                //TODO : Tolist() is needed to create new reference of list
                var values = Items.ToList();
                Items.Clear();

                foreach (var v in values)
                {
                    Items.Add(v);
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
