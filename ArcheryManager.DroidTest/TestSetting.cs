using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    internal static class TestSetting
    {
        public static string ApkUri = System.AppDomain.CurrentDomain.BaseDirectory + "../../../ArcheryManager/ArcheryManager.Android/bin/Release/ArcheryManager.Android.apk";

        public static AndroidApp App { get; private set; }

        internal static AndroidApp InitTestApplication()
        {
            // TOD0: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            App = ConfigureApp
                    .Android
                    // TOD0: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    .ApkFile(TestSetting.ApkUri)
                    .StartApp();

            App.SetOrientationPortrait();
            return App;
        }
    }
}
