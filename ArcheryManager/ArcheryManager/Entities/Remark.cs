using SQLiteNetExtensions.Attributes;

namespace ArcheryManager.Entities
{
    public class Remark : BaseEntity
    {
        private const int FlightIDBase = 1;

        public string Text { get; set; }

        #region countedshoot relation

        [ManyToOne]
        public CountedShoot CountedShoot { get; set; }

        [ForeignKey(typeof(CountedShoot))]
        public int? ShootID { get; set; }

        #endregion countedshoot relation

        #region flight relation

        [ManyToOne]
        public Flight Flight { get; set; }

        [ForeignKey(typeof(Flight))]
        public int? FlightID { get; set; }

        public int FlightIndex
        {
            get
            {
                if (Flight == null) // general remark
                    return -1;

                return Flight.CountedShoot.Flights.IndexOf(Flight) + FlightIDBase;
            }
        }

        #endregion flight relation
    }
}
