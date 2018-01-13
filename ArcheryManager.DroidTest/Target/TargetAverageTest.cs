using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.DroidTest.StepDefinition;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class TargetAverageTest
    {
        private AndroidApp app;

        [Test]
        public void AveragePositionAfterRotationTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap(TranslationHelper.GetTextResource("Finish"));

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            app.SetOrientationLandscape();
            app.WaitForElement("averageCanvas");

            Thread.Sleep(500);
            var average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.AreEqual(443, average.Rect.CenterX, 5);
            Assert.AreEqual(719, average.Rect.CenterY, 5);
            Assert.AreEqual(190, average.Rect.Width, 5);
            Assert.AreEqual(190, average.Rect.Height, 5);
        }

        [Test]
        public void AveragePositionAllArrowTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap("ShowAllArrowsSwitch");
            app.Tap(TranslationHelper.GetTextResource("Finish"));

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            app.WaitForElement("averageCanvas");
            var average = app.Query(e => e.Marked("averageCanvas")).First();
            Assert.AreEqual(538, average.Rect.CenterX, 5);
            Assert.AreEqual(1038, average.Rect.CenterY, 5);
            Assert.AreEqual(292, average.Rect.Height, 5);
            Assert.AreEqual(292, average.Rect.Width, 5);

            app.Tap(TranslationHelper.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);

            app.WaitForElement("scoreList"); //update visual
            average = app.Query(e => e.Marked("averageCanvas")).First();
            Assert.AreEqual(537, average.Rect.CenterX, 5);
            Assert.AreEqual(1036, average.Rect.CenterY, 5);
            Assert.AreEqual(312, average.Rect.Height, 5);
            Assert.AreEqual(465, average.Rect.Width, 5);

            app.DragCoordinates(400, 800, 100, 800);
            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.AreEqual(624, average.Rect.CenterX, 5);
            Assert.AreEqual(1058, average.Rect.CenterY, 5);
            Assert.AreEqual(273, average.Rect.Height, 5);
            Assert.AreEqual(601, average.Rect.Width, 5);
        }

        [Test]
        public void AveragePositionMultiFlightTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap(TranslationHelper.GetTextResource("Finish"));

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 600, 1000);
            app.DragCoordinates(400, 800, 800, 700);
            app.DragCoordinates(300, 800, 700, 900);
            app.DragCoordinates(400, 800, 770, 800);

            app.Tap(TranslationHelper.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            var average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();

            Assert.AreEqual(538, average.Rect.CenterX, 5);
            Assert.AreEqual(1037, average.Rect.CenterY, 5);
            Assert.AreEqual(297, average.Rect.Height, 5);
            Assert.AreEqual(297, average.Rect.Width, 5);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.AreEqual(434, average.Rect.CenterX, 5);
            Assert.AreEqual(1039, average.Rect.CenterY, 5);
            Assert.AreEqual(210, average.Rect.Height, 5);
            Assert.AreEqual(419, average.Rect.Width, 5);
        }

        [Test]
        public void AveragePositionTest()
        {
            app.WaitForElement("scoreList"); //update visual
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap(TranslationHelper.GetTextResource("Finish"));

            app.WaitForElement("scoreList"); //update visual

            app.DragCoordinates(300, 800, 400, 900);
            app.DragCoordinates(400, 800, 300, 700);

            app.WaitForElement("averageCanvas");

            var average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.AreEqual(538, average.Rect.CenterX, 5);
            Assert.AreEqual(1037, average.Rect.CenterY, 5);
            Assert.AreEqual(291, average.Rect.Height, 5);
            Assert.AreEqual(291, average.Rect.Width, 5);

            app.DragCoordinates(400, 800, 100, 800);

            average = app.Query(e => e.Marked("averageCanvas").Child().Child(0)).First();
            Assert.AreEqual(434, average.Rect.CenterX, 5);
            Assert.AreEqual(1037, average.Rect.CenterY, 5);
            Assert.AreEqual(206, average.Rect.Height, 5);
            Assert.AreEqual(419, average.Rect.Width, 5);
        }

        // #TODO
        [Test]
        public void AverageVisibilityTest()
        {
            app.WaitForElement("scoreList"); //update visual

            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));
            app.Tap("VisibilityAverageSwitch");
            app.Tap(TranslationHelper.GetTextResource("Finish"));

            app.WaitForElement("scoreList"); //update visual
            app.WaitForNoElement("averageCanvas");

            // drag to create arrow
            app.DragCoordinates(300, 800, 250, 750);
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.DragCoordinates(300, 800, 300, 1000);
            app.WaitForElement("averageCanvas");

            GeneralCounterStep.RemoveLast();
            app.WaitForElement("averageCanvas");

            GeneralCounterStep.RemoveLast();
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(1));
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));
            app.WaitForElement("averageCanvas");

            app.Tap(c => c.Marked("9").Index(0));
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));
            app.WaitForNoElement("averageCanvas");

            app.DragCoordinates(300, 800, 400, 800);
            app.WaitForElement("averageCanvas");

            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));
            app.WaitForNoElement("averageCanvas");
        }

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
            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("Settings"));

            app.WaitForElement("ArrowsOrderSwitch");
            app.WaitForElement("ShowAllArrowsSwitch");
            app.WaitForElement("VisibilityAverageSwitch");
        }
    }
}
