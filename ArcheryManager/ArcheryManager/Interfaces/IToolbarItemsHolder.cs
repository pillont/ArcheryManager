using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IToolbarItemsHolder
    {
        IList<ToolbarItem> ToolbarItems { get; }
    }
}
