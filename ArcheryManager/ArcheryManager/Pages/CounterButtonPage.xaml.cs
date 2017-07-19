using ArcheryManager.Settings;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using System;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterButtonPage : ContentPage
    {
        private readonly TargetSetting Setting;
        private readonly ScoreCounter Counter;
        private EnglishArrowSetting instance;

        public CounterButtonPage(IArrowSetting arrowSetting, CountSetting countSetting)
        {
            InitializeComponent();

            this.Setting = new TargetSetting(countSetting) { HaveTarget = false };
            Counter = new ScoreCounter(Setting, ToolbarItems, arrowSetting);
            totalCounter.BindingContext = Counter;
            scoreList.Setting = Counter.ArrowSetting;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = Counter.CurrentArrows;

            counterButtons.Counter = Counter;

            var selectBehavior = new SelectableArrowInListBehavior(this.ToolbarItems);
            scoreList.Behaviors.Add(selectBehavior);

            SetupToolbarItems();
        }

        public CounterButtonPage(EnglishArrowSetting instance)
        {
            this.instance = instance;
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
            var page = new SettingTargetPage() { BindingContext = Setting };
            App.NavigationPage.PushAsync(page);
        }
    }
}
