using ArcheryManager.Interfaces;
using ArcheryManager.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ArcheryManager.CustomControls;

namespace ArcheryManager.Utils
{
    internal class SelectionToolbarItemsGenerator : IToolbarItemsGenerator
    {
        public event Action ButtonPressed;

        private readonly ArrowUniformGrid AssociatedObject;
        private readonly ScoreCounter Counter;

        public IEnumerable<ToolbarItem> ToolbarItems
        {
            get
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
        }

        public SelectionToolbarItemsGenerator(ScoreCounter counter, ArrowUniformGrid associatedObject)
        {
            Counter = counter;
            AssociatedObject = associatedObject;
        }

        private void RemoveSelection()
        {
            Counter.RemoveSelection();
            ButtonPressed?.Invoke();
        }

        private void UnSelect()
        {
            foreach (var arrow in AssociatedObject.Items)
            {
                arrow.IsSelected = false;
            }
            ButtonPressed?.Invoke();
        }
    }
}
