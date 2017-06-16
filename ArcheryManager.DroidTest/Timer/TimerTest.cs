﻿using NUnit.Framework;
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
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            app.WaitForElement(c => c.Marked("StartButton"));
            app.WaitForElement(c => c.Marked("StopButton"));
            app.WaitForElement(c => c.Marked("PauseButton"));
        }

        [Test]
        public void StartButton()
        {
            app.Tap("StartButton");
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
            app.Tap("StartButton");
            System.Threading.Thread.Sleep(4000);
            app.Tap("StopButton");
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            System.Threading.Thread.Sleep(4000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));

            app.Tap("StartButton");
            System.Threading.Thread.Sleep(14000);
            app.Tap("StopButton");
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));
            System.Threading.Thread.Sleep(4000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("120"));

            app.Tap("StartButton");
            System.Threading.Thread.Sleep(14000);
            app.WaitForElement(c => c.Marked("TimerLabel").Text("115"));
        }

        [Test]
        public void PauseButton()
        {
            app.Tap("StartButton");
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
    }
}