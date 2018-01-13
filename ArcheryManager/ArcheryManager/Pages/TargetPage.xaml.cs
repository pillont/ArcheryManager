using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPageWithGeneralEvent, IToolbarItemsHolder, ICounterPage
    {
        private Target customTarget { get; set; }

        public TargetPage()
        {
            InitializeComponent();

            ApplyRotationEvent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            customTarget = TargetFactory.Create(globalGrid);
            targetGrid.Children.Add(customTarget);

            AddScoreList();
        }

        private void AddScoreList()
        {
            ScoreListFactory.AddInScrollView(scrollArrows);
        }

        private void ApplyRotationEvent()
        {
            VerticalScreenRotation += SetupGridForVerticalDevice;
            HorizontalScreenRotation += SetupGridForHorizontalDevice;
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

            int targetRate = 52;
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(targetRate, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(9, GridUnitType.Star) });

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
    }

    public partial class TargetPageViewModel : ViewModel
    {
        public ScoreCounter Counter { get; }
        public CounterToolbarItemsBehavior CounterToolbarItemsBehavior { get; private set; }

        public TargetPageViewModel(ScoreCounter counter, CounterToolbarItemsBehavior behavior)
        {
            Counter = counter;
            CounterToolbarItemsBehavior = behavior;
        }
    }
}
