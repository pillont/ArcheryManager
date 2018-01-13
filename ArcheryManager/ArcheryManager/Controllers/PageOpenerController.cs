using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Pages;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using static ArcheryManager.CustomControls.TargetImage;
using ArcheryManager.ViewModels;

namespace ArcheryManager.Controllers
{
    public class PageOpenerController
    {
        public readonly CounterManager Manager;

        public PageOpenerController(CounterManager manager)
        {
            Manager = manager;
        }

        public void ConnectedShoot()
        {
            var page = ViewFactory.CreatePage<ConnectedShootPageViewModel, ConnectedShootPage>() as Page;
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenCounterSelector()
        {
            var page = CounterSelectorPageFactory.Create();
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenEnglishButtonsCounterPage()
        {
            Manager.CurrentShoot = new CountedShoot()
            {
                TargetStyle = TargetStyle.EnglishTarget,
                HaveTarget = false
            };
            Manager.Counter.NewFlight();
            OpenNewCounterView();
        }

        public void OpenGeneralMenuPage()
        {
            var generalMenu = ViewFactory.CreatePage<GeneralMenuViewModel, GeneralMenu>() as Page;
            MessagingCenterHelper.PushInNavigationPage(this, generalMenu);
        }

        public void OpenLogPage()
        {
            var page = ViewFactory.CreatePage<LogPageViewModel, LogPage>() as Page;
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenNewCounterView()
        {
            var page = CounterPageFactory.CreateTabbedCounter(Manager.CurrentShoot);
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenRemarksPage()
        {
            Manager.CurrentShoot = new CountedShoot();
            Manager.Counter.NewFlight();
            var page = ViewFactory.CreatePage<RemarksPageViewModel, RemarksPage>() as Page;

            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenSaveCounterList()
        {
            var page = ShootSavedPageFactory.Create();
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        public void OpenTarget(TargetStyle style)
        {
            Manager.CurrentShoot = new CountedShoot()
            {
                TargetStyle = style,
                HaveTarget = true
            };
            Manager.Counter.NewFlight();

            OpenNewCounterView();
        }

        public void OpenTimerPage()
        {
            var page = new TimerPage();
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }
    }
}
