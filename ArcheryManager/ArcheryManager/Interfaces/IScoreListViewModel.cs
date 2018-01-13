using System.Collections.ObjectModel;
using ArcheryManager.Entities;
using ArcheryManager.Interfaces;
using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IScoreListViewModel
    {
        Binding ArrowsBinding { get; }
        IArrowSetting ArrowSetting { get; }
    }
}
