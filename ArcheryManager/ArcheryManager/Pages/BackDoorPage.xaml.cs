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
            await Navigation.PushModalAsync(new TimerPage());
        }

        private async void Target_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TargetPage());
        }

        private async void ButtonCounter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CounterPage());
        }
    }
}
