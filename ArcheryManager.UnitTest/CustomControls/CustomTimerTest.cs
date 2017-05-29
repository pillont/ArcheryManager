using NUnit.Framework;
using Moq;
using Xamarin.Forms;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace ArcheryManager.UnitTest.CustomControls
{
    [TestFixture]
    public class CustomTimerTest
    {
        /*

        private CustomTimer timer;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            timer = new CustomTimer();
        }

        [TestCase]
        public void InitTest()
        {
            Assert.AreEqual("120", timer.Text);
            Assert.AreEqual(Color.Red, timer.Color);
            Assert.IsTrue(timer.IsStopped);
            Assert.IsFalse(timer.IsPaused);
            Assert.IsFalse(timer.IsWaitingTime);
        }

        [TestCase]
        public void StartTest()
        {
            timer.Start();
            Assert.AreEqual(Color.Red, timer.Color);
            Assert.AreNotEqual("120", timer.Text);
            Assert.IsFalse(timer.IsStopped);
            Assert.IsFalse(timer.IsPaused);
            Assert.IsTrue(timer.IsWaitingTime);

            var t = Task.Run(() =>
            {
                //wait 12 sec
                Thread.Sleep(12000);

                Assert.AreEqual(Color.Green, timer.Color);
                Assert.IsTrue(Convert.ToInt32(timer.Text) < 120);
                Assert.IsTrue(Convert.ToInt32(timer.Text) > 10);
                Assert.IsFalse(timer.IsStopped);
                Assert.IsFalse(timer.IsPaused);
                Assert.IsFalse(timer.IsWaitingTime);
            });
            t.Wait();
        }
    */
    }
}
