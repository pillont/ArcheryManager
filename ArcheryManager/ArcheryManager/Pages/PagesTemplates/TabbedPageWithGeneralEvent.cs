using System;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class TabbedPageWithGeneralEvent : Xamarin.Forms.TabbedPage, IGeneralEventHolder
    {
        public event EventHandler<BackButtonPressedArg> BackButtonPressed;

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            var arg = new BackButtonPressedArg();
            BackButtonPressed?.Invoke(this, arg);
            return !arg.ValidPress; //NOTE : must have "!" to work : why microsoft...
        }
    }
}
