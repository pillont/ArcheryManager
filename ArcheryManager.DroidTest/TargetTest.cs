using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    [TestFixture]
    public class TargetTest
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
            app.Screenshot("BackDoor Page");
            app.Tap("TargetButton");
            app.Screenshot("Target page");
        }

        [Test]
        public void InitScoreTargetElement()
        {
            app.WaitForElement("FlightScoreTitle");
            app.WaitForElement("TotalScoreTitle");
        }

        [Test]
        public void InitTargetElement()
        {
            Assert.AreEqual(961, app.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(872, app.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(782, app.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(693, app.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(604, app.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(514, app.WaitForElement("zone6").First().Rect.Height);
            Assert.AreEqual(425, app.WaitForElement("zone7").First().Rect.Height);
            Assert.AreEqual(336, app.WaitForElement("zone8").First().Rect.Height);
            Assert.AreEqual(247, app.WaitForElement("zone9").First().Rect.Height);
            Assert.AreEqual(158, app.WaitForElement("zone10").First().Rect.Height);
            Assert.AreEqual(68, app.WaitForElement("zone11").First().Rect.Height);
            Assert.AreEqual(6, app.WaitForElement("center").First().Rect.Height);

            Assert.AreEqual(961, app.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(872, app.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(782, app.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(693, app.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(604, app.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(514, app.WaitForElement("zone6").First().Rect.Width);
            Assert.AreEqual(425, app.WaitForElement("zone7").First().Rect.Width);
            Assert.AreEqual(336, app.WaitForElement("zone8").First().Rect.Width);
            Assert.AreEqual(247, app.WaitForElement("zone9").First().Rect.Width);
            Assert.AreEqual(158, app.WaitForElement("zone10").First().Rect.Width);
            Assert.AreEqual(68, app.WaitForElement("zone11").First().Rect.Width);
            Assert.AreEqual(6, app.WaitForElement("center").First().Rect.Width);
        }

        [Test]
        public void InitCommandTargetElement()
        {
            app.WaitForElement("nextFlight");
            app.WaitForElement("removeAllArrows");
            app.WaitForElement("removeArrow");
        }

        [Test]
        public void InitArrowGridsTargetElement()
        {
            app.WaitForElement("arrowInTargetGrid");
            app.WaitForElement("scoreList");
        }

        [Test]
        public void ArrowShowInTarget()
        {
            app.WaitForElement("arrowInTargetGrid");
            app.DragCoordinates(500, 800, 600, 900);
            //TODO test : found test and shape        
            app.WaitForElement("arrowInTargetGrid");
            app.DragCoordinates(500, 800, 450, 750);
            //TODO test : found test and shape        
        }

        [Test]
        public void ArrowShowInList()
        {
        }
    }
}
