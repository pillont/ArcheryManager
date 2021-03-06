﻿using ArcheryManager.Helpers;
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
        /// items to show in the grid
        /// </summary>
        public ObservableCollection<T> Items
        {
            get { return (ObservableCollection<T>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public ItemsGrid()
        {
            Items = new ObservableCollection<T>();
        }

        #region container of the items

        /// <summary>
        /// function to find the container of the object
        /// </summary>
        /// <param name="item">objec to find the container</param>
        public View FindContainer(object item)
        {
            return Children.Where(ctn => ctn.BindingContext == item).FirstOrDefault();
        }

        public View FindContainer(int i)
        {
            return this.Children[i];
        }

        /// <summary>
        /// function to create the container of the items
        /// </summary>
        protected abstract View CreateItemContainer(T data);

        #endregion container of the items

        //TODO set behavior

        #region Items changing

        /// <summary>
        /// call ItemCollectionChanged when list of Items change
        /// </summary>
        /// <param name="propertyName"></param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Items))
            {
                if (Items != null)
                {
                    if (Items == null)
                    {
                        throw new NullReferenceException();
                    }
                    Items.CollectionChanged += Items_CollectionChanged;
                    Items_CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    Items_CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Items));
                }
            }
        }

        protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanging(propertyName);

            if (propertyName == nameof(Items)
            && Items != null)
            {
                Items.CollectionChanged -= Items_CollectionChanged;
            }
        }

        /// <summary>
        /// event when the collection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //reset
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
                //item added
                if (e.NewItems != null)
                {
                    foreach (T item in e.NewItems)
                    {
                        var container = CreateItemContainer(item);
                        if (container != null)
                        {
                            container.BindingContext = item;
                            this.Children.Add(container);
                            ItemAdded?.Invoke(container);
                        }
                    }
                }
                // items removed
                if (e.OldItems != null)
                {
                    int i = e.OldStartingIndex;
                    foreach (var item in e.OldItems)
                    {
                        var container = FindContainer(i++);
                        Children.Remove(container);
                        ItemRemoved?.Invoke(container);
                    }
                }
            }
        }

        #endregion Items changing
    }
}
