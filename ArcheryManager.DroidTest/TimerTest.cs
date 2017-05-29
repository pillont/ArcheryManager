using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    [TestFixture]
    public class TimerTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile(TestSetting.ApkUri)
                .StartApp();

            app.Screenshot("BackDoor Page");
            app.Tap("TimerButton");
            app.Screenshot("Timer page");
        }

        [Test]
        public void InitElement()
        {
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            app.WaitForElement(c => c.Marked("StartButton"));
            app.WaitForElement(c => c.Marked("StopButton"));
            app.WaitForElement(c => c.Marked("PauseButton"));
        }

        [Test]
        public void StartButton()
        {
            app.Tap("StartButton");
            System.Threading.Thread.Sleep(5000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("5"));
        }
    }
}
