using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
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
        private const double TargetSize = 42;
        private AverageBehavior _behavior;
        private Mock<AverageCanvas> _canvas;
        private ScoreCounter Counter;
        private CounterManager Manager;
        private CountedShoot Shoot;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            Shoot = new CountedShoot();
            Manager = new CounterManager() { CurrentShoot = Shoot };
            Counter = Manager.Counter;
            Counter.NewFlight();

            var _target = new Mock<Target>();
            _target.SetupProperty(t => t.TargetSize, TargetSize);

            var navigationPage = new NavigationPage();
            _behavior = new AverageBehavior(Manager, _target.Object);
            _canvas = new Mock<AverageCanvas>();
            _canvas.Object.Behaviors.Add(_behavior);
        }

        [Test]
        public void UpdateAverage_NoSeeAverageTest()
        {
            Shoot.AverageIsVisible = false;
            _canvas.Setup(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()));

            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 50, TranslationY = 100, TargetSize = TargetSize });
            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 100, TranslationY = 200, TargetSize = TargetSize });
            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 300, TranslationY = 600, TargetSize = TargetSize });

            _canvas.Verify(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()),
            Times.Never());
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
            list.Add(new Arrow() { TranslationX = 50, TranslationY = 100, TargetSize = TargetSize });

            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(50, 100), _behavior.AverageCenter); // same point

            list.Add(new Arrow() { TranslationX = 100, TranslationY = 200, TargetSize = TargetSize });
            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(75, 150), _behavior.AverageCenter);

            list.Add(new Arrow() { TranslationX = 30, TranslationY = 0, TargetSize = TargetSize });
            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(60, 100), _behavior.AverageCenter);
        }

        [Test]
        public void UpdateAverageTest()
        {
            Shoot.AverageIsVisible = true;
            _canvas.Setup(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()));

            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 50, TranslationY = 100, TargetSize = TargetSize });
            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 100, TranslationY = 200, TargetSize = TargetSize });

            var X = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationX));
            var Y = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationY));
            _canvas.Setup(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)),
                    Times.AtLeast(1));

            Counter.AddArrowIfPossible(new Arrow() { TranslationX = 300, TranslationY = 600, TargetSize = TargetSize });
            X = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationX));
            Y = StatisticHelper.CalculateStdDev(Counter.ArrowsShowed.Select(a => a.TranslationY));
            _canvas.Setup(mock => mock.CreateAverageVisual(X, Y, new Point(150, 300)));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(X, Y, new Point(150, 300)),
                    Times.AtLeast(1));
        }
    }
}
