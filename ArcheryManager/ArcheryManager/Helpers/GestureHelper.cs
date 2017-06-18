using ArcheryManager.Interactions;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Helpers
{
    public static class GestureHelper
    {
        public static void AddTapGestureOn(View view, EventHandler action)
        {
            if (view is Button button)
            {
                button.Clicked += action;
            }
            else
            {
                var recognizer = new TapGestureRecognizer();
                recognizer.Tapped += action;
                view.GestureRecognizers.Add(recognizer);
            }
        }

        public static void AddPanGestureOn(View view, EventHandler<CustomPanUpdatedEventArgs> action)
        {
            var recognizer = new CustomPanGestureReconizer();
            recognizer.PanUpdated += action;
            view.GestureRecognizers.Add(recognizer);
        }
    }
}
