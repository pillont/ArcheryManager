using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Factories
{
    [TestFixture]
    public class ArrowFactoryTest
    {
        private ArrowFactory factory;
        private Mock<IMovableTarget> target;

        [Test]
        public void EnglishArrowFactory_CreateTest()
        {
            var arrow = factory.Create(new Point(5, 2), 0, 0);
            Assert.AreEqual(5.6, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(2.2, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(0, arrow.NumberInFlight);

            arrow = factory.Create(new Point(20, 15), 0, 0);
            Assert.AreEqual(22.2, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(16.7, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(0, arrow.NumberInFlight);

            arrow = factory.Create(new Point(40, 20), 0, 0);//9 38.5/19.2
            Assert.AreEqual(44.4, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(22.2, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(0, arrow.NumberInFlight);
        }

        [SetUp]
        public void Init()
        {
            var setting = new Mock<IArrowSetting>();
            setting.Setup(c => c.ColorOf(It.IsAny<string>())).Returns(Color.Pink);
            setting.Setup(c => c.ScoreByIndex(It.IsAny<int>())).Returns("test");
            setting.Setup(c => c.ValueByScore(It.IsAny<string>())).Returns(42);

            target = new Mock<IMovableTarget>();
            target.SetupGet(c => c.TargetSize).Returns(350);
            factory = new ArrowFactory(target.Object, setting.Object);
        }
    }
}
