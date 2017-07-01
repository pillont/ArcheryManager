using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class TargetSetting : BindableObject
    {
        public const int MinArrowCount = 3;
        public const int DefaultArrowCount = 6;

        public static readonly BindableProperty HaveMaxArrowsCountProperty =
                     BindableProperty.Create(nameof(HaveMaxArrowsCount), typeof(bool), typeof(TargetSetting), false);

        public bool HaveMaxArrowsCount
        {
            get { return (bool)GetValue(HaveMaxArrowsCountProperty); }
            set { SetValue(HaveMaxArrowsCountProperty, value); }
        }

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

        public static readonly BindableProperty ArrowsCountProperty =
                      BindableProperty.Create(nameof(ArrowsCount), typeof(int), typeof(TargetSetting), DefaultArrowCount);

        public int ArrowsCount
        {
            get { return (int)GetValue(ArrowsCountProperty); }
            set { SetValue(ArrowsCountProperty, value); }
        }
    }
}
