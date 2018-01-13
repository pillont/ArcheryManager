using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.CustomControls
{
    public class ScoreList : ArrowUniformGrid
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ScoreListViewModel vm)
            {
                ArrowSetting = vm.ArrowSetting;
                SetBinding(ItemsProperty, vm.ArrowsBinding);
            }
        }
    }

    public class ScoreListCurrentArrowsViewModel : ScoreListViewModel
    {
        private readonly ScoreCounter Counter;
        private readonly CountedShoot Shoot;

        public ObservableCollection<Arrow> CurrentArrows => Shoot.CurrentArrows != null
                                                                ? new ObservableCollection<Arrow>(Shoot.CurrentArrows)
                                                                                : new ObservableCollection<Arrow>();

        public ScoreListCurrentArrowsViewModel(CounterManager manager)
        {
            Counter = manager.Counter;
            Shoot = manager.CurrentShoot;
            ArrowSetting = ArrowSettingFactory.Create(Shoot.TargetStyle);
            Counter.PropertyChanged += Counter_PropertyChanged;
            ArrowsBinding = new Binding() { Source = this, Path = nameof(CurrentArrows) };
        }

        private void Counter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Counter.CurrentArrows))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            }
        }
    }

    public class ScoreListViewModel : ViewModel, IScoreListViewModel
    {
        public Binding ArrowsBinding { get; protected set; }
        public IArrowSetting ArrowSetting { get; protected set; }

        public ScoreListViewModel(Binding arrowsB, IArrowSetting setting)
        {
            ArrowsBinding = arrowsB;
            ArrowSetting = setting;
        }

        protected ScoreListViewModel()
        {
        }
    }
}
