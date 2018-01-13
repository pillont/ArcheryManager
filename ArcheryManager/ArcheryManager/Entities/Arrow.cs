using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ArcheryManager.Entities
{
    public class Arrow : BaseEntity
    {
        #region flight relation

        [ManyToOne]
        public Flight Flight { get; set; }

        [ForeignKey(typeof(Flight))]
        public int? FlightID { get; set; }

        #endregion flight relation

        private bool _isSelected;
        public int Index { get; set; }

        [Ignore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChange(nameof(IsSelected));
            }
        }

        public int NumberInFlight { get; set; }
        public double TargetSize { get; set; }
        public double TranslationX { get; set; }
        public double TranslationY { get; set; }
    }
}
