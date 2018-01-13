using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using ArcheryManager.Resources;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LimitArrowNumberSelector : ContentView
    {
        public LimitArrowNumberSelector()
        {
            InitializeComponent();
        }
    }

    public class LimitArrowNumberSelectorViewModel : ViewModel
    {
        private IArrowNumberHolder ArrowNumberHolder;

        public int ArrowsCount
        {
            get { return ArrowNumberHolder.ArrowsCount; }
            set
            {
                ArrowNumberHolder.ArrowsCount = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ArrowsCount)));
            }
        }

        public bool HaveMaxArrowsCount
        {
            get { return ArrowNumberHolder.HaveMaxArrowsCount; }
            set
            {
                ArrowNumberHolder.HaveMaxArrowsCount = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(HaveMaxArrowsCount)));
            }
        }

        public ICommand Unfocused => new Command<Entry>((o) => Entry_Unfocused(o));

        public LimitArrowNumberSelectorViewModel(IArrowNumberHolder shoot)
        {
            ArrowNumberHolder = shoot;
        }

        /// <summary>
        /// limit min of Arrow count to const
        /// </summary>
        private void Entry_Unfocused(Entry entry)
        {
            int val = ArrowNumberHolder.ArrowsCount;
            if (val < CountedShoot.MinArrowCount)
            {
                ArrowsCount = CountedShoot.MinArrowCount;
            }

            if (ArrowNumberHolder.Flights.Count() != 0) // have not flight
            {
                int currentFlightArrowNumber = ArrowNumberHolder.Flights.Last().Arrows.Count;
                if (ArrowNumberHolder.ArrowsCount < currentFlightArrowNumber)
                {
                    MessagingCenterHelper.SendToast(this, ErrorResources.Error, ErrorResources.FlightMoreArrowThanNewLimit, AppResources.OK);
                    ArrowsCount = currentFlightArrowNumber;
                }
            }
        }
    }
}
