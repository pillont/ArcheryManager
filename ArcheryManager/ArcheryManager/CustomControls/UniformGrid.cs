using Xamarin.Forms;
using System.Linq;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace ArcheryManager.CustomControls
{
    public abstract class UniformGrid<T> : ItemsGrid<T>
    {
        public static readonly BindableProperty OrderSelectorProperty =
                      BindableProperty.Create(nameof(OrderSelector), typeof(Func<T, object>), typeof(UniformGrid<T>), null);

        public Func<T, object> OrderSelector
        {
            get { return (Func<T, object>)GetValue(OrderSelectorProperty); }
            set { SetValue(OrderSelectorProperty, value); }
        }

        public static readonly BindableProperty HeightCellProperty =
                      BindableProperty.Create(nameof(HeightCell), typeof(double), typeof(UniformGrid<T>), 50d);

        public double HeightCell
        {
            get { return (double)GetValue(HeightCellProperty); }
            set { SetValue(HeightCellProperty, value); }
        }

        public static readonly BindableProperty CountByRowProperty =
                      BindableProperty.Create(nameof(CountByRow), typeof(int?), typeof(UniformGrid<T>), null);

        public int? CountByRow
        {
            get { return (int?)GetValue(CountByRowProperty); }
            set { SetValue(CountByRowProperty, value); }
        }

        public UniformGrid()
        {
            resetDimension();
            this.ItemAdded += UniformGrid_ItemAdded;
            this.ItemRemoved += UniformGrid_ItemRemoved;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Items))
            {
                this.Items.CollectionChanged += Items_CollectionChanged;
            }

            if (propertyName == nameof(HeightCell))
            {
                foreach (var row in this.RowDefinitions)
                {
                    row.Height = new GridLength(HeightCell);
                }
            }

            if (propertyName == nameof(OrderSelector))
            {
                ResetPosition();
            }
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                resetDimension();
            }
        }

        private void UniformGrid_ItemRemoved(BindableObject obj)
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            resetDimension();

            IEnumerable<T> ordered;
            if (OrderSelector != null)
            {
                ordered = Items.OrderBy(OrderSelector);
            }
            else
            {
                ordered = Items;
            }

            int indexChild = 0;
            foreach (var data in ordered)
            {
                var child = FindContainer(data);
                if (child != null)
                {
                    ApplyPosition(child, indexChild);
                    indexChild++;
                }
            }
        }

        private void resetDimension()
        {
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();
            AddRow();
        }

        private void UniformGrid_ItemAdded(BindableObject obj)
        {
            ResetPosition();
        }

        private void ApplyPosition(BindableObject obj, int childIndex)
        {
            bool onlyOneRow = this.RowDefinitions.Count <= 1;

            if (onlyOneRow)
            {
                SetItemInNewColumn(obj);

                var moreCountByRowWanted = this.ColumnDefinitions.Count > CountByRow;
                if (moreCountByRowWanted)
                {
                    var last = this.ColumnDefinitions.Last();
                    this.ColumnDefinitions.Remove(last);
                    AddRow();

                    Grid.SetRow(obj, this.RowDefinitions.Count - 1);
                    Grid.SetColumn(obj, 0);
                }
            }
            else
            {
                int completRow = this.RowDefinitions.Count - 1;
                var currentColumn = childIndex - (completRow * this.ColumnDefinitions.Count);

                bool needNewRow = childIndex % this.ColumnDefinitions.Count == 0;
                if (needNewRow)
                {
                    AddRow();
                    currentColumn = 0;
                }

                Grid.SetRow(obj, this.RowDefinitions.Count - 1);
                Grid.SetColumn(obj, currentColumn);
            }
        }

        private void SetItemInNewColumn(BindableObject item)
        {
            AddColumn();
            Grid.SetColumn(item, this.ColumnDefinitions.Count - 1);
        }

        private void AddRow()
        {
            this.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(HeightCell) });
        }

        private void AddColumn()
        {
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        }
    }
}
