using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public partial class LimitArrowNumberSelector : ContentView
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
                    throw new InvalidCastException("binding target of " + nameof(LimitArrowNumberSelector) + " must be Target setting");
                }
            }
            set
            {
                base.BindingContext = value;
            }
        }

        public LimitArrowNumberSelector()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                throw;
            }
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
                App.NavigationPage.DisplayAlert(ErrorResources.Error, ErrorResources.FlightMoreArrowThanNewLimit, AppResources.OK);
                BindingContext.ArrowsCount = currentFlightArrowNumber;
            }
        }
    }
}
