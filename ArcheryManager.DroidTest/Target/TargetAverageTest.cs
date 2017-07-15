using NUnit.Framework;
using Xamarin.UITest.Android;
using System.Linq;
using ArcheryManager.Resources;

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
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("Settings"));

            app.WaitForElement("numberArrowEntry");
            app.WaitForElement("ArrowsOrderSwitch");
            app.WaitForElement("ShowAllArrowsSwitch");
            app.WaitForElement("VisibilityAverageSwitch");
        }

        [Test]
        public void AverageVisibilityTest()
        {
            app.WaitForElement("scoreList"); //update visual

            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("Settings"));
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

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            app.WaitForElement("averageCanvas");

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(1));
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(0));
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            app.WaitForNoElement("averageCanvas");
        }

        [Test]
        public void AveragePositionTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(340, average.Rect.Height);
            Assert.LessOrEqual(340, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(348, average.Rect.Height);
            Assert.GreaterOrEqual(349, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.LessOrEqual(258, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(240, average.Rect.Height);
            Assert.LessOrEqual(485, average.Rect.Width);

            Assert.GreaterOrEqual(266, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(248, average.Rect.Height);
            Assert.GreaterOrEqual(495, average.Rect.Width);
        }

        [Test]
        public void AveragePositionMultiFlightTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);
            app.DragCoordinates(300, 800, 700, 900);
            app.DragCoordinates(400, 800, 770, 800);

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(340, average.Rect.Height);
            Assert.LessOrEqual(338, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(346, average.Rect.Height);
            Assert.GreaterOrEqual(347, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.LessOrEqual(255, average.Rect.CenterX);
            Assert.LessOrEqual(667, average.Rect.CenterY);
            Assert.LessOrEqual(240, average.Rect.Height);
            Assert.LessOrEqual(483, average.Rect.Width);

            Assert.GreaterOrEqual(265, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(248, average.Rect.Height);
            Assert.GreaterOrEqual(492, average.Rect.Width);
        }

        [Test]
        public void AveragePositionAllArrowTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap("ShowAllArrowsSwitch");
            app.Back();

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas")).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(340, average.Rect.Height);
            Assert.LessOrEqual(340, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(350, average.Rect.Height);
            Assert.GreaterOrEqual(348, average.Rect.Width);

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);

            app.WaitForElement("scoreList"); //update visual
            average = app.Query(e => e.Marked("averageCanvas")).First();

            Assert.LessOrEqual(378, average.Rect.CenterX);
            Assert.LessOrEqual(668, average.Rect.CenterY);
            Assert.LessOrEqual(360, average.Rect.Height);
            Assert.LessOrEqual(535, average.Rect.Width);

            Assert.GreaterOrEqual(385, average.Rect.CenterX);
            Assert.GreaterOrEqual(674, average.Rect.CenterY);
            Assert.GreaterOrEqual(370, average.Rect.Height);
            Assert.GreaterOrEqual(545, average.Rect.Width);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.LessOrEqual(475, average.Rect.CenterX);
            Assert.LessOrEqual(688, average.Rect.CenterY);
            Assert.LessOrEqual(310, average.Rect.Height);
            Assert.LessOrEqual(692, average.Rect.Width);

            Assert.GreaterOrEqual(485, average.Rect.CenterX);
            Assert.GreaterOrEqual(698, average.Rect.CenterY);
            Assert.GreaterOrEqual(320, average.Rect.Height);
            Assert.GreaterOrEqual(705, average.Rect.Width);
        }
    }
}
