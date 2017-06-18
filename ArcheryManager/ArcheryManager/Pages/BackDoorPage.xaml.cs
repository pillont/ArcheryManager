using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackDoorPage : ContentPage
    {
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

            TargetPage target = new TargetPage(setting);
            await App.NavigationPage.PushAsync(target);
        }

        private async void ButtonCounter_Clicked(object sender, EventArgs e)
        {
            await App.NavigationPage.PushAsync(new CounterPage());
        }
    }
}
