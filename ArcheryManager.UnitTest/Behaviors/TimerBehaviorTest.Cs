using ArcheryManager.Behaviors;
using ArcheryManager.CustomControls;
using NUnit.Framework;
using System.Threading;

namespace ArcheryManager.UnitTest.Behaviors
{
    [TestFixture]
    public class TimerBehaviorTest
    {
        private TimerBehavior<CustomTimer> behavior;
        private CustomTimer timer;

        [SetUp]
        public void Init()
        {
            //       Xamarin.Forms.Mocks.MockForms.Init();
            behavior = new TimerBehavior<CustomTimer>();
            //     timer = new CustomTimer();
            //   timer.Behaviors.Add(behavior);
        }

        //TODO [TestCase]
        public void TimerTest()
        {
            behavior.Start();
            Thread.Sleep(50000);
        }
    }
}
