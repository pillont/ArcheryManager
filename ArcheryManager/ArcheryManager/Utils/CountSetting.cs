using Xamarin.Forms;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.Utils
{
    public class CountSetting : BindableObject
    {
        public const int MinArrowCount = 3;
        public const int DefaultArrowCount = 6;
        private const bool DefaultWantTarget = true;

        public static readonly BindableProperty ArrowsCountProperty =
                      BindableProperty.Create(nameof(ArrowsCount), typeof(int), typeof(CountSetting), DefaultArrowCount);

        public TargetStyle TargetStyle { get; set; }

        public int ArrowsCount
        {
            get { return (int)GetValue(ArrowsCountProperty); }
            set { SetValue(ArrowsCountProperty, value); }
        }

        public static readonly BindableProperty HaveMaxArrowsCountProperty =
                     BindableProperty.Create(nameof(HaveMaxArrowsCount), typeof(bool), typeof(CountSetting), false);

        public bool HaveMaxArrowsCount
        {
            get { return (bool)GetValue(HaveMaxArrowsCountProperty); }
            set { SetValue(HaveMaxArrowsCountProperty, value); }
        }

        public static readonly BindableProperty WantTargetProperty =
                      BindableProperty.Create(nameof(WantTarget), typeof(bool), typeof(CountSetting), DefaultWantTarget);

        public bool WantTarget
        {
            get { return (bool)GetValue(WantTargetProperty); }
            set { SetValue(WantTargetProperty, value); }
        }
    }
}
