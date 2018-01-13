using ArcheryManager.Helpers;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    /// <summary>
    /// behavior to remove page of navigation page when the page wanted is not in the top of the list
    /// </summary>
    public class RemoveWhenQuitBehavior : CustomBehavior<Page>
    {
        protected override void OnAttachedTo(Page bindable)
        {
            base.OnAttachedTo(bindable);

            // events to remove this page of the navigation when quit
            MessagingCenterHelper.Instance.PushingPageEvent += MessagingCenter_Pushing;
            MessagingCenterHelper.Instance.PoppingPageEvent += MessageCenterHelper_Popped;
        }

        /// <summary>
        /// remove event to remove of navigation if this page is popped
        /// </summary>
        private void MessageCenterHelper_Popped(object sender, Page page)
        {
            if (page == AssociatedObject)
            {
                MessagingCenterHelper.Instance.PushingPageEvent -= MessagingCenter_Pushing;
                MessagingCenterHelper.Instance.PoppingPageEvent -= MessageCenterHelper_Popped;
            }
        }

        /// <summary>
        /// remove this page of the navigation if other is pushed
        /// remove event to remove of navigation
        /// </summary>
        private void MessagingCenter_Pushing(object sender, PushingEventArg arg)
        {
            if (arg.Page != AssociatedObject)
            {
                MessagingCenterHelper.Instance.PushingPageEvent -= MessagingCenter_Pushing;
                MessagingCenterHelper.Instance.PoppingPageEvent -= MessageCenterHelper_Popped;

                MessagingCenterHelper.PopToRootAndPushPage(this, arg.Page);

                arg.IsPush = false;
            }
        }
    }
}
