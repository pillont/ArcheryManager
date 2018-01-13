using System;
using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IPushablePage
    {
        event EventHandler<NavigationEventArgs> PushedPage;

        event EventHandler<ElementEventArgs> RemovedPage;
    }
}
