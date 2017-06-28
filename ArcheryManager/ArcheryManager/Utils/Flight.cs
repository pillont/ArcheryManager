using System.Collections.Generic;

namespace ArcheryManager.Utils
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
