using System;

namespace ArcheryManager.Interfaces
{
    public interface IViewWithGeneralEvent
    {
        event EventHandler PagePushed;

        void OnPagePushed(object sender, EventArgs p);
    }
}
