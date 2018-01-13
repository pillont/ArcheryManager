using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class CounterButtonGeneratorTest
    {
        [Test]
        public void EnglishTest()
        {
            var arrowSetting = EnglishArrowSetting.Instance;
            var buttons = CounterButtonGenerator.GeneralButton(arrowSetting);

            Assert.AreEqual(12, buttons.Count);
            Assert.AreEqual(0, buttons[11].Index);
            Assert.AreEqual(1, buttons[10].Index);
            Assert.AreEqual(2, buttons[9].Index);
            Assert.AreEqual(3, buttons[8].Index);
            Assert.AreEqual(4, buttons[7].Index);
            Assert.AreEqual(5, buttons[6].Index);
            Assert.AreEqual(6, buttons[5].Index);
            Assert.AreEqual(7, buttons[4].Index);
            Assert.AreEqual(8, buttons[3].Index);
            Assert.AreEqual(9, buttons[2].Index);
            Assert.AreEqual(10, buttons[1].Index);
            Assert.AreEqual(11, buttons[0].Index);
        }

        [Test]
        public void FieldTest()
        {
            var arrowSetting = FieldArrowSetting.Instance;

            var buttons = CounterButtonGenerator.GeneralButton(arrowSetting);

            Assert.AreEqual(7, buttons.Count);
            Assert.AreEqual(0, buttons[6].Index);
            Assert.AreEqual(1, buttons[5].Index);
            Assert.AreEqual(2, buttons[4].Index);
            Assert.AreEqual(3, buttons[3].Index);
            Assert.AreEqual(4, buttons[2].Index);
            Assert.AreEqual(5, buttons[1].Index);
            Assert.AreEqual(6, buttons[0].Index);
        }

        [Test]
        public void IndoorCompoundTest()
        {
            var arrowSetting = IndoorCompoundArrowSetting.Instance;

            var buttons = CounterButtonGenerator.GeneralButton(arrowSetting);

            Assert.AreEqual(6, buttons.Count);
            Assert.AreEqual(0, buttons[5].Index);
            Assert.AreEqual(1, buttons[4].Index);
            Assert.AreEqual(2, buttons[3].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[1].Index);
            Assert.AreEqual(6, buttons[0].Index);
        }

        [Test]
        public void IndoorRecurveTest()
        {
            var arrowSetting = IndoorRecurveArrowSetting.Instance;

            var buttons = CounterButtonGenerator.GeneralButton(arrowSetting);

            Assert.AreEqual(6, buttons.Count);
            Assert.AreEqual(0, buttons[5].Index);
            Assert.AreEqual(1, buttons[4].Index);
            Assert.AreEqual(2, buttons[3].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[1].Index);
            Assert.AreEqual(5, buttons[0].Index);
        }
    }
}
