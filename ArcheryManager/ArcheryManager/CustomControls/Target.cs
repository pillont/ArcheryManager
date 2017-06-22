using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XFShapeView;
using ArcheryManager.Interactions.Behaviors;

namespace ArcheryManager.CustomControls
{
    public class Target : ContentView, IMovableTarget
    {
        public static readonly BindableProperty SettingProperty =
                      BindableProperty.Create(nameof(Setting), typeof(IArrowSetting), typeof(Target), null);

        public ArrowFactory factory;

        public ArrowFactory Factory
        {
            get
            {
                return factory;
            }
            private set
            {
                factory = value;
                DrawTargetVisual();
            }
        }

        public IArrowSetting Setting
        {
            get { return (IArrowSetting)GetValue(SettingProperty); }
            set
            {
                SetValue(SettingProperty, value);
                Factory = new ArrowFactory(this, Setting);
            }
        }

        public ObservableCollection<Arrow> Items
        {
            get
            {
                return arrowGrid.Items;
            }
            set
            {
                arrowGrid.Items = value;
            }
        }

        /// <summary>
        /// ratio to define the width of the zone
        /// </summary>
        public const double ColorWidthRatio = 1.02;

        /// <summary>
        /// size of the target
        /// </summary>
        private const double DefaultTargetSize = 320;

        public static readonly BindableProperty TargetSizeProperty =
                      BindableProperty.Create(nameof(TargetSize), typeof(double), typeof(Target), DefaultTargetSize);

        public double TargetSize
        {
            get { return (double)GetValue(TargetSizeProperty); }
            set { SetValue(TargetSizeProperty, value); }
        }

        /// <summary>
        /// width of the target strings
        /// </summary>
        public const int StringWidth = 1;

        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        public const int ArrowWidth = 7;

        /// <summary>
        /// width of the arrow in the zoomed target
        /// </summary>
        private const double ArrowWidthZommed = ArrowWidth * MovableTargetBehavior.TargetScale;

        /// <summary>
        /// color of the arrows in the target
        /// </summary>
        private readonly Color ArrowColor = Color.Green;

        /// <summary>
        /// color of the point to set arrow
        /// </summary>
        private readonly Color ArrowSetterColor = Color.Fuchsia;

        private ArrowsGrid arrowGrid;
        public AverageCanvas AverageCanvas { get; private set; } // TODO set private with layout builder

        /// <summary>
        /// point to set arrow during manipulation
        /// </summary>
        public ShapeView ArrowSetter { get; private set; }

        /// <summary>
        /// gris container of the target
        /// </summary>
        public Grid TargetGrid { get; private set; }

        public Target()
            : this(EnglishArrowSetting.Instance)

        { }

        public Target(IArrowSetting setting)
        {
            CreateContent();

            Setting = setting;
        }

        /// <summary>
        /// create the target content
        /// </summary>
        private void CreateContent()
        {
            arrowGrid = new ArrowsGrid() { AutomationId = "arrowInTargetGrid", ArrowWidth = ArrowWidth };
            AverageCanvas = new AverageCanvas() { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
            TargetGrid = new Grid();

            CreateVisualArrowSetter();

            Grid globalGrid = new Grid();
            globalGrid.Children.Add(TargetGrid);
            globalGrid.Children.Add(ArrowSetter);

            Content = globalGrid;
        }

        /// <summary>
        /// generate ArrowSetter
        /// </summary>
        private void CreateVisualArrowSetter()
        {
            ArrowSetter = new ShapeView()
            {
                HeightRequest = ArrowWidthZommed,
                WidthRequest = ArrowWidth * MovableTargetBehavior.TargetScale,
                ShapeType = ShapeType.Circle,
                BorderColor = ArrowSetterColor,
                Color = ArrowSetterColor,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = false,
            };
        }

        /// <summary>
        /// function to generate TargetGrid
        /// init and add all shapes in the grid
        /// </summary>
        public void DrawTargetVisual()
        {
            TargetGrid.Children.Clear();

            for (int i = 1; i < Factory.Setting.ZoneCount; i++)
            {
                double rate = (Factory.Setting.ZoneCount - i * ColorWidthRatio) / Factory.Setting.ZoneCount;

                var shape = new ShapeView
                {
                    HeightRequest = TargetSize * rate, //TODO
                    WidthRequest = TargetSize * rate, //TODO
                    ShapeType = ShapeType.Circle,
                    BorderColor = Setting.BorderColorZone(i),
                    Color = Setting.ColorofTargetZone(i),
                    BorderWidth = StringWidth,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    AutomationId = "zone" + i,
                };

                TargetGrid.Children.Add(shape);
            }

            var center = new ShapeView
            {
                HeightRequest = 2,
                WidthRequest = 2,
                ShapeType = ShapeType.Circle,
                BorderColor = Color.Black,
                Color = Color.Black,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = "center",
            };

            TargetGrid.Children.Add(center);//TODO layout builder
            TargetGrid.Children.Add(AverageCanvas); //TODO layout builder
            TargetGrid.Children.Add(arrowGrid);//TODO layout builder
        }

        public void SelectArrow(Arrow arrow)
        {
            arrowGrid.SelectArrow(arrow);
        }

        public void UnSelectArrow(Arrow arrow)
        {
            arrowGrid.UnSelectArrow(arrow);
        }

        public void ResetSelection()
        {
            arrowGrid.ResetSelection();
        }
    }
}
