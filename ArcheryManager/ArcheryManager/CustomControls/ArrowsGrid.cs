﻿using ArcheryManager.Entities;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using System.ComponentModel;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class ArrowsGrid : ItemsGrid<Arrow>
    {
        public static readonly BindableProperty ArrowColorProperty =
                              BindableProperty.Create(nameof(ArrowColor), typeof(Color), typeof(ArrowsGrid), CommonConstant.DefaultArrowColor);

        public static readonly BindableProperty ArrowWidthProperty =
                              BindableProperty.Create(nameof(ArrowWidth), typeof(double), typeof(ArrowsGrid), DefaultArrowWidth);

        public static readonly BindableProperty SelectedArrowColorProperty =
                              BindableProperty.Create(nameof(SelectedArrowColor), typeof(Color), typeof(ArrowsGrid), CommonConstant.DefaultSelectedArrowColor);

        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        private const double DefaultArrowWidth = 10;

        private double targetSize;

        public Color ArrowColor
        {
            get { return (Color)GetValue(ArrowColorProperty); }
            set { SetValue(ArrowColorProperty, value); }
        }

        public double ArrowWidth
        {
            get { return (double)GetValue(ArrowWidthProperty); }
            set { SetValue(ArrowWidthProperty, value); }
        }

        public Color SelectedArrowColor
        {
            get { return (Color)GetValue(SelectedArrowColorProperty); }
            set { SetValue(SelectedArrowColorProperty, value); }
        }

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
                TranslationX = ArrowTranslationHelper.TranslationXOf(arrow, TargetSize),
                TranslationY = ArrowTranslationHelper.TranslationYOf(arrow, TargetSize),
            };

            arrow.PropertyChanged += Arrow_PropertyChanged;
            return ctn;
        }

        private void Arrow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Arrow.IsSelected))
            {
                var arrow = sender as Arrow;

                if (arrow.IsSelected)
                {
                    SelectArrow(arrow);
                }
                else
                {
                    UnSelectArrow(arrow);
                }
            }
        }

        private void SelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            if (container != null)
            {
                container.Color = SelectedArrowColor;
            }
        }

        private double TransformTranslation(double translation, double targetSize)
        {
            return TargetSize / targetSize * translation;
        }

        private double TranslationXOf(Arrow arrow)
        {
            return TransformTranslation(arrow.TranslationX, arrow.TargetSize);
        }

        private double TranslationYOf(Arrow arrow)
        {
            return TransformTranslation(arrow.TranslationY, arrow.TargetSize);
        }

        private void UnSelectArrow(Arrow arrow)
        {
            var container = FindContainer(arrow) as ShapeView;
            if (container != null)
            {
                container.Color = ArrowColor;
            }
        }

        private void UpdateAllTransforms()
        {
            foreach (var a in Items)
            {
                var container = FindContainer(a);
                container.TranslationX = ArrowTranslationHelper.TranslationXOf(a, TargetSize);
                container.TranslationY = ArrowTranslationHelper.TranslationYOf(a, TargetSize);
            }
        }
    }
}
