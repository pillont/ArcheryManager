using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.UnitTest.Mockables;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class CounterToolbarItemsBehaviorTest
    {
        private Mock<ContentPageWithOverridableToolBar> _page;
        private CounterToolbarItemsBehavior<ContentPageWithOverridableToolBar> behavior;
        private List<ToolbarItem> toolBarList;
        private CountSetting countSetting;
        private ScoreCounter counter;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            toolBarList = new List<ToolbarItem>();
            var generalCounterSetting = new GeneralCounterSetting();
            countSetting = generalCounterSetting.CountSetting;
            counter = new ScoreCounter(generalCounterSetting);
            _page = new Mock<ContentPageWithOverridableToolBar>();
            _page.CallBase = true;
            _page.SetupGet(e => e.ToolbarItems).Returns(toolBarList);
            behavior = new CounterToolbarItemsBehavior<ContentPageWithOverridableToolBar>(generalCounterSetting, counter);
            _page.Object.Behaviors.Add(behavior);
        }

        [Test]
        public void ToolBarItems_HaveMaxTest()
        {
            countSetting.HaveMaxArrowsCount = true;
            behavior.AddDefaultToolbarItems();
            countSetting.ArrowsCount = 2;
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrowIfPossible(new Arrow(0, 0));
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrowIfPossible(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_AddTest()
        {
            countSetting.HaveMaxArrowsCount = false;
            behavior.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);

            countSetting.ArrowsCount = 2;
            counter.AddArrowIfPossible(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveTest()
        {
            countSetting.HaveMaxArrowsCount = true;
            behavior.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);
            countSetting.ArrowsCount = 2;

            counter.AddArrowIfPossible(new Arrow(0, 0));
            counter.AddArrowIfPossible(new Arrow(0, 0));

            counter.RemoveLastArrow();
            Assert.AreEqual(3, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveWithoutMaxTest()
        {
            countSetting.HaveMaxArrowsCount = false;
            behavior.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);
            countSetting.ArrowsCount = 2;

            counter.AddArrowIfPossible(new Arrow(0, 0));
            counter.AddArrowIfPossible(new Arrow(0, 0));

            counter.RemoveLastArrow();
            Assert.AreEqual(4, toolBarList.Count);
            counter.RemoveLastArrow();
            Assert.AreEqual(3, toolBarList.Count);
        }
    }
}
