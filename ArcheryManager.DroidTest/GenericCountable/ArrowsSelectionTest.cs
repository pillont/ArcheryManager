using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.GenericCountable
{
    [TestFixture]
    public class ArrowsSelectionTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("EnglishTargetButton");
        }

        [Test]
        public void UnSelectButtonsVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);

            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement("unSelectButton");
            app.WaitForElement("removeSelectionButton");

            //un select all
            app.Tap("unSelectButton");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");
        }

        [Test]
        public void RemoveButtonsVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement("unSelectButton");
            app.WaitForElement("removeSelectionButton");

            // remove arrow
            app.Tap("removeSelectionButton");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");
        }

        [Test]
        public void RemoveSelectedArrowByOtherButtonVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.WaitForElement("scoreList");

            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement("unSelectButton");
            app.WaitForElement("removeSelectionButton");

            // remove arrow
            app.Tap("removeAllArrows");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");
        }

        [Test]
        public void TapUnSelection_ButtonsVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 400, 900);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement("unSelectButton");
            app.WaitForElement("removeSelectionButton");

            // unselect one
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement("unSelectButton");
            app.WaitForElement("removeSelectionButton");

            // unselect all
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // not visible
            app.WaitForNoElement("unSelectButton");
            app.WaitForNoElement("removeSelectionButton");
        }

        [Test]
        public void RemoveBySelectionTest()
        {
            var list = app.WaitForElement("scoreList");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 850);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 700);

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).First().Text);

            //remove last
            app.Tap(e => e.Marked("scoreList").Child(3).Child(1).Child());
            app.Tap("removeSelectionButton");

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);

            //remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap("removeSelectionButton");

            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
        }

        [Test]
        public void RemoveWithUnSelectTest()
        {
            var list = app.WaitForElement("scoreList");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 850);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 700);

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).First().Text);

            //select 0,1,2
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(2).Child(1).Child());

            //unselect 0,1
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());
            app.Tap("removeSelectionButton");

            // wait 0,1,3
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
        }

        [Test]
        public void RemoveArrow_PositionTest()
        {
            var list = app.WaitForElement("scoreList");

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 900);
            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 850);
            // drag to create arrow
            app.DragCoordinates(500, 800, 600, 700);

            var rec1 = app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Rect;
            var rec2 = app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Rect;
            var rec3 = app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Rect;
            var rec4 = app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).First().Rect;

            Assert.LessOrEqual(110, rec1.CenterX);
            Assert.GreaterOrEqual(140, rec1.CenterX);
            Assert.LessOrEqual(1500, rec1.CenterY);
            Assert.GreaterOrEqual(1520, rec1.CenterY);

            Assert.LessOrEqual(395, rec2.CenterX);
            Assert.GreaterOrEqual(415, rec2.CenterX);
            Assert.LessOrEqual(1500, rec2.CenterY);
            Assert.GreaterOrEqual(1520, rec2.CenterY);

            Assert.LessOrEqual(670, rec3.CenterX);
            Assert.GreaterOrEqual(690, rec3.CenterX);
            Assert.LessOrEqual(1500, rec3.CenterY);
            Assert.GreaterOrEqual(1520, rec3.CenterY);

            Assert.LessOrEqual(945, rec4.CenterX);
            Assert.GreaterOrEqual(965, rec4.CenterX);
            Assert.LessOrEqual(1500, rec4.CenterY);
            Assert.GreaterOrEqual(1520, rec4.CenterY);

            // remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap("removeSelectionButton");

            rec1 = app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Rect;
            rec2 = app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Rect;
            rec3 = app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Rect;

            Assert.LessOrEqual(165, rec1.CenterX);
            Assert.GreaterOrEqual(185, rec1.CenterX);
            Assert.LessOrEqual(1500, rec1.CenterY);
            Assert.GreaterOrEqual(1520, rec1.CenterY);

            Assert.LessOrEqual(530, rec2.CenterX);
            Assert.GreaterOrEqual(550, rec2.CenterX);
            Assert.LessOrEqual(1500, rec2.CenterY);
            Assert.GreaterOrEqual(1520, rec2.CenterY);

            Assert.LessOrEqual(900, rec3.CenterX);
            Assert.GreaterOrEqual(910, rec3.CenterX);
            Assert.LessOrEqual(1500, rec3.CenterY);
            Assert.GreaterOrEqual(1520, rec3.CenterY);
        }
    }
}
