using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using Moq;

namespace ArcheryManager.UnitTest.TestSettings
{
    internal class RegisterHelperTest
    {
        public static void InitTestRegister()
        {
            var manager = new CounterManager(new Mock<ISQLiteConnectionManager>().Object);
            InitTestRegister(manager);
        }

        public static void InitTestRegister(CounterManager manager)
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            RegisterHelper.InitViewFactory(manager);
        }
    }
}
