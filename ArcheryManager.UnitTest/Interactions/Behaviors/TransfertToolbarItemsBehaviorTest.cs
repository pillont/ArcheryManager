using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class TransfertToolbarItemsBehaviorTest
    {
        private TabbedPageWithGeneralEvent Associated;
        private TransfertToolbarItemsBehavior Behavior;
        private Page ToTransfert;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            MessagingCenterHelper.Instance.AddedToolbarItem += (s, t) => Associated.ToolbarItems.Add(t.ToolbarItem);

            Behavior = new TransfertToolbarItemsBehavior();

            Associated = new TabbedPageWithGeneralEvent();
            ToTransfert = new Page();
            Associated.Behaviors.Add(Behavior);
            Associated.OnPagePushed(this, null);
        }

        [Test]
        public void TranfertAddItemTest()
        {
            var t = new ToolbarItemsArg() { ToolbarItem = new ToolbarItem() };
            MessagingCenterHelper.AddToolbarItem(this, t);

            Assert.IsTrue(ToTransfert.ToolbarItems.Contains(t.ToolbarItem));
            Assert.IsFalse(Associated.ToolbarItems.Contains(t.ToolbarItem));
        }

        [Test]
        public void TranfertClearItemTest()
        {
            var t1 = new ToolbarItem();
            var t2 = new ToolbarItem();
            var t3 = new ToolbarItem();
            ToTransfert.ToolbarItems.Add(t1);
            ToTransfert.ToolbarItems.Add(t2);
            ToTransfert.ToolbarItems.Add(t3);
            MessagingCenterHelper.ClearToolbarItem(this, new ClearArg<ToolbarItem>());

            Assert.AreEqual(0, ToTransfert.ToolbarItems.Count);
        }

        [Test]
        public void TranfertRemoveItemTest()
        {
            var t = new ToolbarItemsArg() { ToolbarItem = new ToolbarItem() };
            ToTransfert.ToolbarItems.Add(t.ToolbarItem);
            MessagingCenterHelper.RemoveToolbarItem(this, t);

            Assert.IsFalse(ToTransfert.ToolbarItems.Contains(t.ToolbarItem));
        }
    }
}
