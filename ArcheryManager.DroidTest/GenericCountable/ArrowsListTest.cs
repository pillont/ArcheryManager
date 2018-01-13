using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.DroidTest.StepDefinition;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;
using System;

namespace ArcheryManager.DroidTest.GenericCountable
{
    [TestFixture]
    public class ArrowsListTest
    {
        private AndroidApp app;

        [Test]
        public void AddArrowInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 725); // add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 900);// add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 275, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual(3, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 900, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("6", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 550, 850);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("6", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 450, 750);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("6", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
            Assert.AreEqual(6, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 785);// add arrow
            app.WaitForElement(e => e.Marked("scoreList").Child(0).Child(1).Child().Text("10"));
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 813);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 490, 790);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual(3, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 725, 800);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 575, 875);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 425, 725);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
            Assert.AreEqual(6, app.Query(e => e.Marked("scoreList").Child()).Count());

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 725); // add arrow
            app.WaitForElement("9");

            app.DragCoordinates(500, 800, 500, 875);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());

            app.DragCoordinates(500, 800, 300, 700);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 550, 875);// add arrow
            Assert.AreEqual(3, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 450, 720);// add arrow
            Assert.AreEqual(4, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.WaitForElement("indoorCompoundTargetButton");
            app.Tap("indoorCompoundTargetButton");
            app.WaitForElement("scoreList"); //update visual
        }

        [Test]
        public void PositionArrowInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 730); // add arrow
            app.DragCoordinates(500, 800, 500, 870);// add arrow
            app.DragCoordinates(500, 800, 350, 800);// add arrow
            app.DragCoordinates(500, 800, 670, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow
            app.DragCoordinates(500, 800, 675, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 725);// add arrow
            Assert.AreEqual(81, app.WaitForElement("9").First().Rect.CenterX);

            app.DragCoordinates(500, 800, 500, 875);// add arrow
            Assert.AreEqual(264, app.WaitForElement("9").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 250, 800);// add arrow
            Assert.AreEqual(447, app.WaitForElement("8").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual(630, app.WaitForElement("7").Last().Rect.CenterX);
        }

        [Test]
        public void RemoveByCheckInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 700);// add arrow
            app.DragCoordinates(500, 800, 500, 900);// add arrow
            app.DragCoordinates(500, 800, 300, 800);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 850);// add arrow
            app.DragCoordinates(500, 800, 470, 770);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 350, 700);// add arrow

            app.DragCoordinates(500, 800, 500, 950);// add arrow
            app.DragCoordinates(500, 800, 250, 800);// add arrow
            app.DragCoordinates(500, 800, 850, 800);// add arrow
            app.DragCoordinates(500, 800, 500, 650);// add arrow

            Assert.AreEqual(81, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(264, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(447, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(630, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9").Index(1));
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual(81, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(264, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(447, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap("8");
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual(81, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(264, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9"));
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual(81, app.WaitForElement("7").First().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("7"));
            app.Tap(TranslationHelper.GetTextResource("RemoveSelect"));

            Assert.AreEqual(4, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("7").Count());
            Assert.AreEqual(1, app.WaitForElement("9").Count());
        }

        [Test]
        public void RemoveLastInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 700); // add arrow
            app.DragCoordinates(500, 800, 500, 900);// add arrow
            app.DragCoordinates(500, 800, 300, 800);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 850);// add arrow
            app.DragCoordinates(500, 800, 470, 770);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 550, 850);// add arrow
            app.DragCoordinates(500, 800, 450, 750);// add arrow
            app.DragCoordinates(500, 800, 500, 900);// add arrow
            app.DragCoordinates(500, 800, 250, 800);// add arrow
            app.DragCoordinates(500, 800, 900, 800);// add arrow
            app.DragCoordinates(500, 800, 500, 570); // add arrow

            Assert.AreEqual(630, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(447, app.WaitForElement("6").Last().Rect.CenterX);
            Assert.AreEqual(264, app.WaitForElement("8").First().Rect.CenterX);
            Assert.AreEqual(81, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            RemoveArrow("8", 1);

            Assert.AreEqual(447, app.WaitForElement("6").Last().Rect.CenterX);
            Assert.AreEqual(264, app.WaitForElement("8").First().Rect.CenterX);
            Assert.AreEqual(81, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            RemoveArrow("6");

            Assert.AreEqual(264, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(81, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            RemoveArrow("8");

            Assert.AreEqual(81, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            RemoveArrow("9");

            Assert.AreEqual(5, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("7").Count());
        }

        private void RemoveArrow(string score, int index = 0)
        {
            app.Tap(e => e.Text(score).Index(index));
            TestSetting.App.Tap(e => e.Marked(TranslationHelper.GetTextResource("RemoveSelect")));
        }
    }
}
