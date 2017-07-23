using ArcheryManager.Interactions.Behaviors;
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
        private Mock<PageWithOverridableToolBar> _page;
        private CounterToolbarItemsBehavior behavior;
        private List<ToolbarItem> toolBarList;
        private CountSetting countSetting;
        private ScoreCounter counter;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            countSetting = new CountSetting();
            toolBarList = new List<ToolbarItem>();
            var arrowSetting = EnglishArrowSetting.Instance;
            var scoreResult = new ScoreResult();
            var generalCounterSetting = new GeneralCounterSetting() { CountSetting = countSetting, ArrowSetting = arrowSetting, ScoreResult = scoreResult };
            counter = new ScoreCounter(generalCounterSetting);
            _page = new Mock<PageWithOverridableToolBar>();
            _page.CallBase = true;
            _page.SetupGet(e => e.ToolbarItems).Returns(toolBarList);
            behavior = new CounterToolbarItemsBehavior(generalCounterSetting, counter);
            _page.Object.Behaviors.Add(behavior);
        }

        [Test]
        public void ToolBarItems_HaveMaxTest()
        {
            countSetting.HaveMaxArrowsCount = true;
            behavior.AddDefaultToolbarItems();
            countSetting.ArrowsCount = 2;
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_AddTest()
        {
            countSetting.HaveMaxArrowsCount = false;
            behavior.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);

            countSetting.ArrowsCount = 2;
            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveTest()
        {
            countSetting.HaveMaxArrowsCount = true;
            behavior.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);
            countSetting.ArrowsCount = 2;

            counter.AddArrow(new Arrow(0, 0));
            counter.AddArrow(new Arrow(0, 0));

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

            counter.AddArrow(new Arrow(0, 0));
            counter.AddArrow(new Arrow(0, 0));

            counter.RemoveLastArrow();
            Assert.AreEqual(4, toolBarList.Count);
            counter.RemoveLastArrow();
            Assert.AreEqual(3, toolBarList.Count);
        }
    }
}
