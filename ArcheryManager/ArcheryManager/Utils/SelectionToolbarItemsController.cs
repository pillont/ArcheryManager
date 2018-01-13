using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    /// <summary>
    /// show selection toolbar items
    /// save current toolbarItems
    /// update the saved list when messaging center is send
    /// </summary>
    internal class SelectionToolbarItemsController
    {
        private readonly ScoreCounter Counter;

        private readonly List<ToolbarItem> DefaultToolbarItems = new List<ToolbarItem>();

        /// <summary>
        /// to generate the toolbar items
        /// </summary>
        private readonly IToolbarItemsGenerator ToolBarGenerator;

        private bool SelectionToolbarItemIsShown;

        public SelectionToolbarItemsController(ScoreCounter counter, IToolbarItemsGenerator generator)
        {
            Counter = counter;
            ToolBarGenerator = generator;
        }

        internal void UpdateToolBarItems()
        {
            bool haveSelectedElement = Counter.ArrowsSelected.Count() != 0;

            if (haveSelectedElement)
            {
                if (!SelectionToolbarItemIsShown)
                {
                    ShowSelectionButtonsInToolbar();
                    SelectionToolbarItemIsShown = true;
                }
            }
            else
            {
                ShowDefaultToolbarItems();
                SelectionToolbarItemIsShown = false;
                DefaultToolbarItems.Clear();
            }
        }

        private void AddSelectionToolbaritems()
        {
            foreach (var item in ToolBarGenerator.ToolbarItems)
            {
                var arg = new ToolbarItemsArg()
                {
                    ToolbarItem = item,
                    PageType = typeof(ICounterPage)
                };

                MessagingCenterHelper.AddToolbarItem(this, arg);
            }
        }

        private void ApplyToolbarItemsEvent()
        {
            MessagingCenterHelper.Instance.AddedToolbarItem += Instance_AddedToolbarItem;
            MessagingCenterHelper.Instance.RemovedToolbarItem += Instance_RemovedToolbarItem;
            MessagingCenterHelper.Instance.ClearedToolbarItem += Instance_ClearedToolbarItem;
        }

        private void Instance_AddedToolbarItem(object sender, ToolbarItemsArg item)
        {
            RemoveToolbarItemsEvent();
            ResetSelectionToolbarItems(new ClearArg<ToolbarItem>() { PageType = typeof(ICounterPage) });

            DefaultToolbarItems.Add(item.ToolbarItem);

            ApplyToolbarItemsEvent();
        }

        private void Instance_ClearedToolbarItem(object sender, ClearArg<ToolbarItem> e)
        {
            RemoveToolbarItemsEvent();
            ResetSelectionToolbarItems(new ClearArg<ToolbarItem>() { PageType = typeof(ICounterPage) });

            DefaultToolbarItems.Clear();

            ApplyToolbarItemsEvent();
            MessagingCenterHelper.Instance.ClearedToolbarItem -= Instance_ClearedToolbarItem;
        }

        private void Instance_RemovedToolbarItem(object sender, ToolbarItemsArg item)
        {
            RemoveToolbarItemsEvent();
            ResetSelectionToolbarItems(new ClearArg<ToolbarItem>() { PageType = typeof(ICounterPage) });

            var toolbarItem = item.ToolbarItem;
            if (toolbarItem != null
            && DefaultToolbarItems.Contains(toolbarItem))
            {
                DefaultToolbarItems.Remove(toolbarItem);
            }

            ApplyToolbarItemsEvent();
        }

        private void RemoveToolbarItemsEvent()
        {
            MessagingCenterHelper.Instance.AddedToolbarItem -= Instance_AddedToolbarItem; ;
            MessagingCenterHelper.Instance.RemovedToolbarItem -= Instance_RemovedToolbarItem;
            MessagingCenterHelper.Instance.ClearedToolbarItem -= Instance_ClearedToolbarItem;
        }

        private void ResetSelectionToolbarItems(ClearArg<ToolbarItem> arg)
        {
            MessagingCenterHelper.ClearToolbarItem(this, arg);
            AddSelectionToolbaritems();
        }

        private void ShowDefaultToolbarItems()
        {
            RemoveToolbarItemsEvent();

            MessagingCenterHelper.ClearToolbarItem(this, new ClearArg<ToolbarItem>() { PageType = typeof(ICounterPage) });

            foreach (var t in DefaultToolbarItems)
            {
                var arg = new ToolbarItemsArg()
                {
                    ToolbarItem = t,
                    PageType = typeof(ICounterPage)
                };

                MessagingCenterHelper.AddToolbarItem(this, arg);
            }
        }

        private void ShowSelectionButtonsInToolbar()
        {
            var arg = new ClearArg<ToolbarItem>() { PageType = typeof(ICounterPage) };

            EventHandler<IEnumerable<ToolbarItem>> e = null;
            e = (s, l) =>
            {
                DefaultToolbarItems.AddRange(l);
            };
            arg.Cleared += e;

            RemoveToolbarItemsEvent();
            ResetSelectionToolbarItems(arg);
            ApplyToolbarItemsEvent();
        }
    }
}
