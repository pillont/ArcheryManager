using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.Pages
{
    public abstract class ContentPageWithOverridableToolBar : ContentPage
    {
        public new virtual IList<ToolbarItem> ToolbarItems
        {
            get
            {
                return base.ToolbarItems;
            }
        }
    }
}
