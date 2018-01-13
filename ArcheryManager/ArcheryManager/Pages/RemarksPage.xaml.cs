using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemarksPage : ContentPageWithGeneralEvent
    {
        public new RemarksPageViewModel BindingContext
        {
            get
            {
                return base.BindingContext as RemarksPageViewModel;
            }
        }

        public RemarksPage()
        {
            InitializeComponent();
        }
    }

    public class RemarksPageViewModel : ViewModel
    {
        private readonly ISQLiteConnectionManager DBSaver;
        private readonly CounterManager Manager;
        public ObservableCollection<Remark> FlightRemarksPrevious { get; private set; }
        public ObservableCollection<Remark> GeneralRemarksPrevious { get; private set; }
        private CountedShoot Shoot => Manager.CurrentShoot;

        public RemarksPageViewModel(CounterManager manager)
        {
            Manager = manager;
            DBSaver = Manager.DBSaver;

            var generalRemarks = manager.CurrentShoot.GeneralRemarks;
            var flightRemarks = manager.CurrentShoot.Flights.SelectMany(f => f.Remarks);

            GeneralRemarksPrevious = new ObservableCollection<Remark>(generalRemarks);
            FlightRemarksPrevious = new ObservableCollection<Remark>(flightRemarks);
            FlightRemarksPrevious.CollectionChanged += Flight_CollectionChanged;
            GeneralRemarksPrevious.CollectionChanged += General_CollectionChanged;
        }

        private void Flight_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var currentFlight = Shoot.CurrentFlight;
            if (e.NewItems != null)
            {
                foreach (Remark r in e.NewItems)
                {
                    currentFlight.Remarks.Add(r);
                    SaveRemarkInDB(r);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Remark r in e.OldItems)
                {
                    currentFlight.Remarks.Remove(r);
                    RemoveRemarkInDB(r);
                }
            }
        }

        private void General_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Remark r in e.NewItems)
                {
                    Shoot.GeneralRemarks.Add(r);
                    SaveRemarkInDB(r);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Remark r in e.OldItems)
                {
                    Shoot.GeneralRemarks.Remove(r);
                    RemoveRemarkInDB(r);
                }
            }
        }

        private void RemoveRemarkInDB(BaseEntity entity)
        {
            DBSaver.DeleteRecursivelyAsync(entity);
        }

        private void SaveRemarkInDB(BaseEntity entity)
        {
            DBSaver.InsertOrReplaceWithChildrenRecursivelyAsync(entity);
        }
    }
}
