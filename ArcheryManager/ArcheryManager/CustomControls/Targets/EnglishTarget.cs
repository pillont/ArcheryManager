using ArcheryManager.Behaviors;
using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls.Targets
{
    public class EnglishTarget : ContentView, IMovableTarget //TODO set global target with this class, just add setting to the ctor
    {
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
        private const int DefaultTargetSize = 350; //TODO allow to change value

        public static readonly BindableProperty TargetSizeProperty =
                      BindableProperty.Create(nameof(TargetSize), typeof(int), typeof(EnglishTarget), DefaultTargetSize);

        public int TargetSize
        {
            get { return (int)GetValue(TargetSizeProperty); }
            set { SetValue(TargetSizeProperty, value); }
        }

        /// <summary>
        /// width of the target strings
        /// </summary>
        public const int StringWidth = 1;

        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        public const int ArrowWidth = 10;

        /// <summary>
        /// width of the arrow in the zoomed target
        /// </summary>
        private const double ArrowWidthZommed = ArrowWidth * MovableTargetBehavior<EnglishTarget>.TargetScale;

        /// <summary>
        /// color of the arrows in the target
        /// </summary>
        private readonly Color ArrowColor = Color.Green;

        /// <summary>
        /// color of the point to set arrow
        /// </summary>
        private readonly Color ArrowSetterColor = Color.Fuchsia;

        private ArrowsGrid arrowGrid;

        public ArrowFactory Factory { get; private set; }

        /// <summary>
        /// point to set arrow during manipulation
        /// </summary>
        public ShapeView ArrowSetter { get; private set; }

        /// <summary>
        /// gris container of the target
        /// </summary>
        public Grid TargetGrid { get; private set; }

        public EnglishTarget()
        {
            Factory = new EnglishArrowFactory(this);

            #region visual generation

            #region targetgrid

            TargetGrid = new Grid();

            for (int i = 1; i < Factory.Setting.ZoneCount; i++)
            {
                double rate = (Factory.Setting.ZoneCount - i * ColorWidthRatio) / Factory.Setting.ZoneCount;

                var shape = new ShapeView
                {
                    HeightRequest = TargetSize * rate, //TODO
                    WidthRequest = TargetSize * rate, //TODO
                    ShapeType = ShapeType.Circle,
                    BorderColor = BorderColorZone(i),
                    Color = ColorofZone(i),
                    BorderWidth = StringWidth,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
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
            };
            TargetGrid.Children.Add(center);

            arrowGrid = new ArrowsGrid();

            TargetGrid.Children.Add(arrowGrid);

            #endregion targetgrid

            #region arrow setter point

            ArrowSetter = new ShapeView()
            {
                HeightRequest = ArrowWidthZommed,
                WidthRequest = ArrowWidth * MovableTargetBehavior<EnglishTarget>.TargetScale,
                ShapeType = ShapeType.Circle,
                BorderColor = ArrowSetterColor,
                Color = ArrowSetterColor,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = false,
            };

            #endregion arrow setter point

            #region global grid

            Grid globalGrid = new Grid();
            globalGrid.Children.Add(TargetGrid);
            globalGrid.Children.Add(ArrowSetter);

            Content = globalGrid;

            #endregion global grid

            #endregion visual generation
        }

        /// <summary>
        ///determine the color associated to the score zone
        ///
        /// </summary>
        /// <param name="i">score zone / 11 => X10 </param>
        /// <returns>default white</returns>
        private Color ColorofZone(int i)
        {
            switch (i)
            {
                case 3:
                case 4:
                    return Color.Black;

                case 5:
                case 6:
                    return Color.Blue;

                case 7:
                case 8:
                    return Color.Red;

                case 9:
                case 10:
                case 11:
                    return Color.Yellow;

                default:
                    return Color.White;
            }
        }

        /// <summary>
        /// determine the color of the zone string
        /// </summary>
        /// <param name="i">score zone</param>
        private Color BorderColorZone(int i)
        {
            if (i == 3 || i == 4)
                return Color.White;
            else
                return Color.Black;
        }
    }
}
