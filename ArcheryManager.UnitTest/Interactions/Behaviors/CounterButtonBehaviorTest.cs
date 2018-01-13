using ArcheryManager.Entities;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Linq;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class CounterButtonBehaviorTest
    {
        private Arrow _arrow1;
        private Arrow _arrow2;
        private Arrow _arrow3;
        private CounterButtonBehavior _behavior;
        private MockableBindableObject _button;
        private CounterManager Manager;

        [Test]
        public void ButtonTap_NotButtonTest()
        {
            _button.BindingContext = null;
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));

            _button.BindingContext = new object();
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));
            Assert.AreEqual(0, Manager.Counter.ArrowsShowed.Count());
        }

        [Test]
        public void ButtonTap_NumberInFlightTest()
        {
            Assert.AreEqual(0, Manager.Counter.ArrowsShowed.Count());

            _button.BindingContext = _arrow1;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow3;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow2;
            _behavior.ButtonTap(_button);

            Assert.AreEqual(0, Manager.Counter.ArrowsShowed.ToList()[0].NumberInFlight);
            Assert.AreEqual(1, Manager.Counter.ArrowsShowed.ToList()[1].NumberInFlight);
            Assert.AreEqual(2, Manager.Counter.ArrowsShowed.ToList()[2].NumberInFlight);
        }

        [Test]
        public void ButtonTap_ValueTest()
        {
            Assert.AreEqual(0, Manager.Counter.ArrowsShowed.Count());

            _button.BindingContext = _arrow1;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow3;
            _behavior.ButtonTap(_button);
            _button.BindingContext = _arrow2;
            _behavior.ButtonTap(_button);

            Assert.AreEqual(3, Manager.Counter.ArrowsShowed.Count());
            Assert.AreEqual(1, Manager.Counter.ArrowsShowed.ToList()[0].Index);
            Assert.AreEqual(3, Manager.Counter.ArrowsShowed.ToList()[1].Index);
            Assert.AreEqual(2, Manager.Counter.ArrowsShowed.ToList()[2].Index);
        }

        [Test]
        public void ButtonTapCounterNullTest()
        {
            _behavior = new CounterButtonBehavior(Manager);
            Assert.DoesNotThrow(() => _behavior.ButtonTap(_button));
            Assert.AreEqual(0, Manager.Counter.ArrowsShowed.Count());
        }

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            _arrow1 = new Arrow() { Index = 1 };
            _arrow2 = new Arrow() { Index = 2 };
            _arrow3 = new Arrow() { Index = 3 };

            var shoot = new CountedShoot();
            Manager = new CounterManager() { CurrentShoot = shoot };
            Manager.Counter.NewFlight();
            _behavior = new CounterButtonBehavior(Manager);
            _button = new MockableBindableObject();
        }
    }
}
