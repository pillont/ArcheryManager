using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Settings;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class CounterPageFactory
    {
        public static Page Create(GeneralCounterSetting generalCounterSetting)
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

            var behavior = new BackMessageBehavior();
            Page.Behaviors.Add(behavior);
            return Page;
        }
    }
}
