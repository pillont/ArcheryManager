using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Factories
{
    public static class CounterSelectorPageFactory
    {
        public static CounterSelectorPage Create()
        {
            var page = ViewFactory.CreatePage<CounterSelectorPageViewModel, CounterSelectorPage>() as CounterSelectorPage;
            var behavior = new RemoveWhenQuitBehavior();
            page.Behaviors.Add(behavior);
            return page;
        }
    }
}
