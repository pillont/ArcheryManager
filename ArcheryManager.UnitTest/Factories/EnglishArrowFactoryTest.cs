using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Factories
{
    [TestFixture]
    public class EnglishArrowFactoryTest
    {
        private Mock<IMovableTarget> target;
        private EnglishArrowFactory factory;

        [SetUp]
        public void Init()
        {
            target = new Mock<IMovableTarget>();
            target.SetupGet(c => c.TargetSize).Returns(350);
            factory = new EnglishArrowFactory(target.Object);
        }

        [Test]
        public void EnglishArrowFactory_CreateXtenTest()
        {
            var arrow = factory.Create(new Point(5, 2));
            Assert.AreEqual(4.8, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(1.9, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Yellow, arrow.Color);
            Assert.AreEqual("X10", arrow.Score);
            Assert.AreEqual(10, arrow.Value);
        }

        [Test]
        public void EnglishArrowFactory_CreateTenTest()
        {
            var arrow = factory.Create(new Point(20, 15));
            Assert.AreEqual(19.3, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(14.4, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Yellow, arrow.Color);
            Assert.AreEqual("10", arrow.Score);
            Assert.AreEqual(10, arrow.Value);
        }

        [Test]
        public void EnglishArrowFactory_CreateNineTest()
        {
            var arrow = factory.Create(new Point(40, 20));//9 38.5/19.2
            Assert.AreEqual(38.5, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(19.3, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Yellow, arrow.Color);
            Assert.AreEqual("9", arrow.Score);
            Assert.AreEqual(9, arrow.Value);
        }

        [Test]
        public void EnglishArrowFactory_CreateHeightTest()
        {
            var arrow = factory.Create(new Point(40, 40));
            Assert.AreEqual(38.5, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(38.5, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Red, arrow.Color);
            Assert.AreEqual("8", arrow.Score);
            Assert.AreEqual(8, arrow.Value);
        }

        [Test]
        public void EnglishArrowFactory_CreateSevenTest()
        {
            var arrow = factory.Create(new Point(50, 50));
            Assert.AreEqual(48.1, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(48.1, Math.Round(arrow.TranslationY, 1));
            Assert.AreEqual(Color.Red, arrow.Color);
            Assert.AreEqual("7", arrow.Score);
            Assert.AreEqual(7, arrow.Value);
        }

        [Test]
        public void EnglishArrowFactory_CreateSixTest()
        {
            var arrow = factory.Create(new Point(60, -70));
            Assert.AreEqual(Color.CornflowerBlue, arrow.Color);
            Assert.AreEqual("6", arrow.Score);
            Assert.AreEqual(6, arrow.Value);
            Assert.AreEqual(57.8, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(-67.4, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateFiveTest()
        {
            var arrow = factory.Create(new Point(100, 0));
            Assert.AreEqual(Color.CornflowerBlue, arrow.Color);
            Assert.AreEqual("5", arrow.Score);
            Assert.AreEqual(5, arrow.Value);
            Assert.AreEqual(96.3, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(0, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateFourTest()
        {
            var arrow = factory.Create(new Point(0, -120));
            Assert.AreEqual(Color.Gray, arrow.Color);
            Assert.AreEqual("4", arrow.Score);
            Assert.AreEqual(4, arrow.Value);
            Assert.AreEqual(0, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(-115.6, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateThreeTest()
        {
            var arrow = factory.Create(new Point(80, -100));
            Assert.AreEqual("3", arrow.Score);
            Assert.AreEqual(3, arrow.Value);
            Assert.AreEqual(Color.Gray, arrow.Color);
            Assert.AreEqual(77.0, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(-96.3, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateTwoTest()
        {
            var arrow = factory.Create(new Point(100, -100));
            Assert.AreEqual(Color.White, arrow.Color);
            Assert.AreEqual("2", arrow.Score);
            Assert.AreEqual(2, arrow.Value);
            Assert.AreEqual(96.3, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(-96.3, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateOneTest()
        {
            var arrow = factory.Create(new Point(120, -120));
            Assert.AreEqual(Color.White, arrow.Color);
            Assert.AreEqual("1", arrow.Score);
            Assert.AreEqual(1, arrow.Value);
            Assert.AreEqual(115.6, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(-115.6, Math.Round(arrow.TranslationY, 1));
        }

        [Test]
        public void EnglishArrowFactory_CreateMissTest()
        {
            var arrow = factory.Create(new Point(200, 200));//M 192.5/192.5
            Assert.AreEqual(Color.Green, arrow.Color);
            Assert.AreEqual("M", arrow.Score);
            Assert.AreEqual(0, arrow.Value);
            Assert.AreEqual(192.6, Math.Round(arrow.TranslationX, 1));
            Assert.AreEqual(192.6, Math.Round(arrow.TranslationY, 1));
        }
    }
}
