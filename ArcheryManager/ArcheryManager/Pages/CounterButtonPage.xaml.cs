using ArcheryManager.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Interfaces;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterButtonPage : ContentPageWithGeneralEvent, IToolbarItemsHolder
    {
        public readonly ScoreCounter Counter;
        private readonly CountSetting CountSetting;

        private static readonly IGeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>();

        public CounterButtonPage()
        {
            InitializeComponent();
            var arrowSetting = GeneralCounterSetting.ArrowSetting;
            var countSetting = GeneralCounterSetting.CountSetting;
            countSetting.HaveTarget = false;
            CountSetting = countSetting;

            Counter = new ScoreCounter(GeneralCounterSetting);

            totalCounter.BindingContext = Counter;

            scoreList.ArrowSetting = GeneralCounterSetting.ArrowSetting;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = GeneralCounterSetting.ScoreResult.CurrentArrows;

            var selectBehavior = new SelectableArrowInListBehavior(this.ToolbarItems, GeneralCounterSetting);
            scoreList.Behaviors.Add(selectBehavior);

            var behavior = new CounterButtonBehavior(GeneralCounterSetting, Counter);
            counterButtons.Behaviors.Add(behavior);

            var toolbarBehavior = new CounterToolbarItemsBehavior<CounterButtonPage>(GeneralCounterSetting, Counter);
            this.Behaviors.Add(toolbarBehavior);
            toolbarBehavior.AddDefaultToolbarItems();
            AddCounterButtonsToolbarItems();
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        private void AddCounterButtonsToolbarItems()
        {
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.Settings,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(OpenSettingPage)
            });
        }

        private void OpenSettingPage(object obj)
        {
            var page = new SettingTargetPage() { BindingContext = CountSetting };
            App.NavigationPage.PushAsync(page);
        }
    }
}
