using ArcheryManager.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;
using XFShapeView;
using static ArcheryManager.Utils.TargetScoreCounter;

namespace ArcheryManager.CustomControls.Targets
{
    public class EnglishTarget : ContentView, ITarget
    {
        /// <summary>
        /// count of color in the target
        /// </summary>
        private const int ColorCount = 12;

        /// <summary>
        /// ratio to define the width of the zone
        /// </summary>
        private const double ColorWidthRatio = 1.02;

        /// <summary>
        /// size of the target
        /// </summary>
        private const int TargetSize = 350; //TODO allow to change value

        /// <summary>
        /// width of the target strings
        /// </summary>
        private const int StringWidth = 1;

        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        private const int ArrowWidth = 10;

        /// <summary>
        /// width of the arrow in the zoomed target
        /// </summary>
        private const double ArrowWidthZommed = ArrowWidth * TargetBehavior<EnglishTarget>.TargetScale;

        /// <summary>
        /// count the score on the target
        /// </summary>
        private readonly TargetScoreCounter counter;

        /// <summary>
        /// color of the arrows in the target
        /// </summary>
        private readonly Color ArrowColor = Color.Green;

        /// <summary>
        /// color of the point to set arrow
        /// </summary>
        private readonly Color ArrowSetterColor = Color.Fuchsia;

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
            #region visual generation

            #region targetgrid

            TargetGrid = new Grid();

            for (int i = 1; i < ColorCount; i++)
            {
                double rate = (ColorCount - i * ColorWidthRatio) / ColorCount;

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

            #endregion targetgrid

            #region arrow setter point

            ArrowSetter = new ShapeView()
            {
                HeightRequest = ArrowWidthZommed,
                WidthRequest = ArrowWidth * TargetBehavior<EnglishTarget>.TargetScale,
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

            var behavior = new TargetBehavior<EnglishTarget>();
            Behaviors.Add(behavior);

            counter = new TargetScoreCounter();
        }

        #region public functions

        public void AddArrow(Point position)
        {
            var score = ScoreAt(position); // position with scale

            var realPosition = new Point( // position without scale
                            x: (position.X + position.X * Math.Abs(TargetBehavior<EnglishTarget>.TargetTranslationRate)) / TargetBehavior<EnglishTarget>.TargetScale,
                            y: (position.Y + position.Y * Math.Abs(TargetBehavior<EnglishTarget>.TargetTranslationRate)) / TargetBehavior<EnglishTarget>.TargetScale);
            var visual = ArrowVisual(realPosition);

            var arrow = counter.AddArrow(visual, score);
            TargetGrid.Children.Add(arrow);
        }

        public void RemoveLastArrow()
        {
            var arrow = counter.RemoveLastArrow();
            TargetGrid.Children.Remove(arrow);
        }

        public void CleanArrows()
        {
            var arrows = counter.CleanArrows();

            foreach (var a in arrows)
                TargetGrid.Children.Remove(a);
        }

        #endregion public functions

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

        private View ArrowVisual(Point position)
        {
            return new ShapeView
            {
                HeightRequest = ArrowWidth,
                WidthRequest = ArrowWidth,
                ShapeType = ShapeType.Circle,
                BorderColor = ArrowColor,
                Color = ArrowColor,
                BorderWidth = 1,
                TranslationX = position.X,
                TranslationY = position.Y,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
        }

        private Score ScoreAt(Point position)
        {
            double distance = Math.Sqrt(Math.Pow(position.X, 2) + Math.Pow(position.Y, 2));
            distance -= distance * TargetBehavior<EnglishTarget>.TargetTranslationRate; // target translation
            distance -= ArrowWidth / 2; // arrow size
            distance -= StringWidth; // string size

            for (int i = 11; i > 0; i--)
            {
                double rate = (ColorCount - i * ColorWidthRatio) / ColorCount;

                double size = TargetSize * rate;
                size *= TargetBehavior<EnglishTarget>.TargetScale; // target scale
                if (distance < size / 2)
                    return (Score)i;
            }
            return (Score)0;
        }
    }
}
