using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Models;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class CounterButtonBehaviorTest
    {
        private CounterButtonBehavior _behavior;
        private MockableBindableObject _button;
        private IGeneralCounterSetting _generalSetting;
        private ScoreCounter _counter;
        private Arrow _arrow1;
        private Arrow _arrow2;
        private Arrow _arrow3;

        [SetUp]
        public void Init()
        {
            _arrow1 = new Arrow(1, 0);
            _arrow2 = new Arrow(2, 0);
            _arrow3 = new Arrow(3, 0);
            _generalSetting = new GeneralCounterSetting();
            _counter = new ScoreCounter(_generalSetting);

            _behavior = new CounterButtonBehavior(_generalSetting, _counter);
            _button = new MockableBindableObject();
        }

        [Test]
        public void ButtonTap_ValueTest()
        {
            Assert.AreEqual(0, _counter.ArrowsShowed.Count);

            _button.BindingContext = _arrow1;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow3;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow2;
            _behavior.ButtonTap(_button);

            Assert.AreEqual(3, _counter.ArrowsShowed.Count);
            Assert.AreEqual(1, _counter.ArrowsShowed[0].Index);
            Assert.AreEqual(3, _counter.ArrowsShowed[1].Index);
            Assert.AreEqual(2, _counter.ArrowsShowed[2].Index);
        }

        [Test]
        public void ButtonTap_NumberInFlightTest()
        {
            Assert.AreEqual(0, _counter.ArrowsShowed.Count);

            _button.BindingContext = _arrow1;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow3;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow2;
            _behavior.ButtonTap(_button);

            Assert.AreEqual(0, _counter.ArrowsShowed[0].NumberInFlight);
            Assert.AreEqual(1, _counter.ArrowsShowed[1].NumberInFlight);
            Assert.AreEqual(2, _counter.ArrowsShowed[2].NumberInFlight);
        }

        [Test]
        public void ButtonTap_CounterNullTest()
        {
            _behavior = new CounterButtonBehavior(_generalSetting, null);
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));
            Assert.AreEqual(0, _counter.ArrowsShowed.Count);
        }

        [Test]
        public void ButtonTap_NotButtonTest()
        {
            _button.BindingContext = null;
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));

            _button.BindingContext = new object();
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));
            Assert.AreEqual(0, _counter.ArrowsShowed.Count);
        }
    }
}
