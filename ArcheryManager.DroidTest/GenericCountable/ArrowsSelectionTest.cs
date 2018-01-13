using ArcheryManager.DroidTest.Helpers;
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

            Assert.AreEqual(126, rec1.CenterX, 5);
            Assert.AreEqual(1664, rec1.CenterY, 5);

            Assert.AreEqual(400, rec2.CenterX, 5);
            Assert.AreEqual(1664, rec2.CenterY, 5);

            Assert.AreEqual(675, rec3.CenterX, 5);
            Assert.AreEqual(1664, rec3.CenterY, 5);

            Assert.AreEqual(950, rec4.CenterX, 5);
            Assert.AreEqual(1664, rec4.CenterY, 5);

            // remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect")); // toolbar items to remove

            rec1 = app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Rect;
            rec2 = app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Rect;
            rec3 = app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Rect;

            Assert.AreEqual(174, rec1.CenterX, 5);
            Assert.AreEqual(1664, rec1.CenterY, 5);

            Assert.AreEqual(540, rec2.CenterX, 5);
            Assert.AreEqual(1664, rec2.CenterY, 5);

            Assert.AreEqual(906, rec3.CenterX, 5);
            Assert.AreEqual(1664, rec3.CenterY, 5);
        }

        [Test]
        public void RemoveButtonsVisibilityTest()
        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // remove arrow
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));
        }

        [Test]
        public void RemoveBySelectionTest()
        {
            var list = app.WaitForElement("scoreList");

            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 725);
            // drag to create arrow
            app.DragCoordinates(500, 800, 570, 900);
            // drag to create arrow
            app.DragCoordinates(500, 800, 475, 875);
            // drag to create arrow
            app.DragCoordinates(500, 800, 570, 650);

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).First().Text);

            //remove last
            app.Tap(e => e.Marked("scoreList").Child(3).Child(1).Child());
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);

            //remove first
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
        }

        [Test]
        public void UnSelectButtonsVisibilityTest()

        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 600, 900);

            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForElement(TranslationHelper.GetTextResource("RemoveSelect"));

            //un select all
            app.Tap(TranslationHelper.GetTextResource("UnSelect"));

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));
        }

        [Test]
        public void UnSelection_ButtonsVisibilityTest()

        {
            var list = app.WaitForElement("scoreList");

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // drag to create arrow
            app.DragCoordinates(500, 800, 450, 750);
            app.DragCoordinates(500, 800, 400, 900);
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // visible
            app.WaitForElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // TranslationHelper.GetTextResource("UnSelect") one
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());

            // visible
            app.WaitForElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForElement(TranslationHelper.GetTextResource("RemoveSelect"));

            // TranslationHelper.GetTextResource("UnSelect") all
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());

            // not visible
            app.WaitForNoElement(TranslationHelper.GetTextResource("UnSelect"));
            app.WaitForNoElement(TranslationHelper.GetTextResource("RemoveSelect"));
        }

        [Test]
        public void UnSelectTest()

        {
            var list = app.WaitForElement("scoreList");

            // drag to create arrow
            app.DragCoordinates(500, 800, 470, 770);
            // drag to create arrow
            app.DragCoordinates(500, 800, 650, 870);
            // drag to create arrow
            app.DragCoordinates(500, 800, 470, 830);
            // drag to create arrow
            app.DragCoordinates(500, 800, 650, 730);

            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).First().Text);

            //select 0,1,2
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(2).Child(1).Child());

            //TranslationHelper.GetTextResource("UnSelect") 0,1
            app.Tap(e => e.Marked("scoreList").Child(0).Child(1).Child());
            app.Tap(e => e.Marked("scoreList").Child(1).Child(1).Child());
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            // wait 0,1,3
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).First().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).First().Text);
        }
    }
}
