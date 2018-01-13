using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;
using System.Linq;
using ArcheryManager.Interfaces;
using XLabs;

namespace ArcheryManager.Interactions.Behaviors
{
    public class ToolBarItemsBehavior<T> : CustomBehavior<T> where T : BindableObject, IPushablePage
    {
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.PushedPage += AssociatedObject_PushedPage;
        }

        private static bool IsAssociatedPage(Type pageType, Page page)
        {
            return page.GetType() == pageType;
        }

        private void AddEventToManageToolbarItems(Page page)
        {
            EventHandler<ToolbarItemsArg> remove = (s, a) => Instance_RemovedToolbarItem(s, a, page);
            EventHandler<ToolbarItemsArg> add = (s, a) => Instance_AddedToolbarItem(s, a, page);
            EventHandler<ClearArg<ToolbarItem>> clear = (s, a) => Instance_ClearedToolbarItem(s, a, page);

            MessagingCenterHelper.Instance.RemovedToolbarItem += remove;
            MessagingCenterHelper.Instance.AddedToolbarItem += add;
            MessagingCenterHelper.Instance.ClearedToolbarItem += clear;

            AssociatedObject.RemovedPage += (s, a) =>
            {
                if (a.Element == page)
                {
                    MessagingCenterHelper.Instance.RemovedToolbarItem -= remove;
                    MessagingCenterHelper.Instance.AddedToolbarItem -= add;
                    MessagingCenterHelper.Instance.ClearedToolbarItem -= clear;
                }
            };
        }

        private void AssociatedObject_PushedPage(object sender, NavigationEventArgs page)
        {
            AddEventToManageToolbarItems(page.Page);
        }

        private void Instance_AddedToolbarItem(object sender, ToolbarItemsArg e, Page page)
        {
            if (IsAssociatedPage(e.PageType, page))
            {
                page.ToolbarItems.Add(e.ToolbarItem);
            }
        }

        private void Instance_ClearedToolbarItem(object sender, ClearArg<ToolbarItem> e, Page page)
        {
            if (IsAssociatedPage(e.PageType, page))
            {
                var toolbars = page.ToolbarItems.ToList();
                page.ToolbarItems.Clear();
                e.OnCleared(this, toolbars);
            }
        }

        private void Instance_RemovedToolbarItem(object sender, ToolbarItemsArg e, Page page)
        {
            if (IsAssociatedPage(e.PageType, page))
            {
                page.ToolbarItems.Remove(e.ToolbarItem);
            }
        }
    }
}
