using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private ScoreCounter counter;
        private TargetSetting targetSetting;
        private IArrowSetting arrowSetting;

        [SetUp]
        public void Init()
        {
            targetSetting = new TargetSetting();
            counter = new ScoreCounter(targetSetting);
            arrowSetting = EnglishArrowSetting.Instance;
        }

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(counter.CurrentArrows);
            Assert.Zero(counter.FlightScore);
            Assert.Zero(counter.TotalScore);
        }

        #region total calcul

        [Test]
        public void Counter_AddArrowTest()
        {
            var arrow1 = new Arrow(10, 0, arrowSetting);
            var arrow2 = new Arrow(9, 1, arrowSetting);
            var arrow3 = new Arrow(8, 2, arrowSetting);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(3, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.CurrentArrows[1]);
            Assert.AreEqual(arrow3, counter.CurrentArrows[2]);
        }

        [Test]
        public void Counter_AddRemoveArrowTest()
        {
            var arrow1 = new Arrow(10, 0, arrowSetting);
            var arrow2 = new Arrow(9, 1, arrowSetting);
            var arrow3 = new Arrow(10, 2, arrowSetting);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            counter.RemoveLastArrow();
            Assert.AreEqual(2, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.CurrentArrows[1]);

            counter.RemoveLastArrow();
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowTest()
        {
            var arrow1 = new Arrow(10, 0, arrowSetting);
            var arrow2 = new Arrow(9, 1, arrowSetting);
            var arrow3 = new Arrow(10, 2, arrowSetting);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowNewFlightTest()
        {
            var arrow1 = new Arrow(10, 0, arrowSetting);
            var arrow2 = new Arrow(9, 1, arrowSetting);
            var arrow3 = new Arrow(10, 2, arrowSetting);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(3, counter.CurrentArrows.Count);
            counter.NewFlight();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_ScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0, arrowSetting);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1, arrowSetting);
            counter.AddArrow(arrow2);

            Assert.AreEqual(19, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(2, counter.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2, arrowSetting);
            counter.AddArrow(arrow3);

            Assert.AreEqual(26, counter.FlightScore);
            Assert.AreEqual(26, counter.TotalScore);
            Assert.AreEqual(3, counter.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(19, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(2, counter.CurrentArrows.Count);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_TotalScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0, arrowSetting);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1, arrowSetting);
            counter.AddArrow(arrow2);

            Assert.AreEqual(9, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2, arrowSetting);
            counter.AddArrow(arrow3);
            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(26, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        #endregion total calcul

        [Test]
        public void CurrentArrowTest()
        {
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(2, 1, arrowSetting);
            var a3 = new Arrow(3, 2, arrowSetting);
            var a4 = new Arrow(4, 0, arrowSetting);
            var a5 = new Arrow(5, 1, arrowSetting);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(2, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a1));
            Assert.IsTrue(counter.CurrentArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.AddArrow(a3);
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.AddArrow(a4);
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void PreviousArrowTest()
        {
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(2, 1, arrowSetting);
            var a3 = new Arrow(3, 2, arrowSetting);
            var a4 = new Arrow(4, 0, arrowSetting);
            var a5 = new Arrow(5, 1, arrowSetting);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(0, counter.PreviousArrows.Count);

            counter.NewFlight();
            Assert.AreEqual(2, counter.PreviousArrows.Count);
            Assert.IsTrue(counter.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.PreviousArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(2, counter.PreviousArrows.Count);
            Assert.IsTrue(counter.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.PreviousArrows.Contains(a2));
        }

        [Test]
        public void AllArrowTest()
        {
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(2, 1, arrowSetting);
            var a3 = new Arrow(3, 2, arrowSetting);
            var a4 = new Arrow(4, 0, arrowSetting);
            var a5 = new Arrow(5, 1, arrowSetting);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(3, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
            Assert.IsTrue(counter.AllArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.AddArrow(a4);
            Assert.AreEqual(3, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
            Assert.IsTrue(counter.AllArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
        }

        [Test]
        public void ArrowsShowedTest()
        {
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(2, 1, arrowSetting);
            var a3 = new Arrow(3, 2, arrowSetting);
            var a4 = new Arrow(4, 0, arrowSetting);

            counter.AddArrow(a1);
            counter.AddArrow(a2);

            counter.NewFlight();
            counter.AddArrow(a3);
            counter.AddArrow(a4);

            Assert.AreEqual(counter.CurrentArrows, counter.ArrowsShowed);
            targetSetting.ShowAllArrows = true;
            Assert.AreEqual(counter.AllArrows, counter.ArrowsShowed);
        }

        [Test]
        public void UpdateOrderBeforeTest()
        {
            targetSetting.IsDecreasingOrder = true;
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(8, 0, arrowSetting);
            var a3 = new Arrow(5, 0, arrowSetting);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            Assert.AreEqual(a2, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderAfetrTest()
        {
            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(8, 0, arrowSetting);
            var a3 = new Arrow(5, 0, arrowSetting);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            targetSetting.IsDecreasingOrder = true;

            Assert.AreEqual(a2, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderbeforeAndAfetrTest()
        {
            targetSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(1, 0, arrowSetting);
            var a2 = new Arrow(8, 1, arrowSetting);
            var a3 = new Arrow(5, 2, arrowSetting);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            targetSetting.IsDecreasingOrder = false;

            // keep the same order
            Assert.AreEqual(a1, counter.CurrentArrows[0]);
            Assert.AreEqual(a2, counter.CurrentArrows[1]);
            Assert.AreEqual(a3, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderWithSameScoreTest()
        {
            targetSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(11, 0, arrowSetting);
            var a2 = new Arrow(10, 0, arrowSetting);
            var a3 = new Arrow(11, 0, arrowSetting);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            // keep the same order
            Assert.AreEqual(a1, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a2, counter.CurrentArrows[2]);
        }
    }
}
