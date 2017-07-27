using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            _generalCounterSetting = new GeneralCounterSetting()
            {
                ArrowSetting = EnglishArrowSetting.Instance,
                CountSetting = new CountSetting(),
                ScoreResult = new ScoreResult()
            };

            _counter = new ScoreCounter(_generalCounterSetting);
            _behavior = new AverageBehavior(null, _counter, _generalCounterSetting);
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
            list.Add(new Arrow(0, 0, new Point(50, 100), 0));

            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(50, 100), _behavior.AverageCenter); // same point

            list.Add(new Arrow(0, 0, new Point(100, 200), 0));
            _behavior.UpdateAverageCenter(list);
            Assert.AreEqual(new Point(75, 150), _behavior.AverageCenter);

            list.Add(new Arrow(0, 0, new Point(30, 0), 0));
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

            _counter.AddArrow(new Arrow(0, 0, new Point(50, 100), 0));
            _counter.AddArrow(new Arrow(0, 0, new Point(100, 200), 0));

            var X = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationX));
            var Y = StatisticHelper.CalculateStdDev(_counter.ArrowsShowed.Select(a => a.TranslationY));
            _canvas.Setup(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)));
            _behavior.UpdateAverage();
            _canvas.Verify(mock => mock.CreateAverageVisual(X, Y, new Point(75, 150)),
                    Times.AtLeast(1));

            _counter.AddArrow(new Arrow(0, 0, new Point(300, 600), 0));
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

            _counter.AddArrow(new Arrow(0, 0, new Point(50, 100), 0));
            _counter.AddArrow(new Arrow(0, 0, new Point(100, 200), 0));
            _counter.AddArrow(new Arrow(0, 0, new Point(300, 600), 0));

            _canvas.Verify(mock => mock.CreateAverageVisual(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<Point>()),
            Times.Never());
        }
    }
}
