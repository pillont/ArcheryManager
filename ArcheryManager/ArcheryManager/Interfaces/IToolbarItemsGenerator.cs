using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IToolbarItemsGenerator
    {
        IEnumerable<ToolbarItem> ToolbarItems { get; }
    }
}
