using ArcheryManager.Interfaces;
using ArcheryManager.Models;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private ScoreCounter counter;
        private IArrowSetting arrowSetting;
        private CountSetting countSetting;
        private GeneralCounterSetting generalCounterSetting;

        [SetUp]
        public void Init()
        {
            countSetting = new CountSetting();
            arrowSetting = EnglishArrowSetting.Instance;
            var result = new ScoreResult();
            generalCounterSetting = new GeneralCounterSetting()
            {
                CountSetting = countSetting,
                ArrowSetting = arrowSetting,
                ScoreResult = result
            };
            counter = new ScoreCounter(generalCounterSetting);
        }

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(generalCounterSetting.ScoreResult.CurrentArrows);
            Assert.Zero(generalCounterSetting.ScoreResult.FlightScore);
            Assert.Zero(generalCounterSetting.ScoreResult.TotalScore);
        }

        #region total calcul

        [Test]
        public void Counter_AddArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(8, 2);

            counter.AddArrowIfPossible(arrow1);
            counter.AddArrowIfPossible(arrow2);
            counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual(3, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.AreEqual(arrow1, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(arrow2, generalCounterSetting.ScoreResult.CurrentArrows[1]);
            Assert.AreEqual(arrow3, generalCounterSetting.ScoreResult.CurrentArrows[2]);
        }

        [Test]
        public void Counter_AddRemoveArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrowIfPossible(arrow1);
            counter.AddArrowIfPossible(arrow2);
            counter.AddArrowIfPossible(arrow3);

            counter.RemoveLastArrow();
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.AreEqual(arrow1, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(arrow2, generalCounterSetting.ScoreResult.CurrentArrows[1]);

            counter.RemoveLastArrow();
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.AreEqual(arrow1, generalCounterSetting.ScoreResult.CurrentArrows[0]);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrowIfPossible(arrow1);
            counter.AddArrowIfPossible(arrow2);
            counter.AddArrowIfPossible(arrow3);

            counter.ClearArrows();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowNewFlightTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrowIfPossible(arrow1);
            counter.AddArrowIfPossible(arrow2);
            counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual(3, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            counter.NewFlight();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        [Test]
        public void Counter_ScoreUpdateTest()
        {
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrowIfPossible(arrow1);

            Assert.AreEqual(10, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(10, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrowIfPossible(arrow2);

            Assert.AreEqual(19, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(19, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual(26, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(26, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(3, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(19, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(19, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.ClearArrows();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        [Test]
        public void Counter_TotalScoreUpdateTest()
        {
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrowIfPossible(arrow1);

            Assert.AreEqual(10, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(10, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.NewFlight();

            Assert.AreEqual(0, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(10, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrowIfPossible(arrow2);

            Assert.AreEqual(9, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(19, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrowIfPossible(arrow3);
            counter.NewFlight();

            Assert.AreEqual(0, generalCounterSetting.ScoreResult.FlightScore);
            Assert.AreEqual(26, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        #endregion total calcul

        [Test]
        public void CurrentArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.CurrentArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.CurrentArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.AddArrowIfPossible(a3);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.CurrentArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);

            counter.AddArrowIfPossible(a4);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.CurrentArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.CurrentArrows.Count);
        }

        [Test]
        public void PreviousArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            Assert.AreEqual(0, generalCounterSetting.ScoreResult.PreviousArrows.Count);

            counter.NewFlight();
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.PreviousArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.PreviousArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.PreviousArrows.Contains(a2));

            counter.AddArrowIfPossible(a3);
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.PreviousArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.PreviousArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.PreviousArrows.Contains(a2));
        }

        [Test]
        public void AllArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));

            counter.AddArrowIfPossible(a3);
            Assert.AreEqual(3, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));

            counter.AddArrowIfPossible(a4);
            Assert.AreEqual(3, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(2, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a1));
            Assert.IsTrue(generalCounterSetting.ScoreResult.AllArrows.Contains(a2));
        }

        [Test]
        public void ArrowsShowedTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);

            counter.NewFlight();
            counter.AddArrowIfPossible(a3);
            counter.AddArrowIfPossible(a4);

            Assert.AreEqual(generalCounterSetting.ScoreResult.CurrentArrows, counter.ArrowsShowed);
            countSetting.ShowAllArrows = true;
            Assert.AreEqual(generalCounterSetting.ScoreResult.AllArrows, counter.ArrowsShowed);
        }

        [Test]
        public void UpdateOrderBeforeTest()
        {
            countSetting.IsDecreasingOrder = true;
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 0);
            var a3 = new Arrow(5, 0);
            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.AddArrowIfPossible(a3);

            Assert.AreEqual(a2, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(a3, generalCounterSetting.ScoreResult.CurrentArrows[1]);
            Assert.AreEqual(a1, generalCounterSetting.ScoreResult.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderAfetrTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 0);
            var a3 = new Arrow(5, 0);
            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.AddArrowIfPossible(a3);
            countSetting.IsDecreasingOrder = true;

            Assert.AreEqual(a2, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(a3, generalCounterSetting.ScoreResult.CurrentArrows[1]);
            Assert.AreEqual(a1, generalCounterSetting.ScoreResult.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderbeforeAndAfetrTest()
        {
            countSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 1);
            var a3 = new Arrow(5, 2);
            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.AddArrowIfPossible(a3);
            countSetting.IsDecreasingOrder = false;

            // keep the same order
            Assert.AreEqual(a1, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(a2, generalCounterSetting.ScoreResult.CurrentArrows[1]);
            Assert.AreEqual(a3, generalCounterSetting.ScoreResult.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderWithSameScoreTest()
        {
            countSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(11, 0);
            var a2 = new Arrow(10, 0);
            var a3 = new Arrow(11, 0);
            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.AddArrowIfPossible(a3);

            // keep the same order
            Assert.AreEqual(a1, generalCounterSetting.ScoreResult.CurrentArrows[0]);
            Assert.AreEqual(a3, generalCounterSetting.ScoreResult.CurrentArrows[1]);
            Assert.AreEqual(a2, generalCounterSetting.ScoreResult.CurrentArrows[2]);
        }

        [Test]
        public void RestartTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 0);
            var a3 = new Arrow(3, 0);
            var a4 = new Arrow(4, 0);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.NewFlight();
            counter.AddArrowIfPossible(a3);
            counter.AddArrowIfPossible(a4);

            counter.RestartCount();

            Assert.IsEmpty(generalCounterSetting.ScoreResult.AllArrows);
            Assert.Zero(generalCounterSetting.ScoreResult.TotalScore);
            Assert.Zero(generalCounterSetting.ScoreResult.FlightScore);
        }

        [Test]
        public void RestartAndContinueTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 0);
            var a3 = new Arrow(3, 0);
            var a4 = new Arrow(4, 0);

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.NewFlight();
            counter.AddArrowIfPossible(a3);
            counter.AddArrowIfPossible(a4);

            counter.RestartCount();

            counter.AddArrowIfPossible(a1);
            counter.AddArrowIfPossible(a2);
            counter.AddArrowIfPossible(a3);
            counter.NewFlight();
            counter.AddArrowIfPossible(a4);

            Assert.AreEqual(4, generalCounterSetting.ScoreResult.AllArrows.Count);
            Assert.AreEqual(1, generalCounterSetting.ScoreResult.CurrentArrows.Count);
            Assert.AreEqual(3, generalCounterSetting.ScoreResult.PreviousArrows.Count);
            Assert.AreEqual(10, generalCounterSetting.ScoreResult.TotalScore);
            Assert.AreEqual(4, generalCounterSetting.ScoreResult.FlightScore);
        }

        [Test]
        public void DefaultScoreStringTest()
        {
            Assert.AreEqual("0/0", counter.FlightScoreString);
            Assert.AreEqual("0/0", counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringBeforeNewArrowTest()
        {
            counter.AddArrowIfPossible(new Arrow(1, 0));
            counter.AddArrowIfPossible(new Arrow(2, 0));
            counter.AddArrowIfPossible(new Arrow(3, 0));

            Assert.AreEqual("6/30", counter.FlightScoreString);
            Assert.AreEqual("6/30", counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringInNewArrowTest()
        {
            counter.AddArrowIfPossible(new Arrow(1, 0));
            counter.AddArrowIfPossible(new Arrow(2, 0));
            counter.AddArrowIfPossible(new Arrow(3, 0));
            counter.NewFlight();

            Assert.AreEqual("0/0", counter.FlightScoreString);
            Assert.AreEqual("6/30", counter.TotalScoreString);
        }

        [Test]
        public void TotalScoreTest()
        {
            counter.AddArrowIfPossible(new Arrow(1, 0));
            counter.AddArrowIfPossible(new Arrow(2, 0));
            counter.AddArrowIfPossible(new Arrow(3, 0));
            counter.NewFlight();
            counter.AddArrowIfPossible(new Arrow(4, 0));
            counter.AddArrowIfPossible(new Arrow(5, 0));

            Assert.AreEqual("9/20", counter.FlightScoreString);
            Assert.AreEqual("15/50", counter.TotalScoreString);
        }
    }
}
