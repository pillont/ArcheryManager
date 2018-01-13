using ArcheryManager.Controllers;
using ArcheryManager.Helpers;
using ArcheryManager.Pages;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using ArcheryManager.ViewModules;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Controllers
{
    [TestFixture]
    public class PageOpenerControllerTest
    {
        public PageOpenerController Controller;
        private CounterManager Manager;
        private Page Page;

        [Test]
        public void ConnectedShootTest()
        {
            Page = null;

            MessagingCenterHelper.Instance.PushingPageEvent += Instance_PushingPageEvent;
            Controller.ConnectedShoot();
            MessagingCenterHelper.Instance.PushingPageEvent -= Instance_PushingPageEvent;

            Assert.NotNull(Page);
            var connected = Page as ConnectedShootPage;
            Assert.NotNull(connected);
            Assert.IsTrue(connected.BindingContext is ConnectedShootPageViewModel);
        }

        [SetUp]
        public void Init()
        {
            Manager = new CounterManager(new Mock<ISQLiteConnectionManager>().Object);
            RegisterHelperTest.InitTestRegister(Manager);
            Controller = new PageOpenerController(Manager);
        }

        private void Instance_PushingPageEvent(object sender, PushingEventArg e)
        {
            Page = e.Page;
        }
    }
}
