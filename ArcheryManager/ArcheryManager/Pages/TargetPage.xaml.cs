using ArcheryManager.Behaviors;
using ArcheryManager.CustomControls.Targets;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        public static readonly BindableProperty CounterProperty =
                              BindableProperty.Create(nameof(Counter), typeof(ScoreCounter), typeof(TargetPage), null);

        public ScoreCounter Counter
        {
            get { return (ScoreCounter)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public TargetPage(IArrowSetting setting)
        {
            InitializeComponent();
            this.BindingContext = this;
            Counter = new ScoreCounter();

            var list = Counter.Arrows;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = list;
            customTarget.Items = list;
            customTarget.Setting = setting;

            var behavior = new MovableTargetBehavior(Counter);
            customTarget.Behaviors.Add(behavior);

            totalCounter.BindingContext = Counter;
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }
    }
}
