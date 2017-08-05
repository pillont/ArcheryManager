using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryManager.Pages.PagesTemplates
{
    public interface IGeneralEventHolder
    {
        event EventHandler<BackButtonPressedArg> BackButtonPressed;
    }
}
