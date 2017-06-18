using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System;
using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        private readonly ScreenRotationWatcher RotationWatcher;
        private readonly ScoreCounter Counter = new ScoreCounter();

        public TargetPage(IArrowSetting setting)
        {
            InitializeComponent();

            #region view setup

            RotationWatcher = new ScreenRotationWatcher(SetupGridForVerticalDevice, SetupGridForHorizontalDevice);
            SetupToolbarItems();

            #endregion view setup

            #region score list

            var arrowList = Counter.Arrows;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = arrowList;

            var selectBehavior = new SelectableArrowInListBehavior(this.ToolbarItems);
            selectBehavior.ItemsSelectedChange += SelectBehavior_SelectionChange;
            scoreList.Behaviors.Add(selectBehavior);

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

        private void SetupToolbarItems()
        {
            ToolbarItems.Clear();
            AddCounterToolbarItems();
            AddTargetToolbarItems();
        }

        private void AddTargetToolbarItems()
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

            Grid.SetRowSpan(customTarget, 2);

            Grid.SetColumn(totalCounter, 1);
            Grid.SetColumn(customTarget, 0);
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
            Grid.SetColumn(customTarget, 0);
            Grid.SetColumn(scrollArrows, 0);

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(customTarget, 1);
            Grid.SetRow(scrollArrows, 2);

            Grid.SetRowSpan(customTarget, 1);

            var size = Math.Min(globalGrid.Width, ((double)targetRate) / 8d * globalGrid.Height);
            size -= 10; //target margin

            customTarget.TargetSize = size;
            customTarget.DrawTargetVisual();
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

        #region scrool list

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        #endregion scrool list
    }
}
