using NUnit.Framework;
using Xamarin.UITest.Android;
using System.Linq;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class TargetAverageTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("indoorRecurveTargetButton");
            app.Screenshot("Target page");
        }

        [Test]
        public void SettingButtonsTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap("More options");
            app.Tap("Settings");

            app.WaitForElement("numberArrowEntry");
            app.WaitForElement("ArrowsOrderSwitch");
            app.WaitForElement("ShowAllArrowsSwitch");
            app.WaitForElement("VisibilityAverageSwitch");
        }

        [Test]
        public void AverageVisibilityTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap("More options");
            app.Tap("Settings");
            app.Tap("VisibilityAverageSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual
            app.WaitForNoElement("averageCanvas");

            // drag to create arrow
            app.DragCoordinates(300, 800, 250, 750);
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.DragCoordinates(300, 800, 300, 1000);
            app.WaitForElement("averageCanvas");

            app.Tap("Remove last");
            app.WaitForElement("averageCanvas");

            app.Tap("Remove last");
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(1));
            app.Tap("Remove");
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(0));
            app.Tap("Remove");
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap("Remove all");
            app.WaitForNoElement("averageCanvas");
        }

        [Test]
        public void AveragePositionTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap("More options");
            app.Tap("Settings");
            app.Tap("VisibilityAverageSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas").Child()).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(242, average.Rect.Height);
            Assert.LessOrEqual(240, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(248, average.Rect.Height);
            Assert.GreaterOrEqual(247, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child()).First();
            Assert.LessOrEqual(290, average.Rect.CenterX);
            Assert.LessOrEqual(650, average.Rect.CenterY);
            Assert.LessOrEqual(173, average.Rect.Height);
            Assert.LessOrEqual(345, average.Rect.Width);

            Assert.GreaterOrEqual(296, average.Rect.CenterX);
            Assert.GreaterOrEqual(658, average.Rect.CenterY);
            Assert.GreaterOrEqual(181, average.Rect.Height);
            Assert.GreaterOrEqual(355, average.Rect.Width);
        }

        [Test]
        public void AveragePositionMultiFlightTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap("More options");
            app.Tap("Settings");
            app.Tap("VisibilityAverageSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);
            app.DragCoordinates(300, 800, 700, 900);
            app.DragCoordinates(400, 800, 770, 800);

            app.Tap("New Flight");

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas").Child()).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(242, average.Rect.Height);
            Assert.LessOrEqual(240, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(248, average.Rect.Height);
            Assert.GreaterOrEqual(247, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child()).First();
            Assert.LessOrEqual(290, average.Rect.CenterX);
            Assert.LessOrEqual(650, average.Rect.CenterY);
            Assert.LessOrEqual(171, average.Rect.Height);
            Assert.LessOrEqual(343, average.Rect.Width);

            Assert.GreaterOrEqual(296, average.Rect.CenterX);
            Assert.GreaterOrEqual(658, average.Rect.CenterY);
            Assert.GreaterOrEqual(181, average.Rect.Height);
            Assert.GreaterOrEqual(355, average.Rect.Width);
        }

        [Test]
        public void AveragePositionAllArrowTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap("More options");
            app.Tap("Settings");
            app.Tap("VisibilityAverageSwitch");
            app.Tap("ShowAllArrowsSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas")).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(244, average.Rect.Height);
            Assert.LessOrEqual(240, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(250, average.Rect.Height);
            Assert.GreaterOrEqual(248, average.Rect.Width);

            app.Tap("New Flight");

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);

            app.WaitForElement("scoreList"); //update visual
            average = app.Query(e => e.Marked("averageCanvas")).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(250, average.Rect.Height);
            Assert.LessOrEqual(390, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(260, average.Rect.Height);
            Assert.GreaterOrEqual(398, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child()).First();
            Assert.LessOrEqual(450, average.Rect.CenterX);
            Assert.LessOrEqual(660, average.Rect.CenterY);
            Assert.LessOrEqual(220, average.Rect.Height);
            Assert.LessOrEqual(505, average.Rect.Width);

            Assert.GreaterOrEqual(460, average.Rect.CenterX);
            Assert.GreaterOrEqual(668, average.Rect.CenterY);
            Assert.GreaterOrEqual(230, average.Rect.Height);
            Assert.GreaterOrEqual(515, average.Rect.Width);
        }
    }
}
