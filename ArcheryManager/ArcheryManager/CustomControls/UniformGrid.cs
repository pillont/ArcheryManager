using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public abstract class UniformGrid<T> : ItemsGrid<T>
    {
        public static readonly BindableProperty MaxWidthProperty =
                              BindableProperty.Create(nameof(MaxWidth), typeof(double?), typeof(UniformGrid<T>), null);

        public double? MaxWidth
        {
            get { return (double?)GetValue(MaxWidthProperty); }
            set { SetValue(MaxWidthProperty, value); }
        }

        public UniformGrid()
        {
            this.ItemAdded += UniformGrid_ItemAdded;
            this.ItemRemoved += UniformGrid_ItemRemoved;
        }

        private void UniformGrid_ItemRemoved(BindableObject obj)
        {
            this.ColumnDefinitions.Clear();

            foreach (var i in Children)
            {
                SetItemInNewColumn(i);
            }
        }

        private void UniformGrid_ItemAdded(BindableObject obj)
        {
            SetItemInNewColumn(obj);
        }

        private void SetItemInNewColumn(BindableObject item)
        {
            AddColumn();
            Grid.SetColumn(item, this.ColumnDefinitions.Count - 1);
        }

        private void AddRow()
        {
            this.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
        }

        private void AddColumn()
        {
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        }
    }
}
