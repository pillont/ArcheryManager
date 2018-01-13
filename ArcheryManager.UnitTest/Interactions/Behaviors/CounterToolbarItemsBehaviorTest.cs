using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class CounterToolbarItemsBehaviorTest
    {
        private ContentPageWithGeneralEvent _page;
        private CounterToolbarItemsBehavior behavior;
        private CounterManager Manager;
        private List<ToolbarItem> toolBarList;

        public void ApplyEvent(List<ToolbarItem> toolBarList)
        {
            MessagingCenterHelper.Instance.AddedToolbarItem += (s, e) => toolBarList.Add(e.ToolbarItem);
            MessagingCenterHelper.Instance.RemovedToolbarItem += (s, e) => toolBarList.Remove(e.ToolbarItem);
            MessagingCenterHelper.Instance.ClearedToolbarItem += (s, e) => toolBarList.Clear();

            _page.OnPagePushed(this, null);
        }

        [Test]
        public void AskAndApplyTest()
        {
            Manager.Counter.AddArrowIfPossible(new Arrow());
            var newFlight = toolBarList[0];
        }

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            Manager = new CounterManager() { CurrentShoot = new CountedShoot() };
            Manager.Counter.NewFlight();

            _page = new ContentPageWithGeneralEvent();

            behavior = new CounterToolbarItemsBehavior(Manager, new CounterToolbarGenerator(Manager.Counter));
            _page.Behaviors.Add(behavior);

            toolBarList = new List<ToolbarItem>();
            ApplyEvent(toolBarList);
        }

        [Test]
        public void ToolBarItems_AddTest()
        {
            Manager.CurrentShoot.HaveMaxArrowsCount = false;
            Assert.AreEqual(4, toolBarList.Count);

            Manager.Counter.AddArrowIfPossible(new Arrow());
            Assert.AreEqual(5, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_HaveMaxTest()
        {
            Manager.CurrentShoot.HaveMaxArrowsCount = true;
            Manager.CurrentShoot.ArrowsCount = 2;
            Assert.AreEqual(4, toolBarList.Count);

            Manager.Counter.AddArrowIfPossible(new Arrow());
            Assert.AreEqual(4, toolBarList.Count);

            Manager.Counter.AddArrowIfPossible(new Arrow());
            Assert.AreEqual(5, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveTest()
        {
            Manager.CurrentShoot.HaveMaxArrowsCount = true;
            Assert.AreEqual(4, toolBarList.Count);
            Manager.CurrentShoot.ArrowsCount = 2;

            Manager.Counter.AddArrowIfPossible(new Arrow());
            Manager.Counter.AddArrowIfPossible(new Arrow());

            Manager.Counter.RemoveLastArrow();
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveWithoutMaxTest()
        {
            Manager.CurrentShoot.HaveMaxArrowsCount = false;

            Assert.AreEqual(4, toolBarList.Count);

            Manager.Counter.AddArrowIfPossible(new Arrow());
            Manager.Counter.AddArrowIfPossible(new Arrow());

            Manager.Counter.RemoveLastArrow();
            Assert.AreEqual(5, toolBarList.Count);

            Manager.Counter.RemoveLastArrow();
            Assert.AreEqual(4, toolBarList.Count);
        }
    }
}
