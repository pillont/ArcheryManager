using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class ContentPageWithGeneralEvent : ContentPageWithRotationEvent
    {
        public event EventHandler<BackButtonPressedArg> BackButtonPressed;

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            var arg = new BackButtonPressedArg();
            BackButtonPressed?.Invoke(this, arg); NOT WORK...
            return arg.ValidPress;
        }
    }

    public class BackButtonPressedArg
    {
        public bool ValidPress { get; set; }
    }
}
