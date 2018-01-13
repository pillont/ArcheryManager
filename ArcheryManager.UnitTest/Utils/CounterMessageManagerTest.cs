using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using NUnit.Framework;
using System;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class MessageManagerTest
    {
        public bool MaxArrowMessage;
        private MessageManager Manager;
        private bool SelectionMessage;
        private CountedShoot Shoot;

        [Test]
        public void AddArrowDuringSelection_ErrorShowTest()
        {
            Shoot.CurrentArrows.Add(new Arrow() { IsSelected = true });

            Manager.AddArrowOrShowError(null);

            Assert.IsTrue(SelectionMessage);
        }

        [Test]
        public void AddDuringMaxArrow_ErrorShowTest()
        {
            Shoot.ArrowsCount = 3;
            Shoot.HaveMaxArrowsCount = true;
            Shoot.CurrentArrows.Add(new Arrow());
            Shoot.CurrentArrows.Add(new Arrow());
            Shoot.CurrentArrows.Add(new Arrow());

            Manager.AddArrowOrShowError(null);

            Assert.IsTrue(MaxArrowMessage);
        }

        [Test]
        public void AskForDone_messageTest()
        {
            bool done = false;
            Action action = () => done = true;
            string message = "message";
            AlertArg arg = null;

            MessagingCenterHelper.Instance.SendToastEvent += (s, e) =>
             {
                 if (s == Manager)
                 {
                     arg = e;
                 }
             };
            Manager.AskForDone(message, action);

            //no reponse
            Assert.IsFalse(done);

            // anwser = false
            arg.ResultChanged(false);
            Assert.IsFalse(done);

            Manager.AskForDone(message, action);
            // answer = true
            arg.ResultChanged(true);
            Assert.IsTrue(done);
        }

        [SetUp]
        public void Init()
        {
            MaxArrowMessage = false;
            SelectionMessage = false;
            Shoot = new CountedShoot();
            Xamarin.Forms.Mocks.MockForms.Init();
            Manager = new MessageManager(Shoot);
            Shoot.Flights.Add(new Flight());

            MessagingCenterHelper.Instance.SendToastEvent += Instance_SendToastEvent;
        }

        [Test]
        public void MaxArrowMessageTest()
        {
            Shoot.ArrowsCount = 3;
            Shoot.HaveMaxArrowsCount = true;
            Shoot.CurrentArrows.Add(new Arrow());
            Shoot.CurrentArrows.Add(new Arrow());
            Shoot.CurrentArrows.Add(new Arrow());

            Manager.AddArrowOrShowError(null);

            Assert.IsTrue(MaxArrowMessage);
        }

        private void Instance_SendToastEvent(object sender, AlertArg e)
        {
            if (sender == Manager
            && e.Title == TranslateExtension.GetTextResource("Error")
            && e.Cancel == TranslateExtension.GetTextResource("OK"))
            {
                if (e.Message == TranslateExtension.GetTextResource("CantAddMoreThanMaxArrow"))
                    MaxArrowMessage = true;

                if (e.Message == TranslateExtension.GetTextResource("NoAddingDuringSelection"))
                    SelectionMessage = true;
            }
        }
    }
}
