using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class CounterToolbarItemsBehavior : CustomBehavior<ContentPageWithGeneralEvent>
    {
        private readonly ScoreCounter Counter;
        private readonly MessageManager MessageManager;
        private readonly CountedShoot Shoot;
        private readonly CounterToolbarGenerator ToolbarItemsGenerator;
        private ToolbarItem NewFlightButton { get; set; }

        public CounterToolbarItemsBehavior(CounterManager manager, CounterToolbarGenerator generator)
        {
            ToolbarItemsGenerator = generator;
            Counter = manager.Counter;
            Shoot = manager.CurrentShoot;
            MessageManager = manager.MessageManager;
        }

        public void AddDefaultToolbarItems()
        {
            foreach (var item in ToolbarItemsGenerator.ToolbarItems)
            {
                var arg = new ToolbarItemsArg()
                {
                    ToolbarItem = item,
                    PageType = typeof(ICounterPage)
                };
                MessagingCenterHelper.AddToolbarItem(this, arg);
            }
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject.PagePushed += AssociatedObject_PagePushed;
        }

        private void AddNewFlightButton()
        {
            NewFlightButton = ToolbarItemsGenerator.NewFlightButton;
            var arg = new ToolbarItemsArg()
            {
                ToolbarItem = NewFlightButton,
                PageType = typeof(ICounterPage)
            };
            MessagingCenterHelper.AddToolbarItem(this, arg);
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

        private void AssociatedObject_PagePushed(object sender, EventArgs e)
        {
            AssociatedObject.PagePushed -= AssociatedObject_PagePushed;

            Counter.PropertyChanged += Counter_PropertyChanged;
            Shoot.PropertyChanged += CountSetting_PropertyChanged;

            MessagingCenterHelper.ClearToolbarItem(this, new ClearArg<ToolbarItem>() { PageType = typeof(TabbedPage) });
            AddDefaultToolbarItems();
            AddNewFlightButtonIfCanValidFlight();
        }

        private bool CanValidFlight()
        {
            var currentArrows = Shoot.CurrentArrows;
            bool haveMaxArrowsCount = Shoot.HaveMaxArrowsCount;
            int arrowsCount = Shoot.ArrowsCount;

            return currentArrows != null &&
                currentArrows.Count > 0 &&
                ((!haveMaxArrowsCount)
                || currentArrows.Count >= arrowsCount);
        }

        private bool ContainsNewFlightButton()
        {
            var button = GetCurrentNewFlightButton();
            return button != null;
        }

        private void Counter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateFlightButton();
        }

        /// <summary>
        /// if setting value have changed
        /// </summary>
        private void CountSetting_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountedShoot.HaveMaxArrowsCount)
                || e.PropertyName == nameof(CountedShoot.ArrowsCount))
            {
                UpdateFlightButton();
            }
        }

        private ToolbarItem GetCurrentNewFlightButton()
        {
            string newFlightText = AppResources.NewFlight;
            return AssociatedObject.ToolbarItems.Where(i => i.Text == newFlightText).FirstOrDefault();
        }

        private void RemoveNewFlightButton()
        {
            if (NewFlightButton != null)
            {
                var arg = new ToolbarItemsArg()
                {
                    ToolbarItem = NewFlightButton,
                    PageType = typeof(ICounterPage)
                };

                MessagingCenterHelper.RemoveToolbarItem(this, arg);
                NewFlightButton = null;
            }
        }

        private void UpdateFlightButton()
        {
            RemoveNewFlightButton();
            AddNewFlightButtonIfCanValidFlight();
        }
    }
}
