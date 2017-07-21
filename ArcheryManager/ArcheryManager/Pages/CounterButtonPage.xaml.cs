using ArcheryManager.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterButtonPage : ContentPage
    {
        private readonly ScoreCounter Counter;
        private readonly CountSetting CountSetting;

        public CounterButtonPage(IGeneralCounterSetting generalCounterSetting)
        {
            InitializeComponent();
            var arrowSetting = generalCounterSetting.ArrowSetting;
            var countSetting = generalCounterSetting.CountSetting;
            countSetting.HaveTarget = false;
            CountSetting = countSetting;

            Counter = new ScoreCounter(countSetting, arrowSetting, ToolbarItems);
            totalCounter.BindingContext = Counter;
            generalCounterSetting.ScoreCounter = Counter;

            scoreList.ArrowSetting = generalCounterSetting.ArrowSetting;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = Counter.CurrentArrows;

            counterButtons.GeneralCounterSetting = generalCounterSetting;

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
            Counter.AddDefaultToolbarItems();
            AddCounterButtonsToolbarItems();
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
