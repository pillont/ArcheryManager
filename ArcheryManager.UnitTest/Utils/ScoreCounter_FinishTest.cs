using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounter_FinishTest
    {
        public static object ErrorFinishCountLock = new object();
        public bool ErrorFinishCount;
        private static object ChangeViewLock = new object();
        private bool ChangeView;
        private CounterManager Manager;
        private Mock<ISQLiteConnectionManager> SqlManager;
        private ScoreCounter Counter => Manager.Counter;

        public ScoreCounter_FinishTest()
        {
            RegisterHelperTest.InitTestRegister();
        }

        [Test]
        public void ChangeView_FinishShoot()
        {
            Manager.CurrentShoot.IsFinished = false;
            Counter.AddArrowIfPossible(new Arrow());

            Counter.FinishShoot();

            Assert.IsTrue(ChangeView);
        }

        [Test]
        public void CounterWithArrows_FinishShoot()
        {
            Manager.CurrentShoot.IsFinished = false;

            Counter.AddArrowIfPossible(new Arrow());

            Counter.FinishShoot();

            Assert.IsTrue(Manager.CurrentShoot.IsFinished);
        }

        [Test]
        public void CounterWithFlights_FinishShoot()
        {
            Manager.CurrentShoot.IsFinished = false;

            Counter.AddArrowIfPossible(new Arrow());
            Counter.NewFlight();

            Counter.FinishShoot();

            Assert.IsTrue(Manager.CurrentShoot.IsFinished);
        }

        [Test]
        public void CounterWithoutArrows_FinishShoot()
        {
            Manager.CurrentShoot.IsFinished = false;
            Counter.FinishShoot();

            Assert.IsFalse(Manager.CurrentShoot.IsFinished);
            Assert.IsFalse(ChangeView);
            Assert.IsTrue(ErrorFinishCount);
        }

        [Test]
        public void FinishCounter_NotFinishEmptyShoot()
        {
            Manager.CurrentShoot.IsFinished = false;

            Counter.FinishShoot();

            Assert.IsFalse(Manager.CurrentShoot.IsFinished);
        }

        [Test]
        public void FinishShoot_NotSaveEmptyCounterInDB()
        {
            Counter.FinishShoot();

            Assert.Throws<MockException>(() => SqlManager.Verify(e => e.UpdateWithChildrenAsync(Manager.CurrentShoot)));
        }

        [SetUp]
        public void Init()
        {
            ChangeView = false;
            ErrorFinishCount = false;

            SqlManager = new Mock<ISQLiteConnectionManager>();
            SqlManager.Setup(e => e.InsertOrReplaceWithChildrenRecursivelyAsync(It.IsAny<BaseEntity>()));
            SqlManager.Setup(e => e.UpdateWithChildrenAsync(It.IsAny<BaseEntity>()));
            Manager = new CounterManager(SqlManager.Object) { CurrentShoot = new CountedShoot() };
            Manager.Counter.NewFlight();
            RegisterHelperTest.InitTestRegister(Manager);

            MessagingCenterHelper.Instance.SendToastEvent += Instance_SendToastEvent;
            MessagingCenterHelper.Instance.PushingPageEvent += Instance_PushingPageEvent;
        }

        [Test]
        public void ShootwithArrow_SaveCounterInDB()
        {
            Counter.AddArrowIfPossible(new Arrow());
            Counter.FinishShoot();

            SqlManager.Verify(e => e.UpdateWithChildrenAsync(Manager.CurrentShoot));
        }

        [Test]
        public void ShootWithFlights_SaveCounterInDB()
        {
            Counter.AddArrowIfPossible(new Arrow());
            Counter.NewFlight();

            Counter.FinishShoot();

            SqlManager.Verify(e => e.UpdateWithChildrenAsync(Manager.CurrentShoot));
        }

        private void Instance_PushingPageEvent(object sender, PushingEventArg e)
        {
            if (sender == Counter)
            {
                ChangeView = true;
            }
        }

        private void Instance_SendToastEvent(object sender, AlertArg e)
        {
            string message = TranslateExtension.GetTextResource("CantFinishEmptyCount");
            string title = TranslateExtension.GetTextResource("Error");
            string cancel = TranslateExtension.GetTextResource("OK");
            if (sender == Counter
            && e.Message == message
            && e.Title == title
            && e.Cancel == cancel)
            {
                ErrorFinishCount = true;
            }
        }
    }
}
