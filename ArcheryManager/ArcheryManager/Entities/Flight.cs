using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ArcheryManager.Entities
{
    public class Flight : BaseEntity
    {
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Arrow> Arrows { get; set; }

        public bool IsValidated { get; set; }

        #region countedshoot relation

        private CountedShoot _countedShoot;

        [ManyToOne]
        public CountedShoot CountedShoot
        {
            get
            {
                return _countedShoot;
            }
            set
            {
                _countedShoot = value;
                ShootID = value?.ID;
            }
        }

        [ForeignKey(typeof(CountedShoot))]
        public int? ShootID { get; set; }

        #endregion countedshoot relation

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Remark> Remarks { get; set; }

        public Flight()
        {
            Remarks = new ObservableCollection<Remark>();
            Remarks.CollectionChanged += Remarks_CollectionChanged;
            Arrows = new ObservableCollection<Arrow>();
            Arrows.CollectionChanged += Arrows_CollectionChanged;
        }

        private void Arrows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Arrow a in e.NewItems)
                {
                    a.Flight = this;
                }
            }
        }

        private void Remarks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Remark r in e.NewItems)
                {
                    r.Flight = this;
                }
            }
        }
    }
}
