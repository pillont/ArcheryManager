using ArcheryManager.CustomControls;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using Xamarin.Forms;
using System.Collections.Generic;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System.Linq;

namespace ArcheryManager.Interactions.Behaviors
{
    public class SelectableArrowInListBehavior : CustomBehavior<ArrowUniformGrid>
    {
        private IEnumerable<Arrow> ArrowsSelected
        {
            get
            {
                return AssociatedObject.Items.Where(a => a.IsSelected);
            }
        }

        private readonly IList<ToolbarItem> toolbarItems;
        private readonly List<ToolbarItem> DefaultToolbarItems;
        private readonly IGeneralCounterSetting GeneralCountSetting;

        public SelectableArrowInListBehavior(IList<ToolbarItem> toolbarItems, IGeneralCounterSetting generalCountSetting)
        {
            GeneralCountSetting = generalCountSetting;
            this.toolbarItems = toolbarItems;
            DefaultToolbarItems = new List<ToolbarItem>(toolbarItems);
        }

        protected override void OnAttachedTo(ArrowUniformGrid list)
        {
            base.OnAttachedTo(list);

            AssociatedObject.ItemAdded += AssociatedObject_ItemAdded;
        }

        private bool ContainsInAssociatedObject(View a)
        {
            return AssociatedObject.Items.Contains(a.BindingContext as Arrow);
        }

        #region tap remove

        private void RemoveSelection()
        {
            //NOTE : toList to allow removed during browse by foreach
            var toRemove = ArrowsSelected.ToList();
            foreach (var a in toRemove)
            {
                AssociatedObject.Items.Remove(a);
            }
            UpdateToolBarItems();

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
            foreach (var arrow in AssociatedObject.Items)
            {
                arrow.IsSelected = false;
            }
            UpdateToolBarItems();
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

            var arrow = container.BindingContext as Arrow;
            arrow.IsSelected = !arrow.IsSelected;

            UpdateToolBarItems();
        }

        #endregion gesture to item added in list

        #region toolbar items

        public void UpdateToolBarItems()
        {
            // have selected element
            if (ArrowsSelected.Count() != 0)
            {
                ChangeButtonsFor(GetSelectionTitleButtons());
            }
            // have not selected element
            else
            {
                ChangeButtonsFor(DefaultToolbarItems);
            }
        }

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
