using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using NUnit.Framework;
using System;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Helpers
{
    [TestFixture]
    public class MessagingCenterHelperTest
    {
        public MessagingCenterHelper MessagingCenterHelper;
        private bool Alert;
        private AlertArg Arg;
        private bool Back;
        private Page Page;
        private bool PageFlag;
        private bool Remove;

        public MessagingCenterHelperTest()
        {
            MessagingCenterHelper = MessagingCenterHelper.Instance;
        }

        [Test]
        public void BackPageTest()
        {
            MessagingCenterHelper.BackPageEvent += MessagingCenterHelper_BackPageEvent;
            MessagingCenterHelper.BackInNavigationPage(this);

            Assert.IsTrue(Back);
        }

        [SetUp]
        public void Init()
        {
            Alert = false;
            Back = false;
            PageFlag = false;
        }

        [Test]
        public void PoppedInNavigationPageTest()
        {
            MessagingCenterHelper.PoppingPageEvent += MessagingCenterHelper_PageEvent;

            Page = new Page();
            MessagingCenterHelper.PoppedInNavigationPage(this, Page);

            Assert.IsTrue(PageFlag);
        }

        [Test]
        public void PushInNavigationPageTest()
        {
            MessagingCenterHelper.PushedPageEvent += MessagingCenterHelper_PageEvent;

            Page = new Page();
            MessagingCenterHelper.PushInNavigationPage(this, Page);

            Assert.IsTrue(PageFlag);
        }

        [Test]
        public void removePageTest()
        {
            Page = new Page();
            MessagingCenterHelper.RemovedPageInNavigationEvent += MessagingCenterHelper_RemovePageEvent;
            MessagingCenterHelper.RemovePageInNavigation(this, Page);

            Assert.IsTrue(Remove);
        }

        [Test]
        public void SendToastTest()
        {
            MessagingCenterHelper.SendToastEvent += MessagingCenterHelper_SendToastEvent; ;

            Arg = new AlertArg();
            MessagingCenterHelper.SendToast(this, Arg);

            Assert.IsTrue(Alert);
        }

        private void MessagingCenterHelper_BackPageEvent(object sender, EventArgs e)
        {
            if (sender == this && e == null)
            {
                Back = true;
            }
        }

        private void MessagingCenterHelper_PageEvent(object sender, Page e)
        {
            if (sender == this && e == Page)
                PageFlag = true;
        }

        private void MessagingCenterHelper_RemovePageEvent(object sender, Page e)
        {
            if (sender == this && e == Page)
                Remove = true;
        }

        private void MessagingCenterHelper_SendToastEvent(object sender, AlertArg e)
        {
            if (sender == this && e == Arg)
                Alert = true;
        }
    }
}
