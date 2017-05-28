using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    [TestFixture]
    public class TimerViewTest
    {
        private AndroidApp app;

        [SetUp]
        public void Init()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile("../../../ArcheryManager/ArcheryManager.Android/bin/Test/ArcheryManager.Android.apk")
                .StartApp();
            app.Tap(c => c.Marked("TimerButton"));
            app.Screenshot("Timer screen.");
        }

        [Test]
        public void TimerTest()
        { }
    }
}
