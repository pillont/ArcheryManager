using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    /// <summary>
    /// <seealso cref="Page.DisplayAlert(string, string, string, string)"/>
    /// </summary>
    public class AlertArg
    {
        public event EventHandler<bool> ResultChange;

        public string Accept { get; set; }
        public string Cancel { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public void ResultChanged(bool r)
        {
            ResultChange?.Invoke(this, r);
        }
    }

    public class BackMessageBehavior<T> : CustomBehavior<T> where T : Page, IGeneralEventHolder
    {
        public event EventHandler PoppedAccept;

        private readonly AlertArg AlertArg;

        /// <summary>
        /// behavior to display alert when the navigation page pop the associated page
        /// </summary>
        public BackMessageBehavior(AlertArg alertArg)
        {
            AlertArg = alertArg;
        }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            MessagingCenterHelper.Instance.PoppingPageEvent += NavigationPage_Popped;
        }

        private void DisplayAlert()
        {
            MessagingCenterHelper.SendToast(this, AlertArg);
        }

        private void NavigationPage_Popped(object sender, Page page)
        {
            if (page == AssociatedObject)
            {
                DisplayAlert();

                EventHandler<bool> ee = null;
                ee = (s, answer) =>
                {
                    AlertArg.ResultChange -= ee;

                    //return to the target
                    if (!answer)
                    {
                        MessagingCenterHelper.PushInNavigationPage(this, page);
                    }
                    else
                    {
                        MessagingCenterHelper.Instance.PoppingPageEvent -= NavigationPage_Popped;
                        PoppedAccept?.Invoke(AssociatedObject, null);
                    }
                };

                AlertArg.ResultChange += ee;
            }
        }
    }
}
