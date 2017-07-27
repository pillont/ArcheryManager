using ArcheryManager.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Mockables
{
    public class ContentPageWithOverridableToolBar : ContentPage, IToolbarItemsHolder
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
