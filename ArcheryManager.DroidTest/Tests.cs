﻿using NUnit.Framework;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    [TestFixture]
    public class Tests
    {
        private AndroidApp app;

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
        }
    }
}
