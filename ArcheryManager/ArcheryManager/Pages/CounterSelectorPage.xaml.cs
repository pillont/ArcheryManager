using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Utils;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterSelectorPage : ContentPage
    {
        private CountSetting _setting;

        public CounterSelectorPage()
        {
            InitializeComponent();
            _setting = new CountSetting();
            this.BindingContext = _setting;

            foreach (var image in imageGrid.Children)
            {
                var tap = new TapGestureRecognizer();
                tap.Tapped += Image_Tapped;
                image.GestureRecognizers.Add(tap);
            }

            var first = imageGrid.Children.First() as TargetImage;
            SelectTarget(first);
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

            _setting.TargetStyle = image.StyleTarget;
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
                    _setting.ArrowsCount = CountSetting.MinArrowCount;
                }
            }
        }

        private async void Valid_Clicked(object sender, EventArgs e)
        {
            var page = CounterPageFactory.Create(_setting);
            await App.NavigationPage.PushAsync(page);
        }
    }
}
