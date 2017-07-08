using ArcheryManager.CustomControls;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ArcheryManager.UnitTest.Pages
{
    [TestFixture]
    public class NumericPickerTest
    {
        [Test]
        public void GenerateTimerPickerValues_MinTest()
        {
            var list = NumericPicker.GenerateItems(40, 300, 5) as List<double>;

            Assert.NotNull(list);
            Assert.AreEqual(40, list.Min());
        }

        [Test]
        public void GenerateTimerPickerValues_MaxTest()
        {
            var list = NumericPicker.GenerateItems(40, 300, 5) as List<double>;

            Assert.NotNull(list);
            Assert.AreEqual(300, list.Max());
        }

        [Test]
        public void GenerateTimerPickerValues_CountTest()
        {
            var list = NumericPicker.GenerateItems(40, 300, 5) as List<double>;

            Assert.NotNull(list);
            Assert.IsTrue(list.All(i => i % 5 == 0));
            Assert.AreEqual(53, list.Count);
        }
    }
}
