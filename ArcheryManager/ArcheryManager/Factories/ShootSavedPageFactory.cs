using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Factories
{
    public static class ShootSavedPageFactory
    {
        public static ShootSavedPage Create()
        {
            var page = ViewFactory.CreatePage<ShootSavedPageViewModel, ShootSavedPage>() as ShootSavedPage;
            var behavior = new RemoveWhenQuitBehavior();
            page.Behaviors.Add(behavior);
            return page;
        }
    }
}
