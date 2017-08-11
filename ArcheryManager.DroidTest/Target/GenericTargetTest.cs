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
        public void ArrowShowInTarget()
        {
            app.WaitForElement("arrowInTargetGrid"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            var pure = new AppRect() { Width = 14, Height = 14, X = 499, Y = 807, CenterX = 506, CenterY = 814 };

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
            pure = new AppRect() { Width = 14, Height = 14, X = 315, Y = 623, CenterX = 322, CenterY = 630 };

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

        [Test]
        public void ArrowRemoveInTarget()
        {
            app.WaitForElement("arrowInTargetGrid"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 775);
            // drag to create arrow
            app.DragCoordinates(500, 800, 550, 850);
            var pure = new AppRect() { Width = 14, Height = 14, X = 346, Y = 654, CenterX = 353, CenterY = 661 };

            var list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(2, list.Count()); // have one arrow in target

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

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

            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(0, list.Count()); // have one arrow in target
        }

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

            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            list = app.Query(e => e.Marked("arrowInTargetGrid").Child());
            Assert.AreEqual(0, list.Count()); // have one arrow in target
        }

        #endregion target

        [Test]
        public void AllArrowRemoveNewFlightInTarget()
        {
            app.WaitForElement("scoreList"); //update visual

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);

            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("MoreOptions"));
            app.Tap(TranslateExtension.GetTextResource("RemoveAll"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void AllArrowRemoveNewFlightInList()
        {
            app.WaitForElement("scoreList"); //update visual
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.Tap(TranslateExtension.GetTextResource("NewFlight"));
            app.Tap(e => e.Text(TranslateExtension.GetTextResource("Yes")));

            Assert.AreEqual(0, app.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Test]
        public void TargetInPortraitOrientation()
        {
            app.SetOrientationLandscape();
            app.WaitForElement("scoreList");

            var tar = app.Query("arrowInTargetGrid").First().Rect;
            var count = app.Query("scoreGrid").First().Rect;
            var list = app.Query("scoreList").First().Rect;

            Assert.AreEqual(296, tar.CenterX);
            Assert.AreEqual(504, tar.CenterY);

            Assert.AreEqual(900, count.CenterX);
            Assert.AreEqual(369, count.CenterY);

            Assert.AreEqual(900, list.CenterX);
            Assert.AreEqual(639, list.CenterY);
        }
    }
}
