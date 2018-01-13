using ArcheryManager.Entities;
using ArcheryManager.Pages;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.ViewModels
{
    [TestFixture]
    public class RemarksPageViewModelTest
    {
        public Mock<ISQLiteConnectionManager> ConnectionMock;
        public CounterManager Manager;
        public CountedShoot Shoot;
        private RemarksPageViewModel ViewModel;

        [Test]
        public void FlightRemarkTest()
        {
            var r1 = new Remark();
            ViewModel.FlightRemarksPrevious.Add(r1);
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(r1));
            Assert.IsTrue(Shoot.CurrentFlight.Remarks.Contains(r1));

            var r2 = new Remark();
            ViewModel.FlightRemarksPrevious.Add(r2);
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(r2));
            Assert.IsTrue(Shoot.CurrentFlight.Remarks.Contains(r2));

            ViewModel.FlightRemarksPrevious.Remove(r2);
            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(r2));
            Assert.IsFalse(Shoot.CurrentFlight.Remarks.Contains(r2));

            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(r1)));
            Assert.IsTrue(Shoot.CurrentFlight.Remarks.Contains(r1));
        }

        [Test]
        public void GeneralRemarkTest()
        {
            var r1 = new Remark();
            ViewModel.GeneralRemarksPrevious.Add(r1);
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(r1));
            Assert.IsTrue(Shoot.GeneralRemarks.Contains(r1));

            var r2 = new Remark();
            ViewModel.GeneralRemarksPrevious.Add(r2);
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(r2));
            Assert.IsTrue(Shoot.GeneralRemarks.Contains(r2));

            ViewModel.GeneralRemarksPrevious.Remove(r2);
            ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(r2));
            Assert.IsFalse(Shoot.GeneralRemarks.Contains(r2));

            Assert.Throws<MockException>(() => ConnectionMock.Verify(m => m.DeleteRecursivelyAsync(r1)));
            Assert.IsTrue(Shoot.GeneralRemarks.Contains(r1));
        }

        [SetUp]
        public void Init()
        {
            ConnectionMock = new Mock<ISQLiteConnectionManager>();
            ConnectionMock.Setup(e => e.InsertOrReplaceWithChildrenRecursivelyAsync(It.IsAny<BaseEntity>()));
            ConnectionMock.Setup(e => e.DeleteRecursivelyAsync(It.IsAny<BaseEntity>()));

            Shoot = new CountedShoot();
            Manager = new CounterManager(ConnectionMock.Object) { CurrentShoot = Shoot };
            Manager.Counter.NewFlight();
            ViewModel = new RemarksPageViewModel(Manager);
        }
    }
}
