using ArcheryManager.Entities;
using ArcheryManager.Interfaces;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.CustomControls
{
    public class ShootGrid : ItemsGrid<Flight>
    {
        protected override View CreateItemContainer(Flight data)
        {
            var binding = new Binding() { Source = data, Path = nameof(Flight.Arrows) };
            var setting = (BindingContext as ShootGridViewModel).Setting;

            var scoreList = new ScoreList();
            scoreList.BindingContext = new ScoreListViewModel(binding, setting);

            return scoreList;
        }
    }

    public class ShootGridViewModel : ViewModel
    {
        public IArrowSetting Setting { get; }

        public ShootGridViewModel(IArrowSetting setting)
        {
            Setting = setting;
        }
    }
}
