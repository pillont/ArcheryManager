using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Models;
using ArcheryManager.Settings;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class AverageBehaviorTest
    {
        private GeneralCounterSetting _generalCounterSetting;
        private ScoreCounter _counter;
        private AverageBehavior _behavior;
        private Mock<AverageCanvas> _canvas;
        private const double TargetSize = 42;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            _generalCounterSetting = new GeneralCounterSetting();
            var _target = new Mock<Target>(new object[] { _generalCounterSetting });
            _target.SetupProperty(t => t.TargetSize, TargetSize);

            _counter = new ScoreCounter(_generalCounterSetting);
            _behavior = new AverageBehavior(_target.Object, _counter, _generalCounterSetting);
            _canvas = new Mock<AverageCanvas>();
            _canvas.Object.Behaviors.Add(_behavior);
        }

        [Test]
        public void UpdateAverageCenter_EmptyTest()
        {
            var list = new List<Arrow>();

            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(null, _behavior.AverageCenter);
        }

        [Test]
        public void UpdateAverageCenterTest()
        {
            var list = new List<Arrow>();
            list.Add(new Arrow(0, 0, new Point(50, 100), TargetSize));

            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(50, 100), _behavior.AverageCenter); // same point

            list.Add(new Arrow(0, 0, new Point(100, 200), TargetSize));
            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(75, 150), _behavior.AverageCenter);

            list.Add(new Arrow(0, 0, new Point(30, 0), TargetSize));
            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(60, 100), _behavior.AverageCenter);
        }

        [Test]
        public void UpdateAverageAsync_EmptyTest()
        {
            _canvas.Setup(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()),
                    Times.Never());
        }

        [Test]
        public void UpdateAverageTest()
        {
            _generalCounterSetting.CountSetting.AverageIsVisible = true;
            _canvas.Setup(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()));

            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(50, 100), TargetSize));
            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(100, 200), TargetSize));

            var X = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationX));
            var Y = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationY));
            _canvas.Setup(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)),
                    Times.AtLeast(1));

            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(300, 600), TargetSize));
            X = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationX));
            Y = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationY));
            _canvas.Setup(mock => mock.CreateAverageVisual(X, Y, new Point(150, 300)));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(X, Y, new Point(150, 300)),
                    Times.AtLeast(1));
        }

        [Test]
        public void UpdateAverage_NoSeeAverageTest()
        {
            _generalCounterSetting.CountSetting.AverageIsVisible = false;
            _canvas.Setup(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()));

            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(50, 100), TargetSize));
            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(100, 200), TargetSize));
            _counter.AddArrowIfPossible(new Arrow(0, 0, new Point(300, 600), TargetSize));

            _canvas.Verify(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()),
            Times.Never());
        }
    }
}
