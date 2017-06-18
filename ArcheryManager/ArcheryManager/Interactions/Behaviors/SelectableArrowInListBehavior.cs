using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class SelectableArrowInListBehavior : CustomBehavior<ArrowUniformGrid>
    {
        private const int WidthOfSelectedBorder = 10;

        private ObservableCollection<View> selectedArrows;

        public event NotifyCollectionChangedEventHandler ItemsSelectedChange;

        public ReadOnlyCollection<View> SelectedArrow
        {
            get
            {
                return new ReadOnlyCollection<View>(selectedArrows);
            }
        }

        public SelectableArrowInListBehavior()
        {
            selectedArrows = new ObservableCollection<View>();
            selectedArrows.CollectionChanged += SelectedArrows_CollectionChanged;
        }

        protected override void OnAttachedTo(ArrowUniformGrid list)
        {
            base.OnAttachedTo(list);

            associatedObject.ItemAdded += AssociatedObject_ItemAdded;

            associatedObject.Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newValues = selectedArrows.
                            Where(a => !ContainsInAssociatedObject(a))
                                                                    .ToList();
            foreach (var v in newValues)
            {
                selectedArrows.Remove(v);
            }
        }

        private bool ContainsInAssociatedObject(View a)
        {
            return associatedObject.Items.Contains(a.BindingContext as Arrow);
        }

        /// <summary>
        /// event during the change on the items selected list
        /// enable/disable buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedArrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ItemsSelectedChange?.Invoke(sender, e);
        }

        #region tap remove

        //TODO : private function and add toolitem in ctor
        public void RemoveSelection()
        {
            RemoveSelectedItems();
            selectedArrows.Clear();
        }

        private void RemoveSelectedItems()
        {
            foreach (var arrow in selectedArrows.ToList())
            {
                var context = arrow.BindingContext as Arrow;
                associatedObject.Items.Remove(context);
            }
        }

        #endregion tap remove

        #region tap unselect

        public void UnSelect()
        {
            UnSelectSelection();
        }

        private void UnSelectSelection()
        {
            foreach (var arrow in selectedArrows)
            {
                UnSelectArrow(arrow);
            }
            selectedArrows.Clear();
        }

        private void UnSelectArrow(View container)
        {
            var shape = ArrowUniformGridHelper.ShapeOfArrow(container);
            shape.BorderColor = ArrowUniformGrid.DefaultBorderColor;
            shape.BorderWidth = ArrowUniformGrid.DefaultBorderWidth;
        }

        #endregion tap unselect

        #region gesture to item added in list

        private void AssociatedObject_ItemAdded(View obj)
        {
            GestureHelper.AddTapGestureOn(obj, ArrowRecognizer_Tapped);
        }

        private void ArrowRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var container = sender as View;

            if (selectedArrows.Contains(container))
            {
                UnSelectArrow(container);
                selectedArrows.Remove(container);
            }
            else
            {
                SelectArrow(container);
                selectedArrows.Add(container);
            }
        }

        private void SelectArrow(View container)
        {
            var shape = ArrowUniformGridHelper.ShapeOfArrow(container);

            shape.BorderColor = CommonConstant.DefaultSelectedArrowColor;
            shape.BorderWidth = WidthOfSelectedBorder;
        }

        #endregion gesture to item added in list
    }
}
