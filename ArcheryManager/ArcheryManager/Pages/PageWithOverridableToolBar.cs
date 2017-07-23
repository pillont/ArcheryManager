using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Mockables
{
    public class PageWithOverridableToolBar : Page
    {
        public new virtual IList<ToolbarItem> ToolbarItems { get; set; }
    }
}
