using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.ModelViews;
using ArcheryManager.Utils;
using ArcheryManager.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;
using System.Collections.Generic;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShootSavedPage : ContentPage
    {
        public ShootSavedPage()
        {
            InitializeComponent();
        }
    }

    public partial class ShootSavedPageViewModel : ViewModel
    {
        private readonly CounterManager Manager;
        private ReadOnlyCollection<ListViewGroup<ShootInList>> _groupedItems;
        private bool _isRefreshing;
        private ReadOnlyCollection<ShootInList> _items;
        private ShootInList _selectedItem;
        private bool _shownFinish = true;
        private bool _shownNotFinish = true;

        public ReadOnlyCollection<ListViewGroup<ShootInList>> GroupedItems
        {
            get { return _groupedItems; }
            private set
            {
                _groupedItems = value;
                NotifyPropertyChanged(nameof(GroupedItems));
            }
        }

        public bool IsEmptyList
        {
            get
            {
                return Items != null
                                ? Items.Count() == 0
                                : true;
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                NotifyPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ReadOnlyCollection<ShootInList> Items
        {
            get { return _items; }
            private set
            {
                _items = value;
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(IsEmptyList));
            }
        }

        public ICommand OpenCommand => new Command(OpenCurrentShoot);
        public ICommand RefreshCommand => new Command(RefreshItems);

        public ShootInList SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == null && Items.Count() != 0)
                {
                    value = DefaultSelectedItem;
                }

                if (_selectedItem != null)
                    _selectedItem.IsSelected = false;
                _selectedItem = value;
                if (_selectedItem != null)
                    _selectedItem.IsSelected = true;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public bool ShownFinish
        {
            get { return _shownFinish; }
            set
            {
                _shownFinish = value;
                UpdateItemsAsync();
                NotifyPropertyChanged(nameof(ShownFinish));
            }
        }

        public bool ShownNotFinish
        {
            get { return _shownNotFinish; }
            set
            {
                _shownNotFinish = value;
                UpdateItemsAsync();
                NotifyPropertyChanged(nameof(ShownNotFinish));
            }
        }

        private List<CountedShoot> Counters { get; set; }
        private ShootInList DefaultSelectedItem => Items.FirstOrDefault();

        public ShootSavedPageViewModel(CounterManager manager)
        {
            Manager = manager;

            RefreshItems();
        }

        /// <summary>
        /// if selected item is not null or not inside the current items
        /// make default selection
        /// </summary>
        public void TryUpdateSelectedItem()
        {
            if (SelectedItem == null || !Items.Contains(SelectedItem))
            {
                SelectedItem = DefaultSelectedItem;
            }
            NotifyPropertyChanged(nameof(SelectedItem));
        }

        private void CollectInDatabase()
        {
            // get all counter
            Counters = Manager.DBSaver?.GetAllWithChildrenRecursivelyAsync<CountedShoot>();
        }

        private ReadOnlyCollection<ShootInList> CollectItems()
        {
            var items = Counters?.Where(i => // filter by status
            {
                bool shownIfFinish = ShownFinish && i.IsFinished;
                bool shownIfNotFinish = ShownNotFinish && !i.IsFinished;

                return shownIfFinish || shownIfNotFinish;
            })
                .OrderBy(c => c.LastChangeDate).Reverse() // order by date
                .Select(c => new ShootInList(c)) // make view models
                .ToList(); // make list

            return items != null
                        ? new ReadOnlyCollection<ShootInList>(items)
                        : new ReadOnlyCollection<ShootInList>(new List<ShootInList>());
        }

        private ReadOnlyCollection<ListViewGroup<ShootInList>> GroupItems()
        {
            var grouped = Items.GroupBy(i => i.GroupName) // group by name
                                .Select(g => new ListViewGroup<ShootInList>(g) // create group model
                                { Name = g.First().GroupName }) // add name
                                .ToList();

            return new ReadOnlyCollection<ListViewGroup<ShootInList>>(grouped);
        }

        private void OpenCurrentShoot()
        {
            // if no item is selected => do nothing
            if (SelectedItem == null)
                return;

            if (SelectedItem.IsFinished)
                OpenFinishCount();
            else
                OpenUnfinishCount();
        }

        private void OpenFinishCount()
        {
            var shoot = SelectedItem.Model ?? throw new NullReferenceException();
            var setting = ArrowSettingFactory.Create(shoot.TargetStyle);

            var page = ResultPageFactory.Create(shoot);
            MessagingCenterHelper.PopToRootAndPushPage(this, page);
        }

        private void OpenUnfinishCount()
        {
            var shoot = SelectedItem.Model ?? throw new NullReferenceException();

            Manager.CurrentShoot = shoot;
            var page = CounterPageFactory.CreateTabbedCounter(shoot);
            MessagingCenterHelper.PopToRootAndPushPage(this, page);
        }

        private void RefreshItems()
        {
            IsRefreshing = true;

            CollectInDatabase();
            UpdateItemsAsync();

            IsRefreshing = false;
        }

        private void UpdateItemsAsync()
        {
            Task.Run(() =>
            {
                Items = CollectItems();
                GroupedItems = GroupItems();
                TryUpdateSelectedItem();
            });
        }
    }
}
