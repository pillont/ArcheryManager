using ArcheryManager.Interfaces;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class NavigationPageWithInterface : NavigationPage, IPushablePage
    {
        public event EventHandler<NavigationEventArgs> PushedPage
        {
            add { this.Pushed += value; }
            remove { this.Pushed -= value; }
        }

        public event EventHandler<ElementEventArgs> RemovedPage
        {
            add { this.ChildRemoved += value; }
            remove { this.ChildRemoved -= value; }
        }

        public NavigationPageWithInterface(Page page)
            : base(page)
        {
        }
    }
}
