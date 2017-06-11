using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using NUnit.Framework;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Settings
{
    [TestFixture]
    public class EnglishArrowSettingFactoryTest
    {
        private readonly IArrowSetting Setting = EnglishArrowSetting.Instance;

        [Test]
        public void ColorOfTest()
        {
            Assert.AreEqual(Color.Green, Setting.ColorOf("M"));
            Assert.AreEqual(Color.White, Setting.ColorOf("1"));
            Assert.AreEqual(Color.White, Setting.ColorOf("2"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("3"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("4"));
            Assert.AreEqual(Color.CornflowerBlue, Setting.ColorOf("5"));
            Assert.AreEqual(Color.CornflowerBlue, Setting.ColorOf("6"));
            Assert.AreEqual(Color.Red, Setting.ColorOf("7"));
            Assert.AreEqual(Color.Red, Setting.ColorOf("8"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("9"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("10"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("X10"));
            Assert.AreEqual(Color.Green, Setting.ColorOf("Test"));
        }

        [Test]
        public void ColorofTargetZoneTest()
        {
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(0));
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(1));
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(2));
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(3));
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(4));
            Assert.AreEqual(Color.Blue, Setting.ColorofTargetZone(5));
            Assert.AreEqual(Color.Blue, Setting.ColorofTargetZone(6));
            Assert.AreEqual(Color.Red, Setting.ColorofTargetZone(7));
            Assert.AreEqual(Color.Red, Setting.ColorofTargetZone(8));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(9));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(10));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(11));
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(42));
        }

        [Test]
        public void BorderColorZoneTest()
        {
            Assert.AreEqual(Color.White, Setting.BorderColorZone(3));
            Assert.AreEqual(Color.White, Setting.BorderColorZone(4));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(7));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(42));
        }

        [Test]
        public void ScoreByIndexTest()
        {
            Assert.AreEqual("M", Setting.ScoreByIndex(0));
            Assert.AreEqual("1", Setting.ScoreByIndex(1));
            Assert.AreEqual("2", Setting.ScoreByIndex(2));
            Assert.AreEqual("3", Setting.ScoreByIndex(3));
            Assert.AreEqual("4", Setting.ScoreByIndex(4));
            Assert.AreEqual("5", Setting.ScoreByIndex(5));
            Assert.AreEqual("6", Setting.ScoreByIndex(6));
            Assert.AreEqual("7", Setting.ScoreByIndex(7));
            Assert.AreEqual("8", Setting.ScoreByIndex(8));
            Assert.AreEqual("9", Setting.ScoreByIndex(9));
            Assert.AreEqual("10", Setting.ScoreByIndex(10));
            Assert.AreEqual("X10", Setting.ScoreByIndex(11));
            Assert.AreEqual("M", Setting.ScoreByIndex(42));
        }

        [Test]
        public void ValueByScoreTest()
        {
            Assert.AreEqual(0, Setting.ValueByScore("M"));
            Assert.AreEqual(1, Setting.ValueByScore("1"));
            Assert.AreEqual(2, Setting.ValueByScore("2"));
            Assert.AreEqual(3, Setting.ValueByScore("3"));
            Assert.AreEqual(4, Setting.ValueByScore("4"));
            Assert.AreEqual(5, Setting.ValueByScore("5"));
            Assert.AreEqual(6, Setting.ValueByScore("6"));
            Assert.AreEqual(7, Setting.ValueByScore("7"));
            Assert.AreEqual(8, Setting.ValueByScore("8"));
            Assert.AreEqual(9, Setting.ValueByScore("9"));
            Assert.AreEqual(10, Setting.ValueByScore("10"));
            Assert.AreEqual(10, Setting.ValueByScore("X10"));
            Assert.AreEqual(0, Setting.ValueByScore("42"));
        }
    }
}
