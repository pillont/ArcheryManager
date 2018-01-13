using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.DroidTest.StepDefinition;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class IndoorCompoundTargetTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("indoorCompoundTargetButton");
            app.Screenshot("Target page");
        }

        [Test]
        public void InitArrowGridsTargetElement()
        {
            app.WaitForElement("arrowInTargetGrid");
            app.WaitForElement("scoreList");
        }

        [Test]
        public void InitCommandTargetElement()
        {
            app.WaitForElement(TranslationHelper.GetTextResource("Finish"));
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.WaitForElement(TranslationHelper.GetTextResource("RemoveAll"));
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
            TargetHelper.ShouldHaveIndoorCompoundTarget();
        }

        #region list of arrows

        [Test]
        public void ArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 470, 770);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            GeneralCounterStep.RemoveLast();

            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            GeneralCounterStep.RemoveLast();

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void ArrowShowInList()
        {
            app.WaitForElement("scoreList"); //update visual

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());

            // drag to create arrow
            app.DragCoordinates(500, 800, 485, 785);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 850);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
        }

        #endregion list of arrows

        #region score

        [Test]
        public void ScoreFlightUpdate()
        {
            app.WaitForElement("FlightScore"); //update visual
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(520, 820, 550, 850);
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 850);
            Assert.AreEqual("19/20", app.Query("FlightScore").First().Text);

            //remove arrow
            GeneralCounterStep.RemoveLast();
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            //remove all
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
        }

        [Test]
        public void ScoreTotalUpdate()
        {
            app.WaitForElement("TotalScore"); //update visual
            Assert.AreEqual("0/0", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(520, 820, 550, 850);
            Assert.AreEqual("10/10", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 850);
            Assert.AreEqual("19/20", app.Query("TotalScore").First().Text);

            app.Tap(TranslationHelper.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("19/20", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(520, 820, 550, 850);
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("29/30", app.Query("TotalScore").First().Text);

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 850);
            Assert.AreEqual("19/20", app.Query("FlightScore").First().Text);
            Assert.AreEqual("38/40", app.Query("TotalScore").First().Text);

            //remove arrow
            GeneralCounterStep.RemoveLast();
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("29/30", app.Query("TotalScore").First().Text);

            //remove all
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("19/20", app.Query("TotalScore").First().Text);
        }

        #endregion score
    }
}
