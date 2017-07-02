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
        private Mock<IMovableTarget> target;
        private ArrowFactory factory;

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

        [Test]
        public void EnglishArrowFactory_CreateTest()
        {
            var arrow = factory.Create(new Point(5, 2), 0, 0);
            Assert.AreEqual(4.8, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(1.9, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Pink, arrow.Color);
            Assert.AreEqual("test", arrow.Score);
            Assert.AreEqual(42, arrow.Value);
            Assert.AreEqual(0, arrow.NumberInFlight);

            arrow = factory.Create(new Point(20, 15), 0, 0);
            Assert.AreEqual(19.3, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(14.4, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Pink, arrow.Color);
            Assert.AreEqual("test", arrow.Score);
            Assert.AreEqual(42, arrow.Value);
            Assert.AreEqual(0, arrow.NumberInFlight);

            arrow = factory.Create(new Point(40, 20), 0, 0);//9 38.5/19.2
            Assert.AreEqual(38.5, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(19.3, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Pink, arrow.Color);
            Assert.AreEqual("test", arrow.Score);
            Assert.AreEqual(42, arrow.Value);
            Assert.AreEqual(0, arrow.NumberInFlight);
        }
    }
}
