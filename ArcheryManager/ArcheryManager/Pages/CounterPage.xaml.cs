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
        private static readonly IArrowSetting EnglishSetting = EnglishArrowSetting.Instance;
        private readonly ScoreCounter Counter;

        public CounterPage()
        {
            InitializeComponent();
            Counter = new ScoreCounter();
            totalCounter.BindingContext = Counter;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = Counter.Arrows;

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
                Order = ToolbarItemOrder.Secondary
                //TODO make setting page
            });
        }

        private void AddCounterToolbarItems()
        {
            foreach (var item in Counter.AssociatedToolbarItem())
            {
                ToolbarItems.Add(item);
            }
        }
    }
}
