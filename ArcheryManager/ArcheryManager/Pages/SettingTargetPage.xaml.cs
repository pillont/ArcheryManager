using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingTargetPage : ContentPage
    {
        private static readonly IGeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>();

        public new CountSetting BindingContext
        {
            get
            {
                if (base.BindingContext is CountSetting)
                {
                    return base.BindingContext as CountSetting;
                }
                else
                {
                    throw new InvalidCastException("binding target of " + nameof(SettingTargetPage) + " must be Target setting");
                }
            }
            set
            {
                base.BindingContext = value;
            }
        }

        public SettingTargetPage()
        {
            InitializeComponent();

            var finishButton = new ToolbarItem()
            {
                Text = AppResources.Finish,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(Finish),
            };
            ToolbarItems.Add(finishButton);
        }

        private void Finish()
        {
            App.NavigationPage.SendBackButtonPressed();
        }

        /// <summary>
        /// limit min of Arrow count to const
        /// </summary>
        private void ArrowCount_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            int val = BindingContext.ArrowsCount;
            if (val < CountSetting.MinArrowCount)
            {
                if (BindingContext != null)
                {
                    BindingContext.ArrowsCount = CountSetting.MinArrowCount;
                }
            }

            int currentFlightArrowNumber = GeneralCounterSetting.ScoreResult.CurrentArrows.Count;
            if (BindingContext.ArrowsCount < currentFlightArrowNumber)
            {
                DisplayAlert(ErrorResources.Error, ErrorResources.FlightMoreArrowThanNewLimit, AppResources.OK);
                BindingContext.ArrowsCount = currentFlightArrowNumber;
            }
        }
    }
}
