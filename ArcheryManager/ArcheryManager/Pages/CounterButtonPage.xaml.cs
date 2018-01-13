using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterButtonPage : ContentPageWithGeneralEvent, IToolbarItemsHolder, ICounterPage
    {
        private ArrowUniformGrid ScoreList { get; set; }

        public CounterButtonPage()
        {
            InitializeComponent();
            ApplyRotationEvent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var behavior = Resolver.Resolve<CounterButtonBehavior>();
            counterButtons.Behaviors.Add(behavior);

            ScoreListFactory.AddInScrollView(scrollArrows);
        }

        private void ApplyRotationEvent()
        {
            VerticalScreenRotation += SetupGridForVerticalDevice;
            HorizontalScreenRotation += SetupGridForHorizontalDevice;
        }

        private void SetupGridForHorizontalDevice(Size obj)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();

            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(totalCounter, 1);
            Grid.SetColumn(scrollArrows, 1);
            Grid.SetColumn(counterButtons, 0);

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(scrollArrows, 1);
            Grid.SetRow(counterButtons, 0);

            Grid.SetRowSpan(counterButtons, 2);
        }

        private void SetupGridForVerticalDevice(Size obj)
        {
            globalGrid.RowDefinitions.Clear();
            globalGrid.ColumnDefinitions.Clear();

            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

            Grid.SetColumn(totalCounter, 0);
            Grid.SetColumn(scrollArrows, 0);
            Grid.SetColumn(counterButtons, 0);

            Grid.SetRow(totalCounter, 0);
            Grid.SetRow(scrollArrows, 1);
            Grid.SetRow(counterButtons, 2);

            Grid.SetRowSpan(counterButtons, 1);
        }
    }

    public class CounterButtonPageViewModel : ViewModel
    {
        private readonly CounterManager Manager;
        public CounterButtonsViewModel CounterButtonsViewModel => Resolver.Resolve<CounterButtonsViewModel>();
        public ScoreCounter Counter => Manager.Counter;

        public CounterButtonPageViewModel(CounterManager manager)
        {
            Manager = manager;
        }
    }
}
