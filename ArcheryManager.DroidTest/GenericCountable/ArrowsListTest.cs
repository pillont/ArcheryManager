using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.GenericCountable
{
    [TestFixture]
    public class ArrowsListTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("indoorCompoundTargetButton");
            app.Screenshot("Target page");

            app.WaitForElement("scoreList"); //update visual
        }

        [Test]
        public void AddArrowInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 750); // add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 850);// add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 300, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual(3, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("M", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 550, 825);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("M", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 450, 750);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("M", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
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

            app.DragCoordinates(500, 800, 700, 800);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 550, 815);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 460, 770);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
            Assert.AreEqual(6, app.Query(e => e.Marked("scoreList").Child()).Count());

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 750); // add arrow
            app.WaitForElement("9");

            app.DragCoordinates(500, 800, 500, 850);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());

            app.DragCoordinates(500, 800, 350, 780);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());

            app.DragCoordinates(500, 800, 720, 800);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 550, 830);// add arrow
            Assert.AreEqual(3, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 450, 770);// add arrow
            Assert.AreEqual(4, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());
        }

        [Test]
        public void PositionArrowInMultiLineTest()
        {
            app.DragCoordinates(500, 800, 500, 750); // add arrow
            app.DragCoordinates(500, 800, 500, 850);// add arrow
            app.DragCoordinates(500, 800, 400, 800);// add arrow
            app.DragCoordinates(500, 800, 650, 800);// add arrow
            app.DragCoordinates(500, 800, 525, 825);// add arrow
            app.DragCoordinates(500, 800, 475, 775);// add arrow
            app.DragCoordinates(500, 800, 500, 775);// add arrow
            app.DragCoordinates(500, 800, 500, 825);// add arrow
            app.DragCoordinates(500, 800, 485, 785);// add arrow
            app.DragCoordinates(500, 800, 650, 800);// add arrow
            app.DragCoordinates(500, 800, 525, 825);// add arrow
            app.DragCoordinates(500, 800, 475, 775);// add arrow

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 750); // add arrow
            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);

            app.DragCoordinates(500, 800, 500, 850);// add arrow
            Assert.AreEqual(188, app.WaitForElement("9").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 350, 800);// add arrow
            Assert.AreEqual(318, app.WaitForElement("8").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 700, 800);// add arrow
            Assert.AreEqual(448, app.WaitForElement("7").Last().Rect.CenterX);
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
            app.DragCoordinates(500, 800, 300, 800);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 500, 630); // add arrow

            Assert.AreEqual(448, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(58, app.WaitForElement("9").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("M").Last().Rect.CenterX);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("M").Last().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);

            //remove arrow
            app.Tap(TranslateExtension.GetTextResource("RemoveLast"));

            Assert.AreEqual(1, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("M").Count());
            Assert.AreEqual(4, app.WaitForElement("9").Count());
        }

        [Test]
        public void RemoveByCheckInMultiLineTest()
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
            app.DragCoordinates(500, 800, 300, 800);// add arrow
            app.DragCoordinates(500, 800, 800, 800);// add arrow
            app.DragCoordinates(500, 800, 500, 700); // add arrow

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("M").Last().Rect.CenterX);
            Assert.AreEqual(448, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9").Index(1));
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("M").Last().Rect.CenterX);

            //remove arrow
            app.Tap("M");
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9"));
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual(58, app.WaitForElement("7").First().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("7"));
            app.Tap(TranslateExtension.GetTextResource("RemoveSelect"));

            Assert.AreEqual(1, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("M").Count());
            Assert.AreEqual(4, app.WaitForElement("9").Count());
        }
    }
}
