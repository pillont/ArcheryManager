using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class TargetSetting : BindableObject
    {
        public const int MinArrowCount = 3;

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
                      BindableProperty.Create(nameof(ArrowsCount), typeof(int), typeof(TargetSetting), MinArrowCount);

        public int ArrowsCount
        {
            get { return (int)GetValue(ArrowsCountProperty); }
            set { SetValue(ArrowsCountProperty, value); }
        }
    }
}
