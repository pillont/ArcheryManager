using System.Runtime.CompilerServices;
using ArcheryManager.Pages;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class TargetSetting : BindableObject
    {
        public CountSetting CountSetting { get; set; }

        public static readonly BindableProperty HaveTargetProperty =
                      BindableProperty.Create(nameof(HaveTarget), typeof(bool), typeof(TargetSetting), true);

        public bool HaveTarget
        {
            get { return (bool)GetValue(HaveTargetProperty); }
            set { SetValue(HaveTargetProperty, value); }
        }

        public static readonly BindableProperty IsDecreasingOrderProperty =
                      BindableProperty.Create(nameof(IsDecreasingOrder), typeof(bool), typeof(TargetSetting), false);

        public bool IsDecreasingOrder
        {
            get { return (bool)GetValue(IsDecreasingOrderProperty); }
            set { SetValue(IsDecreasingOrderProperty, value); }
        }

        public static readonly BindableProperty ShowAllArrowsProperty =
                      BindableProperty.Create(nameof(ShowAllArrows), typeof(bool), typeof(TargetSetting), false);

        public bool ShowAllArrows
        {
            get { return (bool)GetValue(ShowAllArrowsProperty); }
            set { SetValue(ShowAllArrowsProperty, value); }
        }

        public static readonly BindableProperty AverageIsVisibleProperty =
                      BindableProperty.Create(nameof(AverageIsVisible), typeof(bool), typeof(TargetSetting), false);

        public bool AverageIsVisible
        {
            get { return (bool)GetValue(AverageIsVisibleProperty); }
            set { SetValue(AverageIsVisibleProperty, value); }
        }

        public TargetSetting(CountSetting countSetting)
        {
            this.CountSetting = countSetting;
        }
    }
}
