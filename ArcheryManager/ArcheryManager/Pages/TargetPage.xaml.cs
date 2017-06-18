using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        private readonly SelectableArrowInListBehavior SelectBehavior;
        private readonly RotationWatcher RotationWatcher;
        private readonly ScoreCounter Counter = new ScoreCounter();

        public TargetPage(IArrowSetting setting)
        {
            InitializeComponent();

            #region view setup

            RotationWatcher = new RotationWatcher(SetupGridForVerticalDevice, SetupGridForHorizontalDevice);
            ShowGeneralButtonsInTitle();

            #endregion view setup

            #region score list

            var arrowList = Counter.Arrows;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = arrowList;

            SelectBehavior = new SelectableArrowInListBehavior();
            SelectBehavior.ItemsSelectedChange += SelectBehavior_SelectionChange;
            scoreList.Behaviors.Add(SelectBehavior);

            #endregion score list

            #region target

            customTarget.Items = arrowList;
            customTarget.Setting = setting;

            var behavior = new MovableTargetBehavior(Counter);
            customTarget.Behaviors.Add(behavior);

            #endregion target

            #region total score

            totalCounter.BindingContext = Counter;

            #endregion total score
        }

        #region rotation device

        /// <summary>
        /// event when device rotate
        /// </summary>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            RotationWatcher.UpdateView(width, height);
        }

        private void SetupGridForHorizontalDevice(Size screenSize)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();
            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(customTarget, 0);
            Grid.SetRow(scrollArrows, 1);

            Grid.SetRowSpan(customTarget, 4);

            Grid.SetColumn(totalCounter, 1);
            Grid.SetColumn(customTarget, 0);
            Grid.SetColumn(scrollArrows, 1);
        }

        private void SetupGridForVerticalDevice(Size screenSize)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();

            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(6, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(totalCounter, 0);
            Grid.SetColumn(customTarget, 0);
            Grid.SetColumn(scrollArrows, 0);

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(customTarget, 1);
            Grid.SetRow(scrollArrows, 2);

            Grid.SetRowSpan(customTarget, 1);
        }

        #endregion rotation device

        #region arrow selection

        private void SelectBehavior_SelectionChange(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //reset selection
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                customTarget.ResetSelection();
            }
            // new selected element
            if (e.NewItems != null)
            {
                SelectArrowsInTarget(e.NewItems);
            }
            // remove selected element
            if (e.OldItems != null)
            {
                UnSelectArrowsInTarget(e.OldItems);
            }

            // have selected element
            if (SelectBehavior.SelectedArrow.Count != 0)
            {
                ShowSelectionButtonsInTitle();
            }
            // have not selected element
            else
            {
                ShowGeneralButtonsInTitle();
            }
        }

        private void UnSelectArrowsInTarget(IList oldItems)
        {
            foreach (View v in oldItems)
            {
                var a = v.BindingContext as Arrow;
                customTarget.UnSelectArrow(a);
            }
        }

        private void SelectArrowsInTarget(IList newItems)
        {
            foreach (View v in newItems)
            {
                var a = v.BindingContext as Arrow;
                customTarget.SelectArrow(a);
            }
        }

        #endregion arrow selection

        #region title buttons

        private void ShowGeneralButtonsInTitle()
        {
            this.ToolbarItems.Clear();

            foreach (var item in GetGeneralTitleButtons())
            {
                this.ToolbarItems.Add(item);
            }
        }

        private void ShowSelectionButtonsInTitle()
        {
            this.ToolbarItems.Clear();

            foreach (var item in GetSelectionTitleButtons())
            {
                this.ToolbarItems.Add(item);
            }
        }

        private List<ToolbarItem> GetGeneralTitleButtons()
        {
            return new List<ToolbarItem>()
            {
                new ToolbarItem()
                {
                    Text = "Remove last",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(Counter.RemoveLastArrow)
                },

                new ToolbarItem()
                {
                    Text = "Remove all",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(Counter.ClearArrows)
                },

                new ToolbarItem()
                {
                    Text = "New Flight",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(Counter.NewFlight)
                },
                new ToolbarItem()
                {
                    Text = "Settings",
                    Order = ToolbarItemOrder.Secondary
                    //TODO make setting page
                },
            };
        }

        public List<ToolbarItem> GetSelectionTitleButtons()
        {
            return new List<ToolbarItem>()
            {
                new ToolbarItem()
                {
                    Text = "Unselect",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(SelectBehavior.UnSelect)
                },
                new ToolbarItem()
                {
                    Text = "Remove",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(SelectBehavior.RemoveSelection)
                }
            };
        }

        #endregion title buttons

        #region scrool list

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        #endregion scrool list
    }
}
