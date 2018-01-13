using System;

namespace ArcheryManager.Pages.PagesTemplates
{
    public interface IGeneralEventHolder
    {
        event EventHandler<BackButtonPressedArg> BackButtonPressed;
    }
}
