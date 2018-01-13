using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Resources;
using ArcheryManager.Upjv;
using ArcheryManager.ViewModels;
using Moq;
using NUnit.Framework;
using Refit;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using static ArcheryManager.CustomControls.TargetImage;
using Xamarin.Forms;
using ArcheryManager.Utils;
using System.Threading;
using ArcheryManager.Controllers;
using ArcheryGlobalResult.Upjv;
using System.Collections.Generic;

namespace ArcheryManager.UnitTest.ViewModels
{
    [TestFixture]
    public class ConnectedShootPageViewModelTest
    {
        /*
        private const string NotExistingEmail = "notExistingEmail@email";

        private List<JsonRegistered> All = new List<JsonRegistered>()
        {
            new JsonRegistered { FirstName = "firstname2", Name = "name2", Category = "cate 2", Licence = "licence 2"},
            new JsonRegistered { FirstName = "firstname3", Name = "name3", Category = "cate 3", Licence = "licence 3"},
            new JsonRegistered { FirstName = "firstname1", Name = "name1", Category = "cate 1", Licence = "licence 1"},
        };

        private Mock<IUpjvScore> Api;
        private CounterManager Manager;
        private ConnectedShootPage Page;
        private Mock<TargetStarterController> Starter;
        private ConnectedShootPageViewModel ViewModel;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            Starter = new Mock<TargetStarterController>(null, null);
            Manager = new CounterManager();
            Api = new Mock<IUpjvScore>();
            Api.Setup(api => api.GetAll()).Returns(Task.Run<IEnumerable<JsonRegistered>>(() => All));

            var mock = new Mock<ConnectedShootPageViewModel>(Manager, Starter.Object, Api.Object);
            mock.Setup(vm => vm.ApiStartShootCall(It.IsAny<string>())).Returns<string>((obj) => Task.Run(() =>
             {
                 return new JsonShoot() { Id = 12, TargetStyleString = TargetStyle.EnglishTarget.ToString() };
             }));

            ViewModel = mock.Object;

            Page = new ConnectedShootPage() { BindingContext = ViewModel };
        }

        [Test]
        public void InitValuesTest()
        {
            Assert.AreEqual(3, ViewModel.Registereds.Count());
            Assert.IsTrue(ViewModel.Registereds.Contains(All[2]));
            Assert.IsTrue(ViewModel.Registereds.Contains(All[0]));
            Assert.IsTrue(ViewModel.Registereds.Contains(All[1]));
        }

        [Test]
        public void ListItemsBindingTest()
        {
            Page.RegisteredList.SelectedItem = All[0];

            var items = Page.RegisteredList.ItemsSource;
            Assert.AreEqual(items, ViewModel.Registereds);
            Assert.AreEqual(All[0], ViewModel.Selected);
        }

        [Test]
        public void StartTargetTest()
        {
            Page.RegisteredList.SelectedItem = All.First();

            Starter.ResetCalls();
            Page.ConnectButton.Command.Execute(null);
            Thread.Sleep(1000);

            Starter.Verify(st => st.StartPage(), Times.Once);
            var shoot = Manager.CurrentShoot;
            Assert.IsTrue(shoot.HaveTarget);
            Assert.AreEqual(3, shoot.ArrowsCount);
            Assert.AreEqual(TargetStyle.EnglishTarget, shoot.TargetStyle);
        }*/
    }
}
