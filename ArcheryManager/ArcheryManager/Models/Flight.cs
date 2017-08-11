using System.Collections.Generic;

namespace ArcheryManager.Models
{
    public class Flight : List<Arrow>
    {
        public int Number { get; set; }

        public Flight(IEnumerable<Arrow> collection)
            : base(collection)
        {
        }
    }
}
