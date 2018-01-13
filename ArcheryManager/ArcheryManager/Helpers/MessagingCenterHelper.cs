using ArcheryManager.Interactions.Behaviors;
using Xamarin.Forms;
using System;
using ArcheryManager.Utils;

namespace ArcheryManager.Helpers
{
    public class MessagingCenterHelper
    {
        public event EventHandler<ToolbarItemsArg> AddedToolbarItem;

        public event EventHandler BackPageEvent;

        public event EventHandler<ClearArg<ToolbarItem>> ClearedToolbarItem;

        public event EventHandler<Page> PoppingPageEvent;

        public event EventHandler<Page> PopToRootPageEvent;

        public event EventHandler<Page> PushedPageEvent;

        public event EventHandler<PushingEventArg> PushingPageEvent;

        public event EventHandler<Page> RemovedPageInNavigationEvent;

        public event EventHandler<ToolbarItemsArg> RemovedToolbarItem;

        public event EventHandler<AlertArg> SendToastEvent;

        public enum Message
        {
            BackPageMessage,
            PoppingPageMessage,
            PushedPageMessage,
            SendToastMessage,
            RemovePageInNavigation,
            AddToolbarItemMessage,
            RemoveToolbarItemMessage,
            ClearToolbarItemMessage,
            PushingPageMessage,
            PopToRootPageMessage,
        }

        private static MessagingCenterHelper _messagingCenterHelper;

        public static MessagingCenterHelper Instance
        {
            get
            {
                if (_messagingCenterHelper == null)
                {
                    _messagingCenterHelper = new MessagingCenterHelper();
                }
                return _messagingCenterHelper;
            }
        }

        private MessagingCenterHelper()
        {
            string message = Message.BackPageMessage.ToString();
            MessagingCenter.Subscribe<object>(this, message, BackPageTrigger);

            message = Message.PoppingPageMessage.ToString();
            MessagingCenter.Subscribe<object, Page>(this, message, PoppedPageTrigger);

            message = Message.PushingPageMessage.ToString();
            MessagingCenter.Subscribe<object, PushingEventArg>(this, message, PushingPageTrigger);

            message = Message.PushedPageMessage.ToString();
            MessagingCenter.Subscribe<object, Page>(this, message, PushedPageTrigger);

            message = Message.SendToastMessage.ToString();
            MessagingCenter.Subscribe<object, AlertArg>(this, message, SendToastTrigger);

            message = Message.RemovePageInNavigation.ToString();
            MessagingCenter.Subscribe<object, Page>(this, message, RemovePageInNavigationTrigger);

            message = Message.AddToolbarItemMessage.ToString();
            MessagingCenter.Subscribe<object, ToolbarItemsArg>(this, message, AddedToolbarItemTrigger);

            message = Message.RemoveToolbarItemMessage.ToString();
            MessagingCenter.Subscribe<object, ToolbarItemsArg>(this, message, RemovedToolbarItemTrigger);

            message = Message.ClearToolbarItemMessage.ToString();
            MessagingCenter.Subscribe<object, ClearArg<ToolbarItem>>(this, message, ClearToolbarItemsTrigger);

            message = Message.PopToRootPageMessage.ToString();
            MessagingCenter.Subscribe<object, Page>(this, message, PopToRootPageTrigger);
        }

        public static void AddToolbarItem<T>(T sender, ToolbarItemsArg toolbarItem) where T : class
        {
            string message = Message.AddToolbarItemMessage.ToString();
            MessagingCenter.Send<object, ToolbarItemsArg>(sender, message, toolbarItem);
        }

        public static void BackInNavigationPage<T>(T sender) where T : class
        {
            string message = Message.BackPageMessage.ToString();
            MessagingCenter.Send<object>(sender, message);
        }

        public static void ClearToolbarItem<T>(T sender, ClearArg<ToolbarItem> arg) where T : class
        {
            string message = Message.ClearToolbarItemMessage.ToString();
            MessagingCenter.Send<object, ClearArg<ToolbarItem>>(sender, message, arg);
        }

        public static void PoppedInNavigationPage<T>(T sender, Page page) where T : class
        {
            string message = Message.PoppingPageMessage.ToString();
            MessagingCenter.Send<object, Page>(sender, message, page);
        }

        public static void PopToRootAndPushPage(object sender, Page page)
        {
            string message = Message.PopToRootPageMessage.ToString();
            MessagingCenter.Send<object, Page>(sender, message, page);

            PushInNavigationPage(sender, page);
        }

        public static void PushInNavigationPage<T>(T sender, Page page) where T : class
        {
            string message = Message.PushingPageMessage.ToString();
            var pushingArg = new PushingEventArg() { Page = page };
            MessagingCenter.Send<object, PushingEventArg>(sender, message, pushingArg);

            if (pushingArg.IsPush) // push page if pushing is accepted
            {
                message = Message.PushedPageMessage.ToString();
                MessagingCenter.Send<object, Page>(sender, message, page);
            }
        }

        public static void RemovePageInNavigation<T>(T sender, Page page) where T : class
        {
            string message = Message.RemovePageInNavigation.ToString();
            MessagingCenter.Send<object, Page>(sender, message, page);
        }

        public static void RemoveToolbarItem<T>(T sender, ToolbarItemsArg toolbarItem) where T : class
        {
            string message = Message.RemoveToolbarItemMessage.ToString();
            MessagingCenter.Send<object, ToolbarItemsArg>(sender, message, toolbarItem);
        }

        public static void SendToast<T>(T sender, AlertArg arg) where T : class
        {
            string message = Message.SendToastMessage.ToString();
            MessagingCenter.Send<object, AlertArg>(sender, message, arg);
        }

        internal static void SendToast<T>(T sender, string title, string message, string cancel) where T : class
        {
            var arg = new AlertArg() { Title = title, Message = message, Cancel = cancel };
            SendToast(sender, arg);
        }

        private void AddedToolbarItemTrigger(object arg1, ToolbarItemsArg arg2)
        {
            AddedToolbarItem?.Invoke(arg1, arg2);
        }

        private void BackPageTrigger(object obj)
        {
            BackPageEvent?.Invoke(obj, null);
        }

        private void ClearToolbarItemsTrigger(object sender, ClearArg<ToolbarItem> arg)
        {
            ClearedToolbarItem?.Invoke(sender, arg);
        }

        private void PoppedPageTrigger(object c, Page p)
        {
            PoppingPageEvent?.Invoke(c, p);
        }

        private void PopToRootPageTrigger(object sender, Page page)
        {
            PopToRootPageEvent?.Invoke(sender, page);
        }

        private void PushedPageTrigger(object c, Page p)
        {
            PushedPageEvent?.Invoke(c, p);
        }

        private void PushingPageTrigger(object c, PushingEventArg p)
        {
            PushingPageEvent?.Invoke(c, p);
        }

        private void RemovedToolbarItemTrigger(object arg1, ToolbarItemsArg arg2)
        {
            RemovedToolbarItem?.Invoke(arg1, arg2);
        }

        private void RemovePageInNavigationTrigger(object sender, Page arg)
        {
            RemovedPageInNavigationEvent?.Invoke(sender, arg);
        }

        private void SendToastTrigger(object c, AlertArg arg)
        {
            SendToastEvent?.Invoke(c, arg);
        }
    }

    public class PushingEventArg
    {
        public bool IsPush { get; set; } = true;
        public Page Page { get; set; }
    }
}
