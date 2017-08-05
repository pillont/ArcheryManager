using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class TabbedPageWithGeneralEvent : TabbedPage, IGeneralEventHolder
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
