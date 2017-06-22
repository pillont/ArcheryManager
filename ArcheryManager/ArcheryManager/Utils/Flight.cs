using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
