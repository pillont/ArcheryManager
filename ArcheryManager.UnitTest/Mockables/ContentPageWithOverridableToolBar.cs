using ArcheryManager.Interfaces;
using ArcheryManager.Pages.PagesTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Mockables
{
    public class ContentPageWithOverridableToolBar : ContentPageWithGeneralEvent, IToolbarItemsHolder
    {
        public virtual new IList<ToolbarItem> ToolbarItems
        {
            get
            {
                return base.ToolbarItems;
            }
        }
    }
}
