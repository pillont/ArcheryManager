using ArcheryManager.Entities;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Linq;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private CounterManager Manager;

        private ScoreCounter Counter => Manager.Counter;

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(Manager.CurrentShoot.CurrentArrows);
            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("0/0", Manager.Counter.TotalScoreString);
        }

        [Test]
        public void CurrentArrowTest()
        {
            var a1 = new Arrow() { Index = 1, NumberInFlight = 0 };
            var a2 = new Arrow() { Index = 2, NumberInFlight = 1 };
            var a3 = new Arrow() { Index = 3, NumberInFlight = 2 };
            var a4 = new Arrow() { Index = 4, NumberInFlight = 0 };
            var a5 = new Arrow() { Index = 5, NumberInFlight = 1 };

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Assert.AreEqual(2, Manager.CurrentShoot.CurrentArrows.Count);
            Assert.IsTrue(Manager.CurrentShoot.CurrentArrows.Contains(a1));
            Assert.IsTrue(Manager.CurrentShoot.CurrentArrows.Contains(a2));

            Counter.NewFlight();
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count);

            Counter.AddArrowIfPossible(a3);
            Assert.AreEqual(1, Manager.CurrentShoot.CurrentArrows.Count);
            Assert.IsTrue(Manager.CurrentShoot.CurrentArrows.Contains(a3));

            Counter.RemoveLastArrow();
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count);

            Counter.AddArrowIfPossible(a4);
            Assert.AreEqual(1, Manager.CurrentShoot.CurrentArrows.Count);
            Assert.IsTrue(Manager.CurrentShoot.CurrentArrows.Contains(a4));

            Counter.ClearArrows();
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count);
        }

        [Test]
        public void DefaultScoreStringBeforeNewArrowTest()
        {
            Counter.AddArrowIfPossible(new Arrow() { Index = 1, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 2, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 3, NumberInFlight = 0 });

            Assert.AreEqual("6/30", Counter.FlightScoreString);
            Assert.AreEqual("6/30", Counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringInNewArrowTest()
        {
            Counter.AddArrowIfPossible(new Arrow() { Index = 1, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 2, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 3, NumberInFlight = 0 });
            Counter.NewFlight();

            Assert.AreEqual("0/0", Counter.FlightScoreString);
            Assert.AreEqual("6/30", Counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringTest()
        {
            Assert.AreEqual("0/0", Counter.FlightScoreString);
            Assert.AreEqual("0/0", Counter.TotalScoreString);
        }

        [SetUp]
        public void Init()
        {
            Manager = new CounterManager() { CurrentShoot = new CountedShoot() };
            Manager.Counter.NewFlight();

            RegisterHelperTest.InitTestRegister(Manager);
        }

        [Test]
        public void PreviousArrowTest()
        {
            var a1 = new Arrow() { Index = 1, NumberInFlight = 0 };
            var a2 = new Arrow() { Index = 2, NumberInFlight = 1 };
            var a3 = new Arrow() { Index = 3, NumberInFlight = 2 };
            var a4 = new Arrow() { Index = 4, NumberInFlight = 0 };
            var a5 = new Arrow() { Index = 5, NumberInFlight = 1 };

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Assert.AreEqual(0, Manager.Counter.PreviousArrow.Count());

            Counter.NewFlight();
            Assert.AreEqual(2, Manager.Counter.PreviousArrow.Count());
            Assert.IsTrue(Manager.Counter.PreviousArrow.Contains(a1));
            Assert.IsTrue(Manager.Counter.PreviousArrow.Contains(a2));

            Counter.AddArrowIfPossible(a3);
            Assert.AreEqual(2, Manager.Counter.PreviousArrow.Count());
            Assert.IsTrue(Manager.Counter.PreviousArrow.Contains(a1));
            Assert.IsTrue(Manager.Counter.PreviousArrow.Contains(a2));
        }

        [Test]
        public void RestartAndContinueTest()
        {
            var a1 = new Arrow() { Index = 1, };
            var a2 = new Arrow() { Index = 2, };
            var a3 = new Arrow() { Index = 3, };
            var a4 = new Arrow() { Index = 4, };

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.NewFlight();
            Counter.AddArrowIfPossible(a3);
            Counter.AddArrowIfPossible(a4);

            Counter.RestartCount();

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);
            Counter.NewFlight();
            Counter.AddArrowIfPossible(a4);

            Assert.AreEqual(1, Manager.Counter.CurrentArrows.Count());
            Assert.AreEqual(3, Manager.Counter.PreviousArrow.Count());
            Assert.AreEqual("10/40", Manager.Counter.TotalScoreString);
            Assert.AreEqual("4/10", Manager.Counter.FlightScoreString);
        }

        [Test]
        public void RestartTest()
        {
            var a1 = new Arrow() { Index = 1, };
            var a2 = new Arrow() { Index = 2, };
            var a3 = new Arrow() { Index = 3, };
            var a4 = new Arrow() { Index = 4, };

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.NewFlight();
            Counter.AddArrowIfPossible(a3);
            Counter.AddArrowIfPossible(a4);

            Counter.RestartCount();

            Assert.AreEqual("0/0", Manager.Counter.TotalScoreString);
            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
        }

        [Test]
        public void TotalScoreTest()
        {
            Counter.AddArrowIfPossible(new Arrow() { Index = 1, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 2, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 3, NumberInFlight = 0 });
            Counter.NewFlight();
            Counter.AddArrowIfPossible(new Arrow() { Index = 4, NumberInFlight = 0 });
            Counter.AddArrowIfPossible(new Arrow() { Index = 5, NumberInFlight = 0 });

            Assert.AreEqual("9/20", Counter.FlightScoreString);
            Assert.AreEqual("15/50", Counter.TotalScoreString);
        }

        [Test]
        public void UpdateOrderAfetrTest()
        {
            var a1 = new Arrow() { Index = 1, };
            var a2 = new Arrow() { Index = 8, };
            var a3 = new Arrow() { Index = 5, };
            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);
            Manager.CurrentShoot.IsDecreasingOrder = true;

            Assert.AreEqual(a2, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(a3, Manager.Counter.CurrentArrows.ToList()[1]);
            Assert.AreEqual(a1, Manager.Counter.CurrentArrows.ToList()[2]);
        }

        [Test]
        public void UpdateOrderbeforeAndAfetrTest()
        {
            Manager.CurrentShoot.IsDecreasingOrder = true;

            var a1 = new Arrow() { Index = 1, NumberInFlight = 0 };
            var a2 = new Arrow() { Index = 8, NumberInFlight = 1 };
            var a3 = new Arrow() { Index = 5, NumberInFlight = 2 };
            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);
            Manager.CurrentShoot.IsDecreasingOrder = false;

            // keep the same order
            Assert.AreEqual(a1, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(a2, Manager.Counter.CurrentArrows.ToList()[1]);
            Assert.AreEqual(a3, Manager.Counter.CurrentArrows.ToList()[2]);
        }

        [Test]
        public void UpdateOrderBeforeTest()
        {
            Manager.CurrentShoot.IsDecreasingOrder = true;
            var a1 = new Arrow() { Index = 1, };
            var a2 = new Arrow() { Index = 8, };
            var a3 = new Arrow() { Index = 5, };
            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);

            Assert.AreEqual(a2, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(a3, Manager.Counter.CurrentArrows.ToList()[1]);
            Assert.AreEqual(a1, Manager.Counter.CurrentArrows.ToList()[2]);
        }

        [Test]
        public void UpdateOrderWithSameScoreTest()
        {
            Manager.CurrentShoot.IsDecreasingOrder = true;

            var a1 = new Arrow() { Index = 11, };
            var a2 = new Arrow() { Index = 10, };
            var a3 = new Arrow() { Index = 11, };
            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);

            // keep the same order
            Assert.AreEqual(a1, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(a3, Manager.Counter.CurrentArrows.ToList()[1]);
            Assert.AreEqual(a2, Manager.Counter.CurrentArrows.ToList()[2]);
        }

        #region total calcul

        [Test]
        public void Counter_AddArrowTest()
        {
            var arrow1 = new Arrow() { Index = 10, NumberInFlight = 0 };
            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            var arrow3 = new Arrow() { Index = 8, NumberInFlight = 2 };

            Counter.AddArrowIfPossible(arrow1);
            Counter.AddArrowIfPossible(arrow2);
            Counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual(3, Manager.Counter.CurrentArrows.Count());
            Assert.AreEqual(arrow1, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(arrow2, Manager.Counter.CurrentArrows.ToList()[1]);
            Assert.AreEqual(arrow3, Manager.Counter.CurrentArrows.ToList()[2]);
        }

        [Test]
        public void Counter_AddRemoveArrowTest()
        {
            var arrow1 = new Arrow() { Index = 10, NumberInFlight = 0 };
            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            var arrow3 = new Arrow() { Index = 10, NumberInFlight = 2 };

            Counter.AddArrowIfPossible(arrow1);
            Counter.AddArrowIfPossible(arrow2);
            Counter.AddArrowIfPossible(arrow3);

            Counter.RemoveLastArrow();
            Assert.AreEqual(2, Manager.Counter.CurrentArrows.Count());
            Assert.AreEqual(arrow1, Manager.Counter.CurrentArrows.ToList()[0]);
            Assert.AreEqual(arrow2, Manager.Counter.CurrentArrows.ToList()[1]);

            Counter.RemoveLastArrow();
            Assert.AreEqual(1, Manager.Counter.CurrentArrows.Count());
            Assert.AreEqual(arrow1, Manager.Counter.CurrentArrows.ToList()[0]);

            Counter.RemoveLastArrow();
            Assert.AreEqual(0, Manager.Counter.CurrentArrows.Count());

            Counter.RemoveLastArrow();
            Assert.AreEqual(0, Manager.Counter.CurrentArrows.Count());
        }

        [Test]
        public void Counter_RemoveAllArrowNewFlightTest()
        {
            var arrow1 = new Arrow() { Index = 10, NumberInFlight = 0 };
            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            var arrow3 = new Arrow() { Index = 10, NumberInFlight = 2 };

            Counter.AddArrowIfPossible(arrow1);
            Counter.AddArrowIfPossible(arrow2);
            Counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual(3, Manager.CurrentShoot.CurrentArrows.Count());
            Counter.NewFlight();
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());
        }

        [Test]
        public void Counter_RemoveAllArrowTest()
        {
            var arrow1 = new Arrow() { Index = 10, NumberInFlight = 0 };
            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            var arrow3 = new Arrow() { Index = 10, NumberInFlight = 2 };

            Counter.AddArrowIfPossible(arrow1);
            Counter.AddArrowIfPossible(arrow2);
            Counter.AddArrowIfPossible(arrow3);

            Counter.ClearArrows();
            Assert.AreEqual(0, Manager.Counter.CurrentArrows.ToList().Count());
        }

        [Test]
        public void Counter_ScoreUpdateTest()
        {
            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("0/0", Manager.Counter.TotalScoreString);
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow1 = new Arrow() { Index = 10, };
            Counter.AddArrowIfPossible(arrow1);

            Assert.AreEqual("10/10", Manager.Counter.FlightScoreString);
            Assert.AreEqual("10/10", Manager.Counter.TotalScoreString);
            Assert.AreEqual(1, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            Counter.AddArrowIfPossible(arrow2);

            Assert.AreEqual("19/20", Manager.Counter.FlightScoreString);
            Assert.AreEqual("19/20", Manager.Counter.TotalScoreString);
            Assert.AreEqual(2, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow3 = new Arrow() { Index = 7, NumberInFlight = 2 };
            Counter.AddArrowIfPossible(arrow3);

            Assert.AreEqual("26/30", Manager.Counter.FlightScoreString);
            Assert.AreEqual("26/30", Manager.Counter.TotalScoreString);
            Assert.AreEqual(3, Manager.CurrentShoot.CurrentArrows.Count());

            Counter.RemoveLastArrow();
            Assert.AreEqual("19/20", Manager.Counter.FlightScoreString);
            Assert.AreEqual("19/20", Manager.Counter.TotalScoreString);
            Assert.AreEqual(2, Manager.CurrentShoot.CurrentArrows.Count());

            Counter.ClearArrows();
            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("0/0", Manager.Counter.TotalScoreString);
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());
        }

        [Test]
        public void Counter_TotalScoreUpdateTest()
        {
            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("0/0", Manager.Counter.TotalScoreString);
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow1 = new Arrow() { Index = 10, };
            Counter.AddArrowIfPossible(arrow1);

            Assert.AreEqual("10/10", Manager.Counter.FlightScoreString);
            Assert.AreEqual("10/10", Manager.Counter.TotalScoreString);
            Assert.AreEqual(1, Manager.CurrentShoot.CurrentArrows.Count());

            Counter.NewFlight();

            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("10/10", Manager.Counter.TotalScoreString);
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow2 = new Arrow() { Index = 9, NumberInFlight = 1 };
            Counter.AddArrowIfPossible(arrow2);

            Assert.AreEqual("9/10", Manager.Counter.FlightScoreString);
            Assert.AreEqual("19/20", Manager.Counter.TotalScoreString);
            Assert.AreEqual(1, Manager.CurrentShoot.CurrentArrows.Count());

            var arrow3 = new Arrow() { Index = 7, NumberInFlight = 2 };
            Counter.AddArrowIfPossible(arrow3);
            Counter.NewFlight();

            Assert.AreEqual("0/0", Manager.Counter.FlightScoreString);
            Assert.AreEqual("26/30", Manager.Counter.TotalScoreString);
            Assert.AreEqual(0, Manager.CurrentShoot.CurrentArrows.Count());
        }

        #endregion total calcul
    }
}
