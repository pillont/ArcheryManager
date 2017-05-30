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
            app = TestSetting.InitTestApplication();
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
