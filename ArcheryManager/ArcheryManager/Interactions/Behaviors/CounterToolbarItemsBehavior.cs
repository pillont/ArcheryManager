using ArcheryManager.Interfaces;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class CounterToolbarItemsBehavior<T> : CustomBehavior<T> where T : BindableObject, IToolbarItemsHolder
    {
        #region toolbar item

        private readonly IGeneralCounterSetting GeneralCounterSetting;
        private readonly ScoreCounter Counter;

        public CounterToolbarItemsBehavior(IGeneralCounterSetting generalCounterSetting, ScoreCounter counter)
        {
            GeneralCounterSetting = generalCounterSetting;
            Counter = counter;
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            var countSetting = GeneralCounterSetting.CountSetting;
            var result = GeneralCounterSetting.ScoreResult;
            result.CurrentArrows.CollectionChanged += Arrows_CollectionChanged;
            countSetting.PropertyChanged += CountSetting_PropertyChanged;
        }

        private void Arrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddNewFlightButtonIfCanValidFlight();
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove
                || e.Action == NotifyCollectionChangedAction.Reset)
            {
                RemoveNewFlightIfCantValidFlight();
            }
        }

        private void CountSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountSetting.HaveMaxArrowsCount)
                || e.PropertyName == nameof(CountSetting.ArrowsCount))
            {
                RemoveNewFlightButton();
                AddNewFlightButtonIfCanValidFlight();
            }
        }

        private void RemoveNewFlightIfCantValidFlight()
        {
            if (!CanValidFlight())
            {
                RemoveNewFlightButton();
            }
        }

        private void AddNewFlightButtonIfCanValidFlight()
        {
            if (CanValidFlight())
            {
                if (!ContainsNewFlightButton())
                {
                    AddNewFlightButton();
                }
            }
        }

        private bool CanValidFlight()
        {
            var currentArrows = GeneralCounterSetting.ScoreResult.CurrentArrows;
            bool haveMaxArrowsCount = GeneralCounterSetting.CountSetting.HaveMaxArrowsCount;
            var currentArrows1 = GeneralCounterSetting.ScoreResult.CurrentArrows;
            int arrowsCount = GeneralCounterSetting.CountSetting.ArrowsCount;

            return currentArrows.Count > 0 &&
                ((!haveMaxArrowsCount)
                || currentArrows1.Count >= arrowsCount);
        }

        public void AddDefaultToolbarItems()
        {
            AssociatedObject.ToolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.RemoveLast,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(Counter.RemoveLastArrow)
            });

            AssociatedObject.ToolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.RemoveAll,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => AskValidation(AppResources.RemoveAllQuestion, Counter.ClearArrows))
            });

            AssociatedObject.ToolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.Restart,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => AskValidation(AppResources.RestartQuestion, Counter.RestartCount))
            });
        }

        private void AddNewFlightButton()
        {
            AssociatedObject.ToolbarItems.Add(new ToolbarItem()
            {
                Text = AppResources.NewFlight,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => AskValidation(AppResources.NewFlightQuestion, Counter.NewFlight)),
            });
        }

        private bool ContainsNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            return button != null;
        }

        private ToolbarItem GetCurrentNewFlightButton()
        {
            string newFlightText = AppResources.NewFlight;
            return AssociatedObject.ToolbarItems.Where(i => i.Text == newFlightText).FirstOrDefault();
        }

        private void RemoveNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            if (button != null)
            {
                AssociatedObject.ToolbarItems.Remove(button);
            }
        }

        private async void AskValidation(string message, Action action)
        {
            var valid = await App.NavigationPage.DisplayAlert(AppResources.Question, message, AppResources.Yes, AppResources.No);
            if (valid)
            {
                action?.Invoke();
            }
        }

        #endregion toolbar item
    }
}
