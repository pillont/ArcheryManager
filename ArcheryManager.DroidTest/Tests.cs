using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest
{
    [TestFixture]
    public class Tests
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = TestSetting.InitTestApplication();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
    }
}
