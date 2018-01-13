using ArcheryManager.Interactions.Behaviors;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class WaveBehaviorTest
    {
        private readonly Mock<Label> LabelMock;
        private WaveBehavior behavior;

        public WaveBehaviorTest()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            LabelMock = new Mock<Label>();
            behavior = new WaveBehavior();
            LabelMock.SetupAllProperties();

            LabelMock.Object.Behaviors.Add(behavior);
        }

        [Test]
        public void DefaultWaveTest()
        {
            Assert.AreEqual(null, LabelMock.Object.Text);
        }

        [Test, Sequential]
        public void DuelWaveTest([Values(1, 2, 3, 4)]int wave,
            [Values(WaveBehavior.AB, WaveBehavior.CD, WaveBehavior.AB, WaveBehavior.CD)] string text)
        {
            behavior.DuelMode = true;
            TestWave(wave, text);
        }

        [Test, Sequential]
        public void MultiWaveTest([Values(1, 2, 3, 4)]int wave,
            [Values(WaveBehavior.AB, WaveBehavior.CD, WaveBehavior.CD, WaveBehavior.AB)] string text)
        {
            behavior.DuelMode = false;
            TestWave(wave, text);
        }

        [Test]
        public void StartWaveTest()
        {
            behavior.StartWave();
            Assert.AreEqual(WaveBehavior.AB, LabelMock.Object.Text);
        }

        [Test]
        public void StopWaveTest()
        {
            behavior.StartWave();
            behavior.StopWave();
            Assert.AreEqual(string.Empty, LabelMock.Object.Text);
        }

        private void TestWave(int wave, string text)
        {
            behavior.StartWave();

            for (int i = 1; i < wave; i++)
            {
                behavior.NextWave();
            }
            Assert.AreEqual(text, LabelMock.Object.Text);
        }
    }
}
