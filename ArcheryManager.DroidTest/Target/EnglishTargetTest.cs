using ArcheryManager.Resources;
using NUnit.Framework;
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
            Assert.AreEqual(684, app.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(621, app.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(557, app.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(494, app.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(430, app.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(367, app.WaitForElement("zone6").First().Rect.Height);
            Assert.AreEqual(303, app.WaitForElement("zone7").First().Rect.Height);
            Assert.AreEqual(239, app.WaitForElement("zone8").First().Rect.Height);
            Assert.AreEqual(176, app.WaitForElement("zone9").First().Rect.Height);
            Assert.AreEqual(112, app.WaitForElement("zone10").First().Rect.Height);
            Assert.AreEqual(49, app.WaitForElement("zone11").First().Rect.Height);
            Assert.AreEqual(4, app.WaitForElement("center").First().Rect.Height);

            Assert.AreEqual(684, app.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(621, app.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(557, app.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(494, app.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(430, app.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(367, app.WaitForElement("zone6").First().Rect.Width);
            Assert.AreEqual(303, app.WaitForElement("zone7").First().Rect.Width);
            Assert.AreEqual(239, app.WaitForElement("zone8").First().Rect.Width);
            Assert.AreEqual(176, app.WaitForElement("zone9").First().Rect.Width);
            Assert.AreEqual(112, app.WaitForElement("zone10").First().Rect.Width);
            Assert.AreEqual(49, app.WaitForElement("zone11").First().Rect.Width);
            Assert.AreEqual(4, app.WaitForElement("center").First().Rect.Width);
        }

        [Test]
        public void InitCommandTargetElement()
        {
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveAll"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveLast"));
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
            app.DragCoordinates(500, 800, 475, 775);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 570, 850);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
        }

        [Test]
        public void ArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 475, 775);
            app.DragCoordinates(500, 800, 550, 850);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

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
            app.DragCoordinates(500, 800, 475, 775);
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 800);
            Assert.AreEqual("18/20", app.Query("FlightScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
        }

        [Test]
        public void ScoreTotalUpdate()
        {
            app.WaitForElement("TotalScore"); //update visual
            Assert.AreEqual("0/0", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 775);
            Assert.AreEqual("10/10", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 800);
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 775);
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28/30", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 800);
            Assert.AreEqual("18/20", app.Query("FlightScore").First().Text);
            Assert.AreEqual("36/40", app.Query("TotalScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28/30", app.Query("TotalScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);
        }

        #endregion score
    }
}
