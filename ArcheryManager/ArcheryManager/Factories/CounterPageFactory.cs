using ArcheryManager.Pages;
using ArcheryManager.Settings;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class CounterPageFactory
    {
        public static Page Create(IGeneralCounterSetting GeneralCounterSetting)
        {
            bool wantTarget = GeneralCounterSetting.CountSetting.WantTarget;

            if (wantTarget)
            {
                var Page = new TargetPage(GeneralCounterSetting);
                return Page;
            }
            else
            {
                var Page = new CounterButtonPage(GeneralCounterSetting);
                return Page;
            }
        }
    }
}
