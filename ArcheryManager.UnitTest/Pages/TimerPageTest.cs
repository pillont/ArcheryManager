using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Pages
{
    [TestFixture]
    public class NumericPickerBehaviorTest
    {
        private NumericPickerBehavior behavior;

        [SetUp]
        public void Init()
        {
            behavior = new NumericPickerBehavior(40, 300, 5);
        }

        [Test]
        public void GenerateTimerPickerValues_MinTest()
        {
            var list = behavior.GenerateItems() as List<double>;

            Assert.NotNull(list);
            Assert.AreEqual(40, list.Min());
        }

        [Test]
        public void GenerateTimerPickerValues_MaxTest()
        {
            var list = behavior.GenerateItems() as List<double>;

            Assert.NotNull(list);
            Assert.AreEqual(300, list.Max());
        }

        [Test]
        public void GenerateTimerPickerValues_CountTest()
        {
            var list = behavior.GenerateItems() as List<double>;

            Assert.NotNull(list);
            Assert.IsTrue(list.All(i => i % 5 == 0));
            Assert.AreEqual(53, list.Count);
        }

        [Test]
        public void ItemSourceChangeTest()
        {
            var mock = new Mock<Picker>();
            mock.Object.Behaviors.Add(behavior);
            mock.SetupSet((val) => ItemsSource = val);
            //TODO rename this file and change the package!
            Assert.AreEqual(53, ItemsSource.Count);
        }
    }
}
