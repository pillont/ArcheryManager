using ArcheryManager.Resources;
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
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);

            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveSelect"));

            //un select all
            app.Tap(TranslateExtension.GetTextResource("UnSelect"));

            // not visible
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));
        }

        [Test]
        public void RemoveButtonsVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            // not visible
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));
        }

        [Test]
        public void UnSelection_ButtonsVisibilityTest()

        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 400, 900);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // TranslateExtension.GetTextResource("UnSelect") one
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForElement(TranslateExtension.GetTextResource("RemoveSelect"));

            // TranslateExtension.GetTextResource("UnSelect") all
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // not visible
            app.WaitForNoElement(TranslateExtension.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslateExtension.GetTextResource("RemoveSelect"));
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
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);

            //remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
        }

        [Test]
        public void UnSelectTest()

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

            //TranslateExtension.GetTextResource("UnSelect") 0,1
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

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

            Assert.LessOrEqual(87, rec1.CenterX);
            Assert.GreaterOrEqual(95, rec1.CenterX);
            Assert.LessOrEqual(1105, rec1.CenterY);
            Assert.GreaterOrEqual(1115, rec1.CenterY);

            Assert.LessOrEqual(280, rec2.CenterX);
            Assert.GreaterOrEqual(290, rec2.CenterX);
            Assert.LessOrEqual(1105, rec2.CenterY);
            Assert.GreaterOrEqual(1115, rec2.CenterY);

            Assert.LessOrEqual(475, rec3.CenterX);
            Assert.GreaterOrEqual(485, rec3.CenterX);
            Assert.LessOrEqual(1105, rec3.CenterY);
            Assert.GreaterOrEqual(1115, rec3.CenterY);

            Assert.LessOrEqual(670, rec4.CenterX);
            Assert.GreaterOrEqual(680, rec4.CenterX);
            Assert.LessOrEqual(1105, rec4.CenterY);
            Assert.GreaterOrEqual(1115, rec4.CenterY);

            // remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect")); // toolbar items to remove

            rec1 = app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Rect;
            rec2 = app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Rect;
            rec3 = app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Rect;

            Assert.LessOrEqual(120, rec1.CenterX);
            Assert.GreaterOrEqual(130, rec1.CenterX);
            Assert.LessOrEqual(1105, rec1.CenterY);
            Assert.GreaterOrEqual(1115, rec1.CenterY);

            Assert.LessOrEqual(380, rec2.CenterX);
            Assert.GreaterOrEqual(385, rec2.CenterX);
            Assert.LessOrEqual(1105, rec2.CenterY);
            Assert.GreaterOrEqual(1115, rec2.CenterY);

            Assert.LessOrEqual(640, rec3.CenterX);
            Assert.GreaterOrEqual(650, rec3.CenterX);
            Assert.LessOrEqual(1105, rec3.CenterY);
            Assert.GreaterOrEqual(1115, rec3.CenterY);
        }
    }
}
