using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.ModelViews;
using ArcheryManager.Pages;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using XLabs.Ioc;

namespace ArcheryManager.UnitTest.Pages
{
    [TestFixture]
    public class ShootSavedPageTest
    {
        private const int AsyncWaitingTime = 10;
        private DateTime FirstDate = new DateTime(2016, 05, 22);
        private List<CountedShoot> list;
        private CounterManager manager;
        private DateTime SecondDate = new DateTime(2016, 05, 24);
        private DateTime ThirdDate = new DateTime(2016, 05, 25);
        private ShootSavedPageViewModel viewModel;

        public ShootSavedPageTest()
        {
            RegisterHelperTest.InitTestRegister(manager);
        }

        [Test]
        public void DefaultShownTest()
        {
            Assert.IsTrue(viewModel.ShownFinish);
            Assert.IsTrue(viewModel.ShownNotFinish);
        }

        [Test]
        public void GroupOrderTest()
        {
            Assert.AreEqual(3, viewModel.GroupedItems.Count);
            Assert.AreEqual("25 mai 2016", viewModel.GroupedItems[0].Name);
            Assert.AreEqual("24 mai 2016", viewModel.GroupedItems[1].Name);
            Assert.AreEqual("22 mai 2016", viewModel.GroupedItems[2].Name);
        }

        [Test]
        public void GroupTest()
        {
            Assert.AreEqual(2, viewModel.GroupedItems[0].Count);
            Assert.AreEqual(1, viewModel.GroupedItems[1].Count);
            Assert.AreEqual(1, viewModel.GroupedItems[2].Count);

            Assert.AreEqual("25 mai 2016", viewModel.GroupedItems[0][0].GroupName);
            Assert.AreEqual("25 mai 2016", viewModel.GroupedItems[0][1].GroupName);
            Assert.AreEqual("24 mai 2016", viewModel.GroupedItems[1][0].GroupName);
            Assert.AreEqual("22 mai 2016", viewModel.GroupedItems[2][0].GroupName);
        }

        [SetUp]
        public void Init()
        {
            list = new List<CountedShoot>()
            {
                new CountedShoot(){IsFinished = true , CreationDate = FirstDate },
                new CountedShoot(){IsFinished = true, CreationDate= ThirdDate },
                new CountedShoot(){IsFinished = true, CreationDate= SecondDate  },
                new CountedShoot(){IsFinished = false, CreationDate= ThirdDate },
            };

            var mockQ = new Mock<SQLiteConnectionManager>(new object[] { null });
            mockQ.Setup(e => e.GetAllWithChildrenRecursivelyAsync<CountedShoot>()).Returns(() =>
            {
                return list;
            });

            manager = new CounterManager(mockQ.Object) { CurrentShoot = new CountedShoot() };
            manager.Counter.NewFlight();
            RegisterHelperTest.InitTestRegister(manager);

            viewModel = new ShootSavedPageViewModel(manager);
            Thread.Sleep(AsyncWaitingTime);
        }

        [Test]
        public void OpenShoot_FinishedCountTest()
        {
            Page page = null;
            viewModel.SelectedItem = new ShootInList(new CountedShoot() { IsFinished = true });
            MessagingCenterHelper.Instance.PopToRootPageEvent += (s, e) => page = e;
            viewModel.OpenCommand.Execute(null);

            Assert.IsNotNull(page);
            Assert.IsTrue(page is ResultPage);
        }

        [Test]
        public void OpenShoot_NotFinishedCountTest()
        {
            Page page = null;
            var shoot = new CountedShoot() { IsFinished = false };
            viewModel.SelectedItem = new ShootInList(shoot);
            MessagingCenterHelper.Instance.PopToRootPageEvent += (s, e) => page = e;
            viewModel.OpenCommand.Execute(null);

            Assert.IsNotNull(page);
            Assert.IsTrue(page is CountTabbedPage);
            Assert.IsTrue((page as CountTabbedPage).Counter is TargetPage);
            Assert.AreEqual(shoot, Resolver.Resolve<CounterManager>().CurrentShoot);
        }

        [Test]
        public void SelectedItemTest()
        {
            Assert.AreEqual(viewModel.Items.First().Model, viewModel.SelectedItem.Model);
        }

        [Test]
        public void ShowAllTest()
        {
            viewModel.ShownFinish = true;
            viewModel.ShownNotFinish = true;
            Thread.Sleep(AsyncWaitingTime);

            Assert.AreEqual(4, viewModel.Items.Count());
        }

        [Test]
        public void ShowFinishTest()
        {
            viewModel.ShownFinish = true;
            viewModel.ShownNotFinish = false;
            Thread.Sleep(AsyncWaitingTime);

            Assert.AreEqual(3, viewModel.Items.Count());
            Assert.IsTrue(viewModel.Items.All(i => i.Model.IsFinished));
        }

        [Test]
        public void ShowNotFinishTest()
        {
            viewModel.ShownFinish = false;
            viewModel.ShownNotFinish = true;
            Thread.Sleep(AsyncWaitingTime);

            Assert.AreEqual(1, viewModel.Items.Count());
            Assert.IsTrue(viewModel.Items.All(i => !i.Model.IsFinished));
        }
    }
}
