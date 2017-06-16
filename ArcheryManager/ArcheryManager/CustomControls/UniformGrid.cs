﻿using Xamarin.Forms;
using System.Linq;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace ArcheryManager.CustomControls
{
    public abstract class UniformGrid<T> : ItemsGrid<T>
    {
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
            this.Items.CollectionChanged += Items_CollectionChanged;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(HeightCell))
            {
                foreach (var row in this.RowDefinitions)
                {
                    row.Height = new GridLength(HeightCell);
                }
            }
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
                resetDimension();
        }

        private void UniformGrid_ItemRemoved(BindableObject obj)
        {
            resetDimension();

            foreach (var i in Children)
            {
                ApplyPosition(i);
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
            ApplyPosition(obj);
        }

        private void ApplyPosition(BindableObject obj)
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
                int completRow;
                if (Children.Count - 1 % this.ColumnDefinitions.Count == 0)
                    completRow = this.RowDefinitions.Count;
                else
                    completRow = this.RowDefinitions.Count - 1;

                var currentColumn = Children.Count - 1 - (completRow * this.ColumnDefinitions.Count);
                var needNewRow = currentColumn >= this.ColumnDefinitions.Count;
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
