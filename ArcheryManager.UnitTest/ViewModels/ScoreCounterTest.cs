using ArcheryManager.Entities;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.ViewModels
{
    [TestFixture]
    public class ScoreCounterTest
    {
        public Mock<ISQLiteConnectionManager> ConnectionMock;
        public ScoreCounter Counter;
        public CounterManager Manager;
        public CountedShoot Shoot;

        [Test]
        public void AddArrowInDBTest()
        {
            var a1 = new Arrow();
            var a2 = new Arrow();

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);

            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(a1));
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(a2));
        }

        [SetUp]
        public void Init()
        {
            ConnectionMock = new Mock<ISQLiteConnectionManager>();

            Shoot = new CountedShoot();
            Manager = new CounterManager(ConnectionMock.Object) { CurrentShoot = Shoot };
            Manager.Counter.NewFlight();
            Counter = Manager.Counter;
        }

        [Test]
        public void NewFlightInDBTest()
        {
            var last = Shoot.CurrentFlight;

            Counter.NewFlight();

            var flight = Shoot.CurrentFlight;
            ConnectionMock.Verify(m => m.UpdateWithChildrenAsync(last));
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(flight));
        }

        [Test]
        public void RemoveLastArrowInDBTest()
        {
            var a1 = new Arrow();
            var a2 = new Arrow();
            var a3 = new Arrow();

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);

            Counter.RemoveLastArrow();
            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a3));

            Counter.RemoveLastArrow();
            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a2));
            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a1)));
        }

        [Test]
        public void RemoveSelectionInDBTest()
        {
            var a1 = new Arrow();
            var a2 = new Arrow();
            var a3 = new Arrow();
            var a4 = new Arrow();

            Counter.AddArrowIfPossible(a1);
            Counter.AddArrowIfPossible(a2);
            Counter.AddArrowIfPossible(a3);
            Counter.AddArrowIfPossible(a4);

            a1.IsSelected = true;
            a3.IsSelected = true;

            Counter.RemoveSelection();

            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a1));
            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a3));
            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a2)));
            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a4)));

            a2.IsSelected = true;

            Counter.RemoveSelection();

            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a2));
            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(a4)));
        }
    }
}
