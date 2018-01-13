using NUnit.Framework;
using System;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.Timer
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
        public void InitTimerElement()
        {
            app.WaitForElement("CustomTimer");
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            app.WaitForElement("PauseButton");
        }

        [Test]
        public void PauseButton()
        {
            TestSetting.App.Tap("CustomTimer");
            System.Threading.Thread.Sleep(5000);
            Assert.IsFalse(app.Query("PauseButton").First().Enabled);

            app.WaitForElement(c => c.Marked("TimerLabel").Text("115"));
            app.Tap("PauseButton");
            var val = Convert.ToInt32(app.WaitForElement(c => c.Marked("TimerLabel")).First().Text);

            System.Threading.Thread.Sleep(5000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text(val.ToString()));
            app.Tap("PauseButton");
            app.WaitForElement(c => c.Marked("TimerLabel").Text((--val).ToString()));
            app.WaitForElement(c => c.Marked("TimerLabel").Text("110"));
        }

        [Test]
        public void StartButton()
        {
            TestSetting.App.Tap("CustomTimer");
            System.Threading.Thread.Sleep(4000);

            app.WaitForElement(c => c.Marked("TimerLabel").Text("5"));

            System.Threading.Thread.Sleep(4000);

            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));

            System.Threading.Thread.Sleep(4000);

            app.WaitForElement(c => c.Marked("TimerLabel").Text("115"));
        }

        [Test]
        public void StopButton()
        {
            TestSetting.App.Tap("CustomTimer");
            System.Threading.Thread.Sleep(4000);
            TestSetting.App.Tap("CustomTimer");
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            System.Threading.Thread.Sleep(4000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));

            TestSetting.App.Tap("CustomTimer");
            System.Threading.Thread.Sleep(14000);
            TestSetting.App.Tap("CustomTimer");
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            System.Threading.Thread.Sleep(4000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));

            TestSetting.App.Tap("CustomTimer");
            System.Threading.Thread.Sleep(14000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("115"));
        }
    }
}
