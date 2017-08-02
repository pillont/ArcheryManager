using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class CounterPageFactory
    {
        public static Page CreateSimpleCounter(GeneralCounterSetting generalCounterSetting)
        {
            bool wantTarget = generalCounterSetting.CountSetting.HaveTarget;
            generalCounterSetting.ScoreResult = new ScoreResult();

            ContentPageWithGeneralEvent Page;
            if (wantTarget)
            {
                Page = new TargetPage();
            }
            else
            {
                Page = new CounterButtonPage();
            }

            var arg = new AlertArg()
            {
                Title = AppResources.Question,
                Message = AppResources.SureQuitCount,
                Accept = AppResources.Yes,
                Cancel = AppResources.No
            };
            var behavior = new BackMessageBehavior(App.NavigationPage, arg);
            Page.Behaviors.Add(behavior);
            return Page;
        }

        public static Page CreateTabbedCounter(GeneralCounterSetting generalCounterSetting)
        {
            var counter = CreateSimpleCounter(generalCounterSetting);
            var tabbed = new CountTabbedPage(counter);
            return tabbed;
        }
    }
}
