using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using ArcheryManager.Helpers;
using ArcheryManager.Resources;
using Java.Interop;
using System;

namespace ArcheryManager.Droid
{
    [Activity(Label = "ArcheryManager", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                LoggerHelper.WriteError(exception);
                throw exception;
            }
        }

        [Export("GetDeviceTime")]
        public string GetDeviceTime()
        {
            return System.DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        [Export("GetTranslation")]
        public string GetTranslation(string key)
        {
            return TranslateExtension.GetTextResource(key);
        }

        protected override void OnCreate(Bundle bundle)
        {
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            LoggerHelper.WriteError(e.Exception);
        }
    }
}
