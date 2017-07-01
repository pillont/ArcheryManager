using ArcheryManager.Settings;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Interactions.Behaviors;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        private readonly TargetSetting Setting;
        private static readonly IArrowSetting EnglishSetting = EnglishArrowSetting.Instance;
        private readonly ScoreCounter Counter;

        public CounterPage()
        {
            InitializeComponent();

            this.Setting = new TargetSetting() { HaveTarget = false };
            Counter = new ScoreCounter(Setting);
            totalCounter.BindingContext = Counter;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = Counter.CurrentArrows;

            counterButtons.Counter = Counter;
            counterButtons.Setting = EnglishSetting;

            var selectBehavior = new SelectableArrowInListBehavior(this.ToolbarItems);
            scoreList.Behaviors.Add(selectBehavior);

            SetupToolbarItems();
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        private void SetupToolbarItems()
        {
            ToolbarItems.Clear();
            AddCounterToolbarItems();
            AddCounterButtonsToolbarItems();
        }

        private void AddCounterButtonsToolbarItems()
        {
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(OpenSettingPage)
            });
        }

        private void OpenSettingPage(object obj)
        {
            var page = new SettingTargetPage() { BindingContext = Setting };
            App.NavigationPage.PushAsync(page);
        }

        private void AddCounterToolbarItems()
        {
            foreach (var item in Counter.AssociatedToolbarItem)
            {
                ToolbarItems.Add(item);
            }
        }
    }
}
