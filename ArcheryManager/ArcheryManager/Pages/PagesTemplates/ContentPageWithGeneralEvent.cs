using ArcheryManager.Interfaces;
using System;
using XLabs;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class ContentPageWithGeneralEvent : ContentPageWithRotationEvent, IGeneralEventHolder, IViewWithGeneralEvent
    {
        public event EventHandler<BackButtonPressedArg> BackButtonPressed;

        public event EventHandler PagePushed;

        public void OnPagePushed(object sender, EventArgs p)
        {
            PagePushed?.Invoke(sender, null);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            var arg = new BackButtonPressedArg();
            BackButtonPressed?.Invoke(this, arg);
            return !arg.ValidPress; //NOTE : must have "!" to work : why microsoft...
        }
    }
}
