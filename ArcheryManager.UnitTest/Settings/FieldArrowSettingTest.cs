using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using NUnit.Framework;
using System;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Settings
{
    [TestFixture]
    public class FieldArrowSettingTest
    {
        private readonly IArrowSetting Setting = FieldArrowSetting.Instance;

        [Test]
        public void ColorOfTest()
        {
            Assert.AreEqual(Color.Green, Setting.ColorOf("M"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("1"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("2"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("3"));
            Assert.AreEqual(Color.Gray, Setting.ColorOf("4"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("5"));
            Assert.AreEqual(Color.Yellow, Setting.ColorOf("6"));
            Assert.AreEqual(Color.White, Setting.ColorOf("test"));
        }

        [Test]
        public void ColorofTargetZoneTest()
        {
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(1));
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(2));
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(3));
            Assert.AreEqual(Color.Black, Setting.ColorofTargetZone(4));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(5));
            Assert.AreEqual(Color.Yellow, Setting.ColorofTargetZone(6));
            Assert.AreEqual(Color.White, Setting.ColorofTargetZone(42));
        }

        [Test]
        public void BorderColorZoneTest()
        {
            Assert.AreEqual(Color.White, Setting.BorderColorZone(3));
            Assert.AreEqual(Color.White, Setting.BorderColorZone(4));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(5));
            Assert.AreEqual(Color.Black, Setting.BorderColorZone(6));
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
            Assert.Throws<ArgumentException>(() => Setting.ScoreByIndex(42));
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
            Assert.Throws<ArgumentException>(() => Setting.ValueByScore("42"));
        }
    }
}
