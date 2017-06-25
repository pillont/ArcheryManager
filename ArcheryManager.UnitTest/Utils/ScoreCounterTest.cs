using ArcheryManager.Utils;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private ScoreCounter counter;

        [SetUp]
        public void Init()
        {
            counter = new ScoreCounter();
        }

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(counter.CurrentArrows);
            Assert.Zero(counter.FlightScore);
            Assert.Zero(counter.TotalScore);
        }

        [Test]
        public void Counter_AddArrowTest()
        {
            var arrow1 = new Arrow("10", 10, Color.Yellow);
            var arrow2 = new Arrow("9", 9, Color.Yellow);
            var arrow3 = new Arrow("8", 8, Color.Red);

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
            var arrow1 = new Arrow("10", 10, Color.Yellow);
            var arrow2 = new Arrow("9", 9, Color.Yellow);
            var arrow3 = new Arrow("10", 10, Color.Yellow);

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
            var arrow1 = new Arrow("10", 10, Color.Yellow);
            var arrow2 = new Arrow("9", 9, Color.Yellow);
            var arrow3 = new Arrow("10", 10, Color.Yellow);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowNewFlightTest()
        {
            var arrow1 = new Arrow("10", 10, Color.Yellow);
            var arrow2 = new Arrow("9", 9, Color.Yellow);
            var arrow3 = new Arrow("10", 10, Color.Yellow);

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

            var arrow1 = new Arrow("10", 10, Color.Yellow);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow2 = new Arrow("9", 9, Color.Yellow);
            counter.AddArrow(arrow2);

            Assert.AreEqual(19, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(2, counter.CurrentArrows.Count);

            var arrow3 = new Arrow("7", 7, Color.Red);
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

            var arrow1 = new Arrow("10", 10, Color.Yellow);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow2 = new Arrow("9", 9, Color.Yellow);
            counter.AddArrow(arrow2);

            Assert.AreEqual(9, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow3 = new Arrow("7", 7, Color.Red);
            counter.AddArrow(arrow3);
            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(26, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }
    }
}
