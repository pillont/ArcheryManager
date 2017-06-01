using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public abstract class ItemsGrid<T> : Grid
    {
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
                SetValue(ItemsProperty, value);
                value.CollectionChanged += Items_CollectionChanged;
            }
        }

        public ItemsGrid()
        {
            Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// function to create the container of the item
        /// </summary>
        /// <returns></returns>
        protected abstract View CreateItemContainer();

        /// <summary>
        /// event when the collection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    View container = CreateItemContainer();
                    container.BindingContext = item;
                    this.Children.Add(container);
                }
            }
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    View container = FindContainer(item);
                    this.Children.Remove(container);
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
    }
}
