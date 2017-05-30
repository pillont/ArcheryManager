using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    internal static class TestSetting
    {
        public static string ApkUri = "../../../ArcheryManager/ArcheryManager.Android/bin/Release/ArcheryManager.Android.apk";

        internal static AndroidApp InitTestApplication()
        {
            // TOD0: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            return ConfigureApp
                    .Android
                    // TOD0: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    .ApkFile(TestSetting.ApkUri)
                    .StartApp();
        }
    }
}
