using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackDoorPage : ContentPage
    {
        private static readonly GeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>() as GeneralCounterSetting;

        public BackDoorPage()
        {
            InitializeComponent();
        }

        private async void Timer_Click(object sender, EventArgs e)
        {
            await App.NavigationPage.PushAsync(new TimerPage());
        }

        private async void Target_Click(object sender, EventArgs e)
        {
            try
            {
                IArrowSetting setting;
                if (sender == EnglishTargetButton)
                {
                    setting = EnglishArrowSetting.Instance;
                }
                else if (sender == fieldTargetButton)
                {
                    setting = FieldArrowSetting.Instance;
                }
                else if (sender == indoorCompoundTargetButton)
                {
                    setting = IndoorCompoundArrowSetting.Instance;
                }
                else // indoorRecurveTargetButton
                {
                    setting = IndoorRecurveArrowSetting.Instance;
                }

                var countSetting = new CountSetting() { HaveTarget = true };

                UpdateGeneralCounterSetting(setting, countSetting);
                await OpenNewCounterView();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        private async Task OpenNewCounterView()
        {
            var page = CounterPageFactory.Create(GeneralCounterSetting);
            await App.NavigationPage.PushAsync(page);
        }

        private static void UpdateGeneralCounterSetting(IArrowSetting setting, CountSetting countSetting)
        {
            GeneralCounterSetting.CountSetting = countSetting;
            GeneralCounterSetting.ArrowSetting = setting;
        }

        private async void ButtonCounter_Clicked(object sender, EventArgs e)
        {
            var countSetting = new CountSetting() { HaveTarget = false };
            var arrowSetting = EnglishArrowSetting.Instance;
            UpdateGeneralCounterSetting(arrowSetting, countSetting);
            await OpenNewCounterView();
        }

        private async void CounterSelector_Clicked(object sender, EventArgs e)
        {
            await App.NavigationPage.PushAsync(new CounterSelectorPage(GeneralCounterSetting));
        }
    }
}
