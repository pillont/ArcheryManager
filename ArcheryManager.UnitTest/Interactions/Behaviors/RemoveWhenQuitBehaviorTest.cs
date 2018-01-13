using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class RemoveWhenQuitBehaviorTest
    {
        private RemoveWhenQuitBehavior Behavior;
        private Page Page;
        private int PopToRootCounter;
        private int PushCounter;

        public RemoveWhenQuitBehaviorTest()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            Behavior = new RemoveWhenQuitBehavior();
            Page = new Page();
            Page.Behaviors.Add(Behavior);

            MessagingCenterHelper.Instance.PushedPageEvent += (s, e) => { PushCounter++; };
            MessagingCenterHelper.Instance.PopToRootPageEvent += (s, e) => { PopToRootCounter++; };
        }

        [Test]
        public void CurrentPageApparingTest()
        {
            PopToRootCounter = 0;
            PushCounter = 0;

            MessagingCenterHelper.PushInNavigationPage(this, Page);
            Assert.AreEqual(1, PushCounter);
            Assert.AreEqual(0, PopToRootCounter);
        }

        [SetUp]
        public void Init()
        {
            PopToRootCounter = 0;
            PushCounter = 0;
        }

        [Test]
        public void NewPageApparingOneTimeTest()
        {
            var page = new Page();

            MessagingCenterHelper.PushInNavigationPage(this, page);
            Assert.AreEqual(1, PushCounter);
            Assert.AreEqual(1, PopToRootCounter);
        }
    }
}
