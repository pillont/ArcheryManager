using System;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public class CustomTarget : ContentView
    {
        private double currentScale;
        private double startScale;
        private double xOffset;
        private double yOffset;

        public CustomTarget()
        {
            Grid grid = new Grid();
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += PinchGesture_PinchUpdated;
            grid.GestureRecognizers.Add(pinchGesture);

            for (int i = 1; i < 12; i++)
            {
                var rate = (double)(12d - (double)i * 1.02) / 12d;

                var shape = new ShapeView
                {
                    HeightRequest = 350 * rate, //TODO
                    WidthRequest = 350 * rate, //TODO
                    ShapeType = ShapeType.Circle,
                    BorderColor = BorderColorZone(i),
                    Color = ColorZone(i),
                    BorderWidth = 1,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };

                grid.Children.Add(shape);
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
            grid.Children.Add(center);
            Content = grid;
        }

        private void PinchGesture_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            //REF : https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/gestures/pinch/
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                Content.TranslationX = Clamp(targetX, -Content.Width * (currentScale - 1), 0);
                Content.TranslationY = Clamp(targetY, -Content.Height * (currentScale - 1), 0);

                // Apply scale factor.
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }

        private Color ColorZone(int i)
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

        private Color BorderColorZone(int i)
        {
            if (i == 3 || i == 4)
                return Color.White;
            else
                return Color.Black;
        }

        public static double Clamp(double value, double min, double max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
    }
}
