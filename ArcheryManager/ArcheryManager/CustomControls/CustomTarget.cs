using ArcheryManager.Behaviors;
using System;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class CustomTarget : ContentView
    {
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
        public readonly ShapeView ArrowSetter;

        /// <summary>
        /// gris container of the target
        /// </summary>
        public readonly Grid TargetGrid;

        public CustomTarget()
        {
            #region visual generation

            #region targetgrid

            TargetGrid = new Grid();

            for (int i = 1; i < 12; i++)
            {
                var rate = (double)(12d - (double)i * 1.02) / 12d;

                var shape = new ShapeView
                {
                    HeightRequest = 350 * rate, //TODO
                    WidthRequest = 350 * rate, //TODO
                    ShapeType = ShapeType.Circle,
                    BorderColor = BorderColorZone(i),
                    Color = ColorofZone(i),
                    BorderWidth = 1,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };

                TargetGrid.Children.Add(shape);
            }

            var center = new ShapeView
            {
                HeightRequest = 2, //TODO
                WidthRequest = 2, //TODO
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
                HeightRequest = 10,
                WidthRequest = 10,
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

            var behavior = new TargetBehavior();
            Behaviors.Add(behavior);
        }

        public void SetArrow(Point position)
        {
            //TODO set arrow in the target
            throw new NotImplementedException();
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
