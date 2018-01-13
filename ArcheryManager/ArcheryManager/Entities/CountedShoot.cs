using ArcheryManager.Interfaces;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.Entities
{
    public class CountedShoot : BaseEntity, IArrowNumberHolder
    {
        public const int DefaultArrowCount = 6;
        public const int MinArrowCount = 3;
        private const bool DefaultShowAllArrows = false;
        private const bool DefaultWantTarget = true;
        private int _arrowsCount = DefaultArrowCount;
        private bool _averageIsVisible;
        private bool _haveMaxArrowsCount;
        private bool _isDecreasingOrder;
        private bool _isFinished;
        private bool _showAllArrows = DefaultShowAllArrows;
        private TargetStyle _targetStyle;

        public IEnumerable<Arrow> AllArrows => Flights.SelectMany(fl => fl.Arrows);

        public int ArrowsCount
        {
            get { return _arrowsCount; }
            set
            {
                _arrowsCount = value;
                OnPropertyChange(nameof(ArrowsCount));
            }
        }

        public bool AverageIsVisible
        {
            get
            {
                return _averageIsVisible;
            }
            set
            {
                _averageIsVisible = value;
                OnPropertyChange(nameof(AverageIsVisible));
            }
        }

        public Collection<Arrow> CurrentArrows
        {
            get
            {
                return CurrentFlight?.Arrows;
            }
        }

        public Flight CurrentFlight
        {
            get
            {
                return Flights.LastOrDefault(f => !f.IsValidated);
            }
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Flight> Flights { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Remark> GeneralRemarks { get; set; }

        public bool HaveMaxArrowsCount
        {
            get { return _haveMaxArrowsCount; }
            set
            {
                _haveMaxArrowsCount = value;
                OnPropertyChange(nameof(HaveMaxArrowsCount));
            }
        }

        public bool HaveTarget { get; set; } = DefaultWantTarget;

        public bool IsDecreasingOrder
        {
            get
            {
                return _isDecreasingOrder;
            }
            set
            {
                _isDecreasingOrder = value;
                OnPropertyChange(nameof(IsDecreasingOrder));
            }
        }

        public bool IsFinished
        {
            get { return _isFinished; }
            set
            {
                _isFinished = value;
                OnPropertyChange(nameof(IsFinished));
            }
        }

        public int ServerId { get; set; }

        public bool ShowAllArrows
        {
            get
            {
                return _showAllArrows;
            }
            set
            {
                _showAllArrows = value;
                OnPropertyChange(nameof(ShowAllArrows));
            }
        }

        public TargetStyle TargetStyle
        {
            get { return _targetStyle; }
            set
            {
                _targetStyle = value;
                OnPropertyChange(nameof(TargetStyle));
            }
        }

        IEnumerable<Flight> IArrowNumberHolder.Flights
        {
            get
            {
                return Flights;
            }
        }

        public CountedShoot()
        {
            GeneralRemarks = new ObservableCollection<Remark>();
            GeneralRemarks.CollectionChanged += GeneralRemarks_CollectionChanged;
            Flights = new ObservableCollection<Flight>();
            Flights.CollectionChanged += Flights_CollectionChanged;
        }

        public Flight CreateNewFlight()
        {
            var flight = new Flight();
            Flights.Add(flight);
            return flight;
        }

        private void Flights_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateModificationDate();
            if (e.NewItems != null)
            {
                foreach (Flight f in e.NewItems)
                {
                    f.CountedShoot = this;
                }
            }
        }

        private void GeneralRemarks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateModificationDate();
            if (e.NewItems != null)
            {
                foreach (Remark r in e.NewItems)
                {
                    r.CountedShoot = this;
                }
            }
        }
    }
}
