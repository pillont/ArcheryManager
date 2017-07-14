using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.GenericCountable
{
    [TestFixture]
    public class ButtonScoreTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("ButtonCounterButton");
            app.Screenshot("button count page");
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
            app.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child(1).Child().Text("1"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child(1).Child().Text("2"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child(1).Child().Text("3"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child(1).Child().Text("4"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child(1).Child().Text("5"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child(1).Child().Text("6"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child(1).Child().Text("7"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(8).Child(1).Child().Text("9"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(10).Child(1).Child().Text("X10"));
            app.WaitForElement(c => c.Marked("buttonGrid").Child(11).Child(1).Child().Text("M"));
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
            app.WaitForElement("scoreList");
        }

        #region list of arrows

        [Test]
        public void AllArrowRemoveNewFlightInTarget()
        {
            app.WaitForElement("buttonGrid"); //update visual

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));

            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void ArrowShowInList()
        {
            app.WaitForElement("buttonGrid"); //update visual

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            // tap to create arrow

            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
        }

        [Test]
        public void ArrowRemoveInList()
        {
            app.WaitForElement("buttonGrid"); //update visual
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child().Child(1).Child()).Last().Text);

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveInList()
        {
            app.WaitForElement("buttonGrid"); //update visual
            app.Tap(c => c.Marked("buttonGrid").Child(9));
            app.Tap(c => c.Marked("buttonGrid").Child(7));
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveNewFlightInList()
        {
            app.WaitForElement("buttonGrid"); //update visual
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        #endregion list of arrows

        #region score

        [Test]
        public void ScoreFlightUpdate()
        {
            app.WaitForElement("buttonGrid"); //update visual
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual("18/20", app.Query("FlightScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
        }

        [Test]
        public void ScoreTotalUpdate()
        {
            app.WaitForElement("buttonGrid"); //update visual
            Assert.AreEqual("0/0", app.Query("TotalScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            Assert.AreEqual("10/10", app.Query("TotalScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28/30", app.Query("TotalScore").First().Text);

            // tap to create arrow
            app.Tap(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            Assert.AreEqual("18/20", app.Query("FlightScore").First().Text);
            Assert.AreEqual("36/40", app.Query("TotalScore").First().Text);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            Assert.AreEqual("10/10", app.Query("FlightScore").First().Text);
            Assert.AreEqual("28/30", app.Query("TotalScore").First().Text);

            //remove all
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            Assert.AreEqual("0/0", app.Query("FlightScore").First().Text);
            Assert.AreEqual("18/20", app.Query("TotalScore").First().Text);
        }

        #endregion score

        [Test]
        public void ButtonsCounterInPortraitOrientation()
        {
            app.SetOrientationLandscape();
            app.WaitForElement("scoreList");

            var count = app.Query("scoreGrid").First().Rect;
            var list = app.Query("scoreList").First().Rect;

            Assert.AreEqual(598, count.CenterX);
            Assert.AreEqual(244, count.CenterY);

            Assert.AreEqual(598, list.CenterX);
            Assert.AreEqual(456, list.CenterY);

            app.ScrollToVerticalEnd();

            var tar = app.Query("buttonGrid").First().Rect;
            Assert.AreEqual(598, tar.CenterX);

            Assert.GreaterOrEqual(tar.CenterY, 463);
            Assert.LessOrEqual(tar.CenterY, 478);
        }
    }
}
