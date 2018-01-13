using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.DroidTest.StepDefinition;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace ArcheryManager.DroidTest.Target
{
    [TestFixture]
    public class GenericTargetTest
    {
        private AndroidApp app;

        [Test]
        public void AllArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveNewFlightInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslationHelper.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveNewFlightInTarget()
        {
            app.WaitForElement("scoreList"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);

            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslationHelper.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("fieldTargetButton");
            app.Screenshot("Target page");
        }

        #region target

        [Test]
        public void AllArrowRemoveInTarget()
        {
            app.WaitForElement("arrowInTargetGrid"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);

            var list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(2, list.Count()); // have one arrow in target

            app.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            app.Tap(TranslationHelper.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(0, list.Count()); // have one arrow in target
        }

        [Test]
        public void ArrowRemoveInTarget()
        {
            app.WaitForElement("arrowInTargetGrid"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 775);
            // drag to create arrow
            app.DragCoordinates(500, 800, 550, 850);
            var pure = new AppRect() { Width = 21, Height = 21, X = 502, Y = 1001, CenterX = 512, CenterY = 1011 };

            var list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(2, list.Count()); // have one arrow in target

            GeneralCounterStep.RemoveLast();

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(1, list.Count()); // have one arrow in target

            var rec = list.Last().Rect;
            //assert on the position of the arrow
            Assert.LessOrEqual(pure.Width - 2, rec.Width);
            Assert.GreaterOrEqual(pure.Width + 2, rec.Width);
            Assert.LessOrEqual(pure.Height - 2, rec.Height);
            Assert.GreaterOrEqual(pure.Height + 2, rec.Height);
            Assert.LessOrEqual(pure.X - 2, rec.X);
            Assert.GreaterOrEqual(pure.X + 2, rec.X);
            Assert.LessOrEqual(pure.Y - 2, rec.Y);
            Assert.GreaterOrEqual(pure.Y + 2, rec.Y);
            Assert.LessOrEqual(pure.CenterX - 2, rec.CenterX);
            Assert.GreaterOrEqual(pure.CenterX + 2, rec.CenterX);
            Assert.LessOrEqual(pure.CenterY - 2, rec.CenterY);
            Assert.GreaterOrEqual(pure.CenterY + 2, rec.CenterY);

            GeneralCounterStep.RemoveLast();

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(0, list.Count()); // have one arrow in target
        }

        [Test]
        public void ArrowShowInTarget()
        {
            app.WaitForElement("arrowInTargetGrid"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            var pure = new AppRect() { Width = 21, Height = 21, X = 630, Y = 1129, CenterX = 640, CenterY = 1139 };

            var list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(1, list.Count()); // have one arrow in target
            var rec = list.Last().Rect;
            //assert on the position of the arrow
            Assert.LessOrEqual(pure.Width - 2, rec.Width);
            Assert.GreaterOrEqual(pure.Width + 2, rec.Width);
            Assert.LessOrEqual(pure.Height - 2, rec.Height);
            Assert.GreaterOrEqual(pure.Height + 2, rec.Height);
            Assert.LessOrEqual(pure.X - 2, rec.X);
            Assert.GreaterOrEqual(pure.X + 2, rec.X);
            Assert.LessOrEqual(pure.Y - 4, rec.Y);
            Assert.GreaterOrEqual(pure.Y + 4, rec.Y);
            Assert.LessOrEqual(pure.CenterX - 2, rec.CenterX);
            Assert.GreaterOrEqual(pure.CenterX + 2, rec.CenterX);
            Assert.LessOrEqual(pure.CenterY - 2, rec.CenterY);
            Assert.GreaterOrEqual(pure.CenterY + 2, rec.CenterY);

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            pure = new AppRect() { Width = 21, Height = 21, X = 476, Y = 975, CenterX = 486, CenterY = 985 };

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(2, list.Count()); // have one arrow in target
            rec = list.Last().Rect;
            //assert on the position of the arrow
            Assert.LessOrEqual(pure.Width - 2, rec.Width);
            Assert.GreaterOrEqual(pure.Width + 2, rec.Width);
            Assert.LessOrEqual(pure.Height - 2, rec.Height);
            Assert.GreaterOrEqual(pure.Height + 2, rec.Height);
            Assert.LessOrEqual(pure.X - 2, rec.X);
            Assert.GreaterOrEqual(pure.X + 2, rec.X);
            Assert.LessOrEqual(pure.Y - 4, rec.Y);
            Assert.GreaterOrEqual(pure.Y + 4, rec.Y);
            Assert.LessOrEqual(pure.CenterX - 2, rec.CenterX);
            Assert.GreaterOrEqual(pure.CenterX + 2, rec.CenterX);
            Assert.LessOrEqual(pure.CenterY - 2, rec.CenterY);
            Assert.GreaterOrEqual(pure.CenterY + 2, rec.CenterY);
        }

        #endregion target

        [Test]
        public void TargetInPortraitOrientation()
        {
            app.SetOrientationLandscape();
            app.WaitForElement("scoreList");

            var tar = app.Query("arrowInTargetGrid").First().Rect;
            var count = app.Query("scoreGrid").First().Rect;
            var list = app.Query("scoreList").First().Rect;

            Assert.AreEqual(444, tar.CenterX);
            Assert.AreEqual(720, tar.CenterY);

            Assert.AreEqual(1350, count.CenterX);
            Assert.AreEqual(535, count.CenterY);

            Assert.AreEqual(1350, list.CenterX);
            Assert.AreEqual(904, list.CenterY);
        }
    }
}
