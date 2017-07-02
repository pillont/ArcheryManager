using System;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;
using System.Collections.Generic;

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

        private double targetSize;

        public double TargetSize
        {
            get
            {
                return targetSize;
            }
            set
            {
                targetSize = value;
                UpdateAllTransforms();
            }
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
                TranslationX = TranslationXOf(arrow),
                TranslationY = TranslationYOf(arrow),
            };
            return ctn;
        }

        private void UpdateAllTransforms()
        {
            foreach (var a in Items)
            {
                var container = FindContainer(a);
                container.TranslationX = TranslationXOf(a);
                container.TranslationY = TranslationYOf(a);
            }
        }

        private double TranslationYOf(Arrow arrow)
        {
            return TransformTranslation(arrow.TranslationY, arrow.TargetSize);
        }

        private double TranslationXOf(Arrow arrow)
        {
            return TransformTranslation(arrow.TranslationX, arrow.TargetSize);
        }

        private double TransformTranslation(double translation, double targetSize)
        {
            return TargetSize / targetSize * translation;
        }

        public void SelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            if (container != null)
            {
                container.Color = SelectedArrowColor;
            }
        }

        public void UnSelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            if (container != null)
            {
                container.Color = ArrowColor;
            }
        }

        public void ResetSelection()
        {
            foreach (var arrow in Items)
            {
                UnSelectArrow(arrow);
            }
        }
    }
}
