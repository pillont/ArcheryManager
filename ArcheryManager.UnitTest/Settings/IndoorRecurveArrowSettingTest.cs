using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Settings
{
    [TestFixture]
    public class IndoorRecurveArrowSettingTest
    {
        private readonly IArrowSetting Setting = IndoorRecurveArrowSetting.Instance;

        [Test]
        public void BorderColorZoneTest()
        {
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(3));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(4));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(5));
        }

        [Test]
        public void ColorofTargetZoneTest()
        {
            Assert.AreEqual(Color.Blue, Setting.ColorofTargetZone(1));
            Assert.AreEqual(Color.Red, Setting.ColorofTargetZone(2));
            Assert.AreEqual(Color.Red, Setting.ColorofTargetZone(3));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(4));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(5));
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(42));
        }

        [Test]
        public void ColorOfTest()
        {
            Assert.AreEqual(Color.Green, Setting.ColorOf("M"));
            Assert.AreEqual(Color.CornflowerBlue, Setting.ColorOf("6"));
            Assert.AreEqual(Color.Red, Setting.ColorOf("7"));
            Assert.AreEqual(Color.Red, Setting.ColorOf("8"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("9"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("10"));
            Assert.AreEqual(Color.Green, Setting.ColorOf("test"));
        }

        [Test]
        public void ScoreByIndexTest()
        {
            Assert.AreEqual("M", Setting.ScoreByIndex(0));
            Assert.AreEqual("6", Setting.ScoreByIndex(1));
            Assert.AreEqual("7", Setting.ScoreByIndex(2));
            Assert.AreEqual("8", Setting.ScoreByIndex(3));
            Assert.AreEqual("9", Setting.ScoreByIndex(4));
            Assert.AreEqual("10", Setting.ScoreByIndex(5));
            Assert.AreEqual("M", Setting.ScoreByIndex(42));
        }

        [Test]
        public void ValueByScoreTest()
        {
            Assert.AreEqual(0, Setting.ValueByScore("M"));
            Assert.AreEqual(6, Setting.ValueByScore("6"));
            Assert.AreEqual(7, Setting.ValueByScore("7"));
            Assert.AreEqual(8, Setting.ValueByScore("8"));
            Assert.AreEqual(9, Setting.ValueByScore("9"));
            Assert.AreEqual(10, Setting.ValueByScore("10"));
            Assert.AreEqual(0, Setting.ValueByScore("42"));
        }
    }
}
