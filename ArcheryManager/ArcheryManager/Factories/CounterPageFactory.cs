using ArcheryManager.Pages;
using ArcheryManager.Utils;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    internal class CounterPageFactory
    {
        public static Page Create(CountSetting setting)
        {
            var arrowSetting = ArrowsettingFactory.Create(setting.TargetStyle);

            if (setting.WantTarget)
            {
                var Page = new TargetPage(arrowSetting, setting);
                return Page;
            }
            else
            {
                var Page = new CounterButtonPage(arrowSetting, setting);
                return Page;
            }
        }
    }
}
