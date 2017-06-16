using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace ArcheryManager.Behaviors
{
    public class SelectableArrowInListBehavior : CustomBehavior<ArrowUniformGrid>
    {
        public event NotifyCollectionChangedEventHandler ItemsSelectedChange;

        private const int WidthOfSelectedBorder = 10;
        private ObservableCollection<View> selectedArrows;
        private readonly View UnSelectViewToClick;
        private readonly View RemoveViewToClick;

        public SelectableArrowInListBehavior(View unSelectViewToClick, View removeViewToClick)
        {
            RemoveViewToClick = removeViewToClick;
            UnSelectViewToClick = unSelectViewToClick;
            selectedArrows = new ObservableCollection<View>();
            selectedArrows.CollectionChanged += SelectedArrows_CollectionChanged;
            DisableButtons();
        }

        protected override void OnAttachedTo(ArrowUniformGrid list)
        {
            base.OnAttachedTo(list);

            associatedObject.ItemAdded += AssociatedObject_ItemAdded;

            GestureHelper.AddTapGestureOn(UnSelectViewToClick, UnSelectViewToClick_Tapped);
            GestureHelper.AddTapGestureOn(RemoveViewToClick, RemoveViewToClick_Tapped);

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

            if (selectedArrows.Count > 0)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        #region tap remove

        private void RemoveViewToClick_Tapped(object sender, EventArgs e)
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

        private void UnSelectViewToClick_Tapped(object sender, EventArgs e)
        {
            UnSelectSelection();
        }

        private void DisableButtons()
        {
            UnSelectViewToClick.IsVisible = false;
            RemoveViewToClick.IsVisible = false;
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

        private void EnableButtons()
        {
            UnSelectViewToClick.IsVisible = true;
            RemoveViewToClick.IsVisible = true;
        }

        #endregion gesture to item added in list
    }
}
