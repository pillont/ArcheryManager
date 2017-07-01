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
            app.DragCoordinates(500, 800, 500, 700); // add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 900);// add arrow

            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 300, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual(3, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 550, 850);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 450, 750);// add arrow
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("8", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
            Assert.AreEqual(6, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 750);// add arrow
            app.WaitForElement(e => e.Marked("scoreList").Child(0).Child(1).Child().Text("10"));
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual(1, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 500, 850);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual(2, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 470, 770);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual(3, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual(4, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 550, 850);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual(5, app.Query(e => e.Marked("scoreList").Child()).Count());

            app.DragCoordinates(500, 800, 450, 750);// add arrow
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(0).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(1).Child(1).Child()).Last().Text);
            Assert.AreEqual("10", app.Query(e => e.Marked("scoreList").Child(2).Child(1).Child()).Last().Text);
            Assert.AreEqual("7", app.Query(e => e.Marked("scoreList").Child(3).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(4).Child(1).Child()).Last().Text);
            Assert.AreEqual("9", app.Query(e => e.Marked("scoreList").Child(5).Child(1).Child()).Last().Text);
            Assert.AreEqual(6, app.Query(e => e.Marked("scoreList").Child()).Count());

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 700); // add arrow
            app.WaitForElement("9");

            app.DragCoordinates(500, 800, 500, 900);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());

            app.DragCoordinates(500, 800, 300, 800);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());

            app.DragCoordinates(500, 800, 800, 800);// add arrow
            Assert.AreEqual(2, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 550, 850);// add arrow
            Assert.AreEqual(3, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());

            app.DragCoordinates(500, 800, 450, 750);// add arrow
            Assert.AreEqual(4, app.Query("9").Count());
            Assert.AreEqual(1, app.Query("8").Count());
            Assert.AreEqual(1, app.Query("7").Count());
        }

        [Test]
        public void PositionArrowInMultiLineTest()
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

            //NOTE : can not use e.Marked("scoreList").Child because center of the list not in the view...
            app.DragCoordinates(500, 800, 500, 700); // add arrow
            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);

            app.DragCoordinates(500, 800, 500, 900);// add arrow
            Assert.AreEqual(188, app.WaitForElement("9").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 300, 800);// add arrow
            Assert.AreEqual(318, app.WaitForElement("8").Last().Rect.CenterX);

            app.DragCoordinates(500, 800, 800, 800);// add arrow
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
            app.DragCoordinates(500, 800, 500, 700); // add arrow

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(448, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            app.Tap("Remove last");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap("Remove last");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);

            //remove arrow
            app.Tap("Remove last");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);

            //remove arrow
            app.Tap("Remove last");

            Assert.AreEqual(3, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("7").Count());
            Assert.AreEqual(2, app.WaitForElement("9").Count());
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
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("7").Last().Rect.CenterX);
            Assert.AreEqual(448, app.WaitForElement("9").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9").Index(1));
            app.Tap("Remove");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);
            Assert.AreEqual(318, app.WaitForElement("7").Last().Rect.CenterX);

            //remove arrow
            app.Tap("7");
            app.Tap("Remove");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);
            Assert.AreEqual(188, app.WaitForElement("8").Last().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("8"));
            app.Tap("Remove");

            Assert.AreEqual(58, app.WaitForElement("9").First().Rect.CenterX);

            //remove arrow
            app.Tap(c => c.Marked("9"));
            app.Tap("Remove");

            Assert.AreEqual(3, app.WaitForElement("10").Count());
            Assert.AreEqual(1, app.WaitForElement("7").Count());
            Assert.AreEqual(2, app.WaitForElement("9").Count());
        }
    }
}
