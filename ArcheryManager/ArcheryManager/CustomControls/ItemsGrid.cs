using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public abstract class ItemsGrid<T> : Grid
    {
        public event Action<View> ItemAdded;

        public event Action<View> ItemRemoved;

        public static readonly BindableProperty ItemsProperty =
              BindableProperty.Create(nameof(Items), typeof(ObservableCollection<T>), typeof(ItemsGrid<T>), null);

        /// <summary>
        /// item to show in the grid
        /// </summary>
        public ObservableCollection<T> Items
        {
            get
            {
                return (ObservableCollection<T>)GetValue(ItemsProperty);
            }
            set
            {
                if (Items != null)
                {
                    Items.CollectionChanged -= Items_CollectionChanged;
                }

                SetValue(ItemsProperty, value);
                value.CollectionChanged += Items_CollectionChanged;
            }
        }

        public ItemsGrid()
        {
            Items = new ObservableCollection<T>();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Items))
            {
                // set first add to apply event on the item in the new list
                Items_CollectionChanged(Items, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Items));
            }
        }

        /// <summary>
        /// function to create the container of the item
        /// </summary>
        /// <returns></returns>
        protected abstract View CreateItemContainer(T data);

        /// <summary>
        /// event when the collection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                var items = new List<View>(Children);
                this.Children.Clear();
                foreach (var i in items)
                {
                    ItemRemoved?.Invoke(i);
                }
            }
            else
            {
                if (e.NewItems != null)
                {
                    foreach (T item in e.NewItems)
                    {
                        var container = CreateItemContainer(item);
                        container.BindingContext = item;
                        this.Children.Add(container);
                        ItemAdded?.Invoke(container);
                    }
                }
                if (e.OldItems != null)
                {
                    var i = e.OldStartingIndex;
                    foreach (var item in e.OldItems)
                    {
                        View container = FindContainer(i++);
                        this.Children.Remove(container);
                        ItemRemoved?.Invoke(container);
                    }
                }
            }
        }

        /// <summary>
        /// function to find the container of the object
        /// </summary>
        /// <param name="item">objec to find the container</param>
        public View FindContainer(object item)
        {
            return this.Children.Where(ctn => ctn.BindingContext == item).First();
        }

        public View FindContainer(int i)
        {
            return this.Children[i];
        }
    }
}
