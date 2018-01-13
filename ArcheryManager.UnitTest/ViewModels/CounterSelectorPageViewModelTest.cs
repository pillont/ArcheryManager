using ArcheryManager.Controllers;
using ArcheryManager.Entities;
using ArcheryManager.Pages;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.ViewModels
{
    [TestFixture]
    public class CounterSelectorPageViewModelTest
    {
        public Mock<ISQLiteConnectionManager> ConnectionMock;
        public CounterManager Manager;
        public CountedShoot Shoot;
        public CounterSelectorPageViewModel ViewModel;

        [SetUp]
        public void Init()
        {
            ConnectionMock = new Mock<ISQLiteConnectionManager>();
            ConnectionMock.Setup(e => e.InsertOrReplaceWithChildrenRecursivelyAsync(It.IsAny<BaseEntity>()));

            Shoot = new CountedShoot();
            Manager = new CounterManager(ConnectionMock.Object) { CurrentShoot = Shoot };
            Manager.Counter.NewFlight();
            ViewModel = new CounterSelectorPageViewModel(Manager, new TargetStarterController(Manager));

            RegisterHelperTest.InitTestRegister(Manager);
        }

        [Test]
        public void SaveInDbAfterValidationTest()
        {
            var current = Manager.CurrentShoot;

            ViewModel.Valid();
            ConnectionMock.Verify(m => m.InsertOrReplaceWithChildrenRecursivelyAsync(current));
        }

        [Test]
        public void ValuesChangeTest()
        {
            ViewModel.HaveTarget = true;
            ViewModel.LimitArrowNumberSelectorViewModel.ArrowsCount = 42;
            ViewModel.LimitArrowNumberSelectorViewModel.HaveMaxArrowsCount = true;

            var shoot = Manager.CurrentShoot;

            Assert.IsTrue(shoot.HaveTarget);
            Assert.IsTrue(shoot.HaveMaxArrowsCount);
            Assert.AreEqual(42, shoot.ArrowsCount);
        }

        //TODO use mvvm to manage target style and make test on change
    }
}
