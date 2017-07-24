using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterSelectorPage : ContentPage
    {
        private CountSetting CountSetting => GeneralCounterSetting.CountSetting;

        private readonly GeneralCounterSetting GeneralCounterSetting;

        public CounterSelectorPage(GeneralCounterSetting generalCounterSetting)
        {
            InitializeComponent();
            GeneralCounterSetting = generalCounterSetting;
            GeneralCounterSetting.CountSetting = new CountSetting();

            this.BindingContext = CountSetting;

            foreach (var image in imageGrid.Children)
            {
                var tap = new TapGestureRecognizer();
                tap.Tapped += Image_Tapped;
                image.GestureRecognizers.Add(tap);
            }

            var first = imageGrid.Children.First() as TargetImage;
            SelectTarget(first);

            var validButton = new ToolbarItem()
            {
                Text = AppResources.Valid,
                Command = new Command(Valid_Clicked),
            };
            ToolbarItems.Add(validButton);
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            SelectTarget(sender as TargetImage);
        }

        public void SelectTarget(TargetImage image)
        {
            foreach (TargetImage i in imageGrid.Children)
            {
                i.IsSelected = false;
            }

            CountSetting.TargetStyle = image.StyleTarget;

            image.IsSelected = true;
        }

        /// <summary>
        /// limit min of Arrow count to const
        /// </summary>
        private void ArrowCount_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            int val = Convert.ToInt32(entry.Text);
            if (val < CountSetting.MinArrowCount)
            {
                if (BindingContext != null)
                {
                    CountSetting.ArrowsCount = CountSetting.MinArrowCount;
                }
            }
        }

        private async void Valid_Clicked()
        {
            try
            {
                GeneralCounterSetting.ArrowSetting = ArrowsettingFactory.Create(CountSetting.TargetStyle);

                var page = CounterPageFactory.Create(GeneralCounterSetting);
                await App.NavigationPage.PushAsync(page);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
