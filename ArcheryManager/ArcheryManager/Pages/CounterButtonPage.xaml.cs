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
    public partial class CounterButtonPage : ContentPage, IToolbarItemsHolder
    {
        public readonly ScoreCounter Counter;
        private readonly CountSetting CountSetting;

        private readonly IGeneralCounterSetting GeneralCounterSetting;

        public CounterButtonPage(IGeneralCounterSetting generalCounterSetting)
        {
            InitializeComponent();
            GeneralCounterSetting = generalCounterSetting;
            var arrowSetting = generalCounterSetting.ArrowSetting;
            var countSetting = generalCounterSetting.CountSetting;
            countSetting.HaveTarget = false;
            CountSetting = countSetting;

            Counter = new ScoreCounter(generalCounterSetting);

            totalCounter.BindingContext = Counter;

            scoreList.ArrowSetting = generalCounterSetting.ArrowSetting;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = generalCounterSetting.ScoreResult.CurrentArrows;

            var selectBehavior = new SelectableArrowInListBehavior(this.ToolbarItems, generalCounterSetting);
            scoreList.Behaviors.Add(selectBehavior);

            var behavior = new CounterButtonBehavior(generalCounterSetting, Counter);
            counterButtons.Behaviors.Add(behavior);

            var toolbarBehavior = new CounterToolbarItemsBehavior<CounterButtonPage>(generalCounterSetting, Counter);
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
            var page = new SettingTargetPage(GeneralCounterSetting) { BindingContext = CountSetting };
            App.NavigationPage.PushAsync(page);
        }
    }
}
