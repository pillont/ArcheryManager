using ArcheryManager.Factories;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.CustomControls;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Interfaces;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPageWithRotationEvent, IToolbarItemsHolder
    {
        private readonly IGeneralCounterSetting GeneralCounterSetting;

        private CountSetting CountSetting => GeneralCounterSetting.CountSetting;
        private ScoreCounter Counter { get; set; }

        private readonly Target customTarget;

        public TargetPage(IGeneralCounterSetting generalCounterSetting)
        {
            InitializeComponent();

            GeneralCounterSetting = generalCounterSetting;
            Counter = new ScoreCounter(GeneralCounterSetting);

            #region view setup

            var behavior = new CounterToolbarItemsBehavior<TargetPage>(generalCounterSetting, Counter);
            this.Behaviors.Add(behavior);

            VerticalScreenRotation += SetupGridForVerticalDevice;
            HorizontalScreenRotation += SetupGridForHorizontalDevice;

            SetupToolbarItems(behavior);

            #endregion view setup

            customTarget = TargetFactory.Create(generalCounterSetting, Counter);
            targetGrid.Children.Add(customTarget);

            #region ScoreList

            var scoreList = ScoreListFactory.Create(customTarget, generalCounterSetting, ToolbarItems);
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scrollArrows.Content = scoreList;

            #endregion ScoreList

            #region total score

            totalCounter.BindingContext = Counter;

            #endregion total score
        }

        private void SetupToolbarItems(CounterToolbarItemsBehavior<TargetPage> behavior)
        {
            ToolbarItems.Clear();
            behavior.AddDefaultToolbarItems();
            AddTargetToolbarItems();
        }

        private void AddTargetToolbarItems()
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

        #region rotation device

        private void SetupGridForHorizontalDevice(Size screenSize)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();
            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(targetGrid, 0);
            Grid.SetRow(scrollArrows, 1);

            Grid.SetRowSpan(targetGrid, 2);

            Grid.SetColumn(totalCounter, 1);
            Grid.SetColumn(targetGrid, 0);
            Grid.SetColumn(scrollArrows, 1);

            var size = Math.Min(globalGrid.Width / 2, globalGrid.Height);
            size -= 10; //target margin

            customTarget.TargetSize = size;
            customTarget.DrawTargetVisual();
        }

        private void SetupGridForVerticalDevice(Size screenSize)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();

            int targetRate = 6;
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(targetRate, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(totalCounter, 0);
            Grid.SetColumn(targetGrid, 0);
            Grid.SetColumn(scrollArrows, 0);

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(targetGrid, 1);
            Grid.SetRow(scrollArrows, 2);

            Grid.SetRowSpan(targetGrid, 1);

            var size = Math.Min(globalGrid.Width, ((double)targetRate) / 8d * globalGrid.Height);
            size -= 10; //target margin

            customTarget.TargetSize = size;
            customTarget.DrawTargetVisual();
        }

        #endregion rotation device

        #region scrool list

        /// <summary>
        /// scroll down in list of arrow each time arrowList update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scrollArrows.Content, ScrollToPosition.End, true);
        }

        #endregion scrool list
    }
}
