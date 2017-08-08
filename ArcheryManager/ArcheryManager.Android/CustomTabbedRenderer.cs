using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Reflection;
using ArcheryManager.Droid;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedRenderer))]

namespace ArcheryManager.Droid
{
    public class CustomTabbedRenderer : TabbedPageRenderer
    {
        public CustomTabbedRenderer()
        {
        }

        override

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            // Disable animations only when UseAnimations is queried for enabling gestures
            var fieldInfo = typeof(TabbedPageRenderer).GetField("_useAnimations", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(this, false);

            base.OnElementChanged(e);

            // Re-enable animations for everything else
            fieldInfo.SetValue(this, true);
        }
    }
}
