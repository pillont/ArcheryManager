using ArcheryManager.Factories;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class CounterButtonGeneratorTest
    {
        [Test]
        public void EnglishTest()
        {
            var arrowSetting = EnglishArrowSetting.Instance;

            var generator = new CounterButtonGenerator(arrowSetting);
            var buttons = generator.GeneralButton();

            Assert.AreEqual(12, buttons.Count);
            Assert.AreEqual(1, buttons[0].Index);
            Assert.AreEqual(2, buttons[1].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[3].Index);
            Assert.AreEqual(5, buttons[4].Index);
            Assert.AreEqual(6, buttons[5].Index);
            Assert.AreEqual(7, buttons[6].Index);
            Assert.AreEqual(8, buttons[7].Index);
            Assert.AreEqual(9, buttons[8].Index);
            Assert.AreEqual(10, buttons[9].Index);
            Assert.AreEqual(11, buttons[10].Index);
            Assert.AreEqual(0, buttons[11].Index);
        }

        [Test]
        public void IndoorRecurveTest()
        {
            var arrowSetting = IndoorRecurveArrowSetting.Instance;

            var generator = new CounterButtonGenerator(arrowSetting);
            var buttons = generator.GeneralButton();

            Assert.AreEqual(6, buttons.Count);
            Assert.AreEqual(1, buttons[0].Index);
            Assert.AreEqual(2, buttons[1].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[3].Index);
            Assert.AreEqual(5, buttons[4].Index);
            Assert.AreEqual(0, buttons[5].Index);
        }

        [Test]
        public void IndoorCompoundTest()
        {
            var arrowSetting = IndoorCompoundArrowSetting.Instance;

            var generator = new CounterButtonGenerator(arrowSetting);
            var buttons = generator.GeneralButton();

            Assert.AreEqual(6, buttons.Count);
            Assert.AreEqual(1, buttons[0].Index);
            Assert.AreEqual(2, buttons[1].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[3].Index);
            Assert.AreEqual(6, buttons[4].Index);
            Assert.AreEqual(0, buttons[5].Index);
        }

        [Test]
        public void FieldTest()
        {
            var arrowSetting = FieldArrowSetting.Instance;

            var generator = new CounterButtonGenerator(arrowSetting);
            var buttons = generator.GeneralButton();

            Assert.AreEqual(7, buttons.Count);
            Assert.AreEqual(1, buttons[0].Index);
            Assert.AreEqual(2, buttons[1].Index);
            Assert.AreEqual(3, buttons[2].Index);
            Assert.AreEqual(4, buttons[3].Index);
            Assert.AreEqual(5, buttons[4].Index);
            Assert.AreEqual(6, buttons[5].Index);
            Assert.AreEqual(0, buttons[6].Index);
        }
    }
}
