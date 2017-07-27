﻿using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;
using System.Collections.Generic;
using ArcheryManager.Resources;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Settings;

namespace ArcheryManager.Interactions.Behaviors
{
    public class SelectableArrowInListBehavior : CustomBehavior<ArrowUniformGrid>
    {
        private const int WidthOfSelectedBorder = 10;

        private ObservableCollection<View> selectedArrows;
        private readonly IList<ToolbarItem> toolbarItems;
        private readonly List<ToolbarItem> DefaultToolbarItems;
        private readonly IGeneralCounterSetting GeneralCountSetting;

        public event NotifyCollectionChangedEventHandler ItemsSelectedChange;

        public SelectableArrowInListBehavior(IList<ToolbarItem> toolbarItems, IGeneralCounterSetting generalCountSetting)
        {
            GeneralCountSetting = generalCountSetting;
            this.toolbarItems = toolbarItems;
            DefaultToolbarItems = new List<ToolbarItem>(toolbarItems);
            selectedArrows = new ObservableCollection<View>();
            selectedArrows.CollectionChanged += SelectedArrows_CollectionChanged;
        }

        protected override void OnAttachedTo(ArrowUniformGrid list)
        {
            base.OnAttachedTo(list);

            AssociatedObject.ItemAdded += AssociatedObject_ItemAdded;
            AssociatedObject.Items.CollectionChanged += Items_CollectionChanged;
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
            return AssociatedObject.Items.Contains(a.BindingContext as Arrow);
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

            // have selected element
            if (selectedArrows.Count != 0)
            {
                ChangeButtonsFor(GetSelectionTitleButtons());
            }
            // have not selected element
            else
            {
                ChangeButtonsFor(DefaultToolbarItems);
            }
        }

        #region tap remove

        private void RemoveSelection()
        {
            RemoveSelectedItems();
            selectedArrows.Clear();
        }

        private void RemoveSelectedItems()
        {
            foreach (var arrow in selectedArrows.ToList())
            {
                int index = AssociatedObject.Children.IndexOf(arrow);
                AssociatedObject.Items.RemoveAt(index);
            }
            GeneralCountSetting.ScoreResult.OnArrowsChanged();
        }

        #endregion tap remove

        #region tap unselect

        private void UnSelect()
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

        public void ArrowRecognizer_Tapped(object sender, System.EventArgs e)
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

        // TODO : view function !
        private void SelectArrow(View container)
        {
            var shape = ArrowUniformGridHelper.ShapeOfArrow(container);

            shape.BorderColor = CommonConstant.DefaultSelectedArrowColor;
            shape.BorderWidth = WidthOfSelectedBorder;
        }

        #endregion gesture to item added in list

        #region toolbar items

        private void ChangeButtonsFor(List<ToolbarItem> list)
        {
            toolbarItems.Clear();

            foreach (var item in list)
            {
                toolbarItems.Add(item);
            }
        }

        private void ShowSelectionButtonsInTitle()
        {
            toolbarItems.Clear();

            foreach (var item in GetSelectionTitleButtons())
            {
                toolbarItems.Add(item);
            }
        }

        private List<ToolbarItem> GetSelectionTitleButtons()
        {
            return new List<ToolbarItem>()
            {
                new ToolbarItem()
                {
                    Text = AppResources.UnSelect,
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(UnSelect)
                },
                new ToolbarItem()
                {
                    Text = AppResources.RemoveSelect,
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(RemoveSelection)
                }
            };
        }

        #endregion toolbar items
    }
}
