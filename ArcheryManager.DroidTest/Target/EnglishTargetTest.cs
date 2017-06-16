﻿using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class EnglishTargetTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("EnglishTargetButton");
            app.Screenshot("Target page");
        }

        [Test]
        public void InitScoreTargetElement()
        {
            app.WaitForElement("FlightScoreTitle");
            app.WaitForElement("TotalScoreTitle");
            app.WaitForElement("FlightScore");
            app.WaitForElement("TotalScore");
        }

        [Test]
        public void InitTargetElement()
        {
            Assert.AreEqual(961, app.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(872, app.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(782, app.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(693, app.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(604, app.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(514, app.WaitForElement("zone6").First().Rect.Height);
            Assert.AreEqual(425, app.WaitForElement("zone7").First().Rect.Height);
            Assert.AreEqual(336, app.WaitForElement("zone8").First().Rect.Height);
            Assert.AreEqual(247, app.WaitForElement("zone9").First().Rect.Height);
            Assert.AreEqual(158, app.WaitForElement("zone10").First().Rect.Height);
            Assert.AreEqual(68, app.WaitForElement("zone11").First().Rect.Height);
            Assert.AreEqual(6, app.WaitForElement("center").First().Rect.Height);

            Assert.AreEqual(961, app.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(872, app.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(782, app.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(693, app.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(604, app.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(514, app.WaitForElement("zone6").First().Rect.Width);
            Assert.AreEqual(425, app.WaitForElement("zone7").First().Rect.Width);
            Assert.AreEqual(336, app.WaitForElement("zone8").First().Rect.Width);
            Assert.AreEqual(247, app.WaitForElement("zone9").First().Rect.Width);
            Assert.AreEqual(158, app.WaitForElement("zone10").First().Rect.Width);
            Assert.AreEqual(68, app.WaitForElement("zone11").First().Rect.Width);
            Assert.AreEqual(6, app.WaitForElement("center").First().Rect.Width);
        }

        [Test]
        public void InitCommandTargetElement()
        {
            app.WaitForElement("nextFlight");
            app.WaitForElement("removeAllArrows");
            app.WaitForElement("removeArrow");
        }

        [Test]
        public void InitArrowGridsTargetElement()
        {
            app.WaitForElement("arrowInTargetGrid");
            app.WaitForElement("scoreList");
        }

        #region list of arrows

        [Test]
        public void ArrowShowInList()
        {
            app.WaitForElement("scoreList"); //update visual

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
        }

        [Test]
        public void ArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap("removeArrow");

            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            app.Tap("removeArrow");

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        #endregion list of arrows

        #region score

        [Test]
        public void ScoreFlightUpdate()
        {
            app.WaitForElement("FlightScore"); //update visual
            Assert.AreEqual("0", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            Assert.AreEqual("10", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual("18", app.Query("FlightScore").First().Text);

            //remove arrow
            app.Tap("removeArrow");
            Assert.AreEqual("10", app.Query("FlightScore").First().Text);

            //remove all
            app.Tap("removeAllArrows");
            Assert.AreEqual("0", app.Query("FlightScore").First().Text);
        }

        [Test]
        public void ScoreTotalUpdate()
        {
            app.WaitForElement("TotalScore"); //update visual
            Assert.AreEqual("0", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            Assert.AreEqual("10", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual("18", app.Query("TotalScore").First().Text);

            app.Tap("nextFlight");

            Assert.AreEqual("0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            Assert.AreEqual("10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual("18", app.Query("FlightScore").First().Text);
            Assert.AreEqual("36", app.Query("TotalScore").First().Text);

            //remove arrow
            app.Tap("removeArrow");
            Assert.AreEqual("10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28", app.Query("TotalScore").First().Text);

            //remove all
            app.Tap("removeAllArrows");
            Assert.AreEqual("0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18", app.Query("TotalScore").First().Text);
        }

        #endregion score
    }
}