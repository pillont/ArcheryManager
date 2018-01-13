using ArcheryManager.Entities;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Factories
{
    public static class CounterPageFactory
    {
        public static ContentPageWithGeneralEvent CreateSimpleCounter(CountedShoot shoot)
        {
            bool wantTarget = shoot.HaveTarget;

            ContentPageWithGeneralEvent Page;
            if (wantTarget)
            {
                Page = ViewFactory.CreatePage<TargetPageViewModel, TargetPage>() as ContentPageWithGeneralEvent;
            }
            else
            {
                Page = ViewFactory.CreatePage<CounterButtonPageViewModel, CounterButtonPage>() as ContentPageWithGeneralEvent;
            }

            var behavior = Resolver.Resolve<CounterToolbarItemsBehavior>();
            Page.Behaviors.Add(behavior);

            ApplyBackMessageBehavior(Page);
            return Page;
        }

        public static Page CreateTabbedCounter(CountedShoot shoot)
        {
            var counter = CreateSimpleCounter(shoot);
            var tabbed = new CountTabbedPage(counter);

            var behavior = new TransfertToolbarItemsBehavior();
            tabbed.Behaviors.Add(behavior);

            ApplyBackMessageBehavior(tabbed);
            return tabbed;
        }

        private static BackMessageBehavior<T> ApplyBackMessageBehavior<T>(T Page) where T : Page, IGeneralEventHolder
        {
            var arg = new AlertArg()
            {
                Title = AppResources.Question,
                Message = AppResources.SureQuitCount,
                Accept = AppResources.Yes,
                Cancel = AppResources.No
            };
            var behavior = new BackMessageBehavior<T>(arg);
            Page.Behaviors.Add(behavior);
            return behavior;
        }
    }
}
