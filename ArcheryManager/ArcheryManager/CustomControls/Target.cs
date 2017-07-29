using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XFShapeView;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Settings.ArrowSettings;

namespace ArcheryManager.CustomControls
{
    public class Target : ContentView, IMovableTarget
    {
        #region constants

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

        private readonly Color PreviousArrowsColor = Color.DarkGray;

        #endregion constants

        public virtual double TargetSize
        {
            get { return (double)GetValue(TargetSizeProperty); }
            set
            {
                SetValue(TargetSizeProperty, value);
                PreviousArrowGrid.TargetSize = TargetSize;
                ArrowGrid.TargetSize = TargetSize;
            }
        }

        #region target layout

        internal readonly ArrowsGrid ArrowGrid;

        internal readonly ArrowsGrid PreviousArrowGrid;

        private readonly IArrowSetting ArrowSetting;
        public readonly ArrowFactory Factory;

        internal readonly AverageCanvas AverageCanvas; // TODO set private with layout builder

        #endregion target layout

        /// <summary>
        /// point to set arrow during manipulation
        /// </summary>
        public ShapeView ArrowSetter { get; private set; }

        /// <summary>
        /// gris container of the target
        /// </summary>
        public Grid TargetGrid { get; private set; }

        private readonly IGeneralCounterSetting GeneralCounterSetting;

        public Target()
            : this(DependencyService.Get<IGeneralCounterSetting>())
        {
        }

        public Target(IGeneralCounterSetting GeneralCounterSetting)
        {
            /*
             * target layout
             */
            PreviousArrowGrid = new ArrowsGrid()
            {
                AutomationId = "lastArrowInTargetGrid",
                ArrowWidth = ArrowWidth,
                ArrowColor = PreviousArrowsColor
            };
            AverageCanvas = new AverageCanvas()
            {
                AutomationId = "averageCanvas",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            ArrowGrid = new ArrowsGrid()
            {
                AutomationId = "arrowInTargetGrid",
                ArrowWidth = ArrowWidth,
                ArrowColor = CommonConstant.DefaultArrowColor
            };

            CreateContent();
            ArrowSetting = GeneralCounterSetting.ArrowSetting;
            Factory = new ArrowFactory(this, ArrowSetting);
            DrawTargetVisual();
        }

        #region visual of the target

        /// <summary>
        /// create the target content
        /// </summary>
        private void CreateContent()
        {
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
                BorderColor = Color.Black,
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
                    BorderColor = ArrowSetting.BorderColorZone(i),
                    Color = ArrowSetting.ColorofTargetZone(i),
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
            TargetGrid.Children.Add(PreviousArrowGrid);//TODO layout builder
            TargetGrid.Children.Add(ArrowGrid);//TODO layout builder
        }

        #endregion visual of the target

        #region selection interactions

        public virtual void SelectArrow(Arrow arrow)
        {
            ArrowGrid.SelectArrow(arrow);
        }

        public virtual void UnSelectArrow(Arrow arrow)
        {
            ArrowGrid.UnSelectArrow(arrow);
        }

        public virtual void ResetSelection()
        {
            foreach (var arrow in ArrowGrid.Items)
            {
                UnSelectArrow(arrow);
            }
        }

        #endregion selection interactions
    }
}
