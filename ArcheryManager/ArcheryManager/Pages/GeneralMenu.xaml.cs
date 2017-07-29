using ArcheryManager.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralMenu : ContentPage
    {
        private static readonly GeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>() as GeneralCounterSetting;

        public GeneralMenu()
        {
            InitializeComponent();
        }

        private async void Timer_Tapped(object sender, System.EventArgs e)
        {
            await App.NavigationPage.PushAsync(new TimerPage());
        }

        private async void Counter_Tapped(object sender, System.EventArgs e)
        {
            await App.NavigationPage.PushAsync(new CounterSelectorPage(GeneralCounterSetting));
        }
    }
}
