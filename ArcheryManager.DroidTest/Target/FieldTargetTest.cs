﻿using NUnit.Framework;
using System.Linq;
using ArcheryManager.Resources;
using Xamarin.UITest.Android;
using ArcheryManager.DroidTest.Helpers;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class FieldTargetTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("fieldTargetButton");
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
            TargetHelper.ShouldHaveFieldTarget();
        }

        [Test]
        public void InitCommandTargetElement()
        {
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveLast"));
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveAll"));
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
            app.DragCoordinates(300, 800, 250, 775);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("5", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            // drag to create arrow
            app.DragCoordinates(500, 900, 570, 960);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("4", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
        }

        [Test]
        public void ArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(600, 600, 650, 550);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("5", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        #endregion list of arrows

        #region score

        [Test]
        public void ScoreFlightUpdate()
        {
            app.WaitForElement("FlightScore"); //update visual
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(300, 1000, 250, 950);
            Assert.AreEqual("5/6", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(530, 730, 600, 830);
            Assert.AreEqual("9/12", app.Query("FlightScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("5/6", app.Query("FlightScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
        }

        [Test]
        public void ScoreTotalUpdate()
        {
            app.WaitForElement("TotalScore"); //update visual
            Assert.AreEqual("0/0", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(300, 1000, 250, 950);
            Assert.AreEqual("5/6", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(530, 730, 600, 830);
            Assert.AreEqual("9/12", app.Query("TotalScore").First().Text);

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("9/12", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(300, 1000, 250, 950);
            Assert.AreEqual("5/6", app.Query("FlightScore").First().Text);
            Assert.AreEqual("14/18", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(530, 730, 600, 830);
            Assert.AreEqual("9/12", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18/24", app.Query("TotalScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("5/6", app.Query("FlightScore").First().Text);
            Assert.AreEqual("14/18", app.Query("TotalScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("9/12", app.Query("TotalScore").First().Text);
        }

        #endregion score
    }
}
