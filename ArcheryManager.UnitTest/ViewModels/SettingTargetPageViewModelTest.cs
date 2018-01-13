using ArcheryManager.Entities;
using ArcheryManager.Pages;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.ViewModels
{
    [TestFixture]
    public class SettingTargetPageViewModelTest
    {
        public Mock<ISQLiteConnectionManager> ConnectionMock;
        public CounterManager Manager;
        public CountedShoot Shoot;
        public SettingTargetPageViewModel ViewModel;

        [Test]
        public void ChangeValuesTest()
        {
            Shoot.ArrowsCount = 3;
            Shoot.AverageIsVisible = true;
            Shoot.HaveMaxArrowsCount = true;
            Shoot.IsDecreasingOrder = true;
            Shoot.ShowAllArrows = true;

            ViewModel = new SettingTargetPageViewModel(Manager);

            Assert.AreEqual(3, ViewModel.ArrowsCount);
            Assert.IsTrue(ViewModel.AverageIsVisible);
            Assert.IsTrue(ViewModel.HaveMaxArrowsCount);
            Assert.IsTrue(ViewModel.IsDecreasingOrder);
            Assert.IsTrue(ViewModel.ShowAllArrows);
        }

        [Test]
        public void DefaultValuesTest()
        {
            Assert.AreEqual(6, ViewModel.ArrowsCount);
            Assert.IsFalse(ViewModel.AverageIsVisible);
            Assert.IsFalse(ViewModel.HaveMaxArrowsCount);
            Assert.IsFalse(ViewModel.IsDecreasingOrder);
            Assert.IsFalse(ViewModel.ShowAllArrows);
        }

        [SetUp]
        public void Init()
        {
            ConnectionMock = new Mock<ISQLiteConnectionManager>();
            ConnectionMock.Setup(e => e.UpdateWithChildrenAsync(It.IsAny<BaseEntity>()));

            Shoot = new CountedShoot();
            Manager = new CounterManager(ConnectionMock.Object) { CurrentShoot = Shoot };
            Manager.Counter.NewFlight();
            ViewModel = new SettingTargetPageViewModel(Manager);
        }

        [Test]
        public void SaveInDBAfterValidationTest()
        {
            ViewModel.Finish();
            ConnectionMock.Verify(m => m.UpdateWithChildrenAsync(Shoot));
        }

        [Test]
        public void UpdateValuesInCommonInstanceTest()
        {
            ViewModel.ArrowsCount = 3;
            ViewModel.AverageIsVisible = true;
            ViewModel.HaveMaxArrowsCount = true;
            ViewModel.IsDecreasingOrder = true;
            ViewModel.ShowAllArrows = true;

            ViewModel.Finish();

            Assert.AreEqual(3, Shoot.ArrowsCount);
            Assert.IsTrue(Shoot.AverageIsVisible);
            Assert.IsTrue(Shoot.HaveMaxArrowsCount);
            Assert.IsTrue(Shoot.IsDecreasingOrder);
            Assert.IsTrue(Shoot.ShowAllArrows);
        }
    }
}
