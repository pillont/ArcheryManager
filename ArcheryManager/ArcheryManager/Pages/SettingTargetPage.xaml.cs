using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingTargetPage : ContentPageWithGeneralEvent
    {
        public new SettingTargetPageViewModel BindingContext
        {
            get
            {
                return base.BindingContext as SettingTargetPageViewModel;
            }
        }

        public SettingTargetPage()
        {
            InitializeComponent();
            PagePushed += OnPushed;
        }

        protected void OnPushed(object sender, EventArgs arg)
        {
            var finishButton = new ToolbarItem()
            {
                Text = AppResources.Finish,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(BindingContext.Finish),
            };

            var argEvent = new ToolbarItemsArg()
            {
                ToolbarItem = finishButton,
                PageType = typeof(SettingTargetPage)
            };

            MessagingCenterHelper.AddToolbarItem(this, argEvent);
        }
    }

    public class SettingTargetPageViewModel : ViewModel, IArrowNumberHolder
    {
        public readonly ISQLiteConnectionManager SQLiteConnectionManager;

        private readonly CountedShoot Shoot;

        public int ArrowsCount { get; set; }
        public bool AverageIsVisible { get; set; }

        public IEnumerable<Flight> Flights
        {
            get
            {
                return Shoot.Flights;
            }
        }

        public bool HaveMaxArrowsCount { get; set; }
        public bool IsDecreasingOrder { get; set; }

        public LimitArrowNumberSelectorViewModel LimitArrowNumberSelectorViewModel
        {
            get
            {
                return new LimitArrowNumberSelectorViewModel(this);
            }
        }

        public bool ShowAllArrows { get; set; }
        public bool HaveTarget => Shoot.HaveTarget;

        public SettingTargetPageViewModel(CounterManager manager)
        {
            Shoot = manager.CurrentShoot;
            SQLiteConnectionManager = manager.DBSaver;

            HaveMaxArrowsCount = Shoot.HaveMaxArrowsCount;
            ShowAllArrows = Shoot.ShowAllArrows;
            AverageIsVisible = Shoot.AverageIsVisible;
            IsDecreasingOrder = Shoot.IsDecreasingOrder;
            ArrowsCount = Shoot.ArrowsCount;
        }

        public void Finish()
        {
            UpdateGeneralSetting();
            UpdateCounterInDB();
            MessagingCenterHelper.BackInNavigationPage(this);
        }

        private void UpdateCounterInDB()
        {
            SQLiteConnectionManager.UpdateWithChildrenAsync(Shoot);
        }

        private void UpdateGeneralSetting()
        {
            Shoot.ArrowsCount = ArrowsCount;
            Shoot.AverageIsVisible = AverageIsVisible;
            Shoot.HaveMaxArrowsCount = HaveMaxArrowsCount;
            Shoot.IsDecreasingOrder = IsDecreasingOrder;
            Shoot.ShowAllArrows = ShowAllArrows;
        }
    }
}
