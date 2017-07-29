using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
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

            if (wantTarget)
            {
                var Page = new TargetPage();
                return Page;
            }
            else
            {
                var Page = new CounterButtonPage();
                return Page;
            }
        }
    }
}
