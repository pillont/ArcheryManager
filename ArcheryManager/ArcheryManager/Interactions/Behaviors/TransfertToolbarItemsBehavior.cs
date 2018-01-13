using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    /// <summary>
    /// behavior allow to a tabbed page to apply page pushed event on his children
    /// during apply event on children the toolbaritems generated ar collected to apply on the child page associated
    /// </summary>
    public class TransfertToolbarItemsBehavior : CustomBehavior<TabbedPageWithGeneralEvent>
    {
        protected override void OnAttachedTo(TabbedPageWithGeneralEvent bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.PagePushed += Associated_PagePushed;
            MessagingCenterHelper.Instance.PoppingPageEvent += Associated_PoppingPageEvent;
        }

        /// <summary>
        /// during push event of the associated item
        /// select all the children of type ContentPageWithGeneralEvent
        /// apply push event and transfert toolbarItems on the child page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void Associated_PagePushed(object sender, EventArgs arg)
        {
            AttachEvent();
        }

        /// <summary>
        /// remove event when the associated page isn't in navigation list
        /// </summary>
        private void Associated_PoppingPageEvent(object sender, Page e)
        {
            if (e == AssociatedObject)
            {
                DetachEvent();
            }
        }

        private void AttachEvent()
        {
            MessagingCenterHelper.Instance.AddedToolbarItem += Instance_AddedToolbarItem;
            MessagingCenterHelper.Instance.RemovedToolbarItem += Instance_RemovedToolbarItem;
            MessagingCenterHelper.Instance.ClearedToolbarItem += Instance_ClearedToolbarItem;
        }

        private void DetachEvent()
        {
            MessagingCenterHelper.Instance.AddedToolbarItem -= Instance_AddedToolbarItem;
            MessagingCenterHelper.Instance.RemovedToolbarItem -= Instance_RemovedToolbarItem;
            MessagingCenterHelper.Instance.ClearedToolbarItem -= Instance_ClearedToolbarItem;
        }

        private Page GetWantedToolbarItem(Type type)
        {
            return AssociatedObject.Children.Where(c =>
            {
                var wantedType = type.GetTypeInfo();
                var ChildType = c.GetType().GetTypeInfo();
                return wantedType.IsAssignableFrom(ChildType);
            })
                .FirstOrDefault();
        }

        private void Instance_AddedToolbarItem(object sender, ToolbarItemsArg e)
        {
            var wantedChild = GetWantedToolbarItem(e.PageType);
            if (wantedChild != null)
            {
                wantedChild.ToolbarItems.Add(e.ToolbarItem);
            }
        }

        private void Instance_ClearedToolbarItem(object sender, ClearArg<ToolbarItem> e)
        {
            var wantedChild = GetWantedToolbarItem(e.PageType);
            if (wantedChild != null)
            {
                var toolbarItems = wantedChild.ToolbarItems;
                e.OnCleared(this, toolbarItems.ToList());
                toolbarItems.Clear();
            }
        }

        private void Instance_RemovedToolbarItem(object sender, ToolbarItemsArg e)
        {
            var wantedChild = GetWantedToolbarItem(e.PageType);
            if (wantedChild != null)
            {
                wantedChild.ToolbarItems.Remove(e.ToolbarItem);
            }
        }
    }
}
