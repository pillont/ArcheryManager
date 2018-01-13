using ArcheryManager.Interfaces;
using System;
using Xamarin.Forms;
using System.Linq;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class TabbedPageWithGeneralEvent : TabbedPage, IGeneralEventHolder, IViewWithGeneralEvent
    {
        public event EventHandler<BackButtonPressedArg> BackButtonPressed;

        public event EventHandler PagePushed;

        public void OnPagePushed(object sender, EventArgs p)
        {
            PagePushed?.Invoke(sender, p);

            TransfertPushEvent();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            var arg = new BackButtonPressedArg();
            BackButtonPressed?.Invoke(this, arg);
            return !arg.ValidPress; //NOTE : must have "!" to work : why microsoft...
        }

        /// <summary>
        /// call the pushed event of the children GeneralEventHolder
        /// </summary>
        private void TransfertPushEvent()
        {
            foreach (var c in Children.OfType<IViewWithGeneralEvent>())
            {
                c.OnPagePushed(this, null);
            }
        }
    }
}
