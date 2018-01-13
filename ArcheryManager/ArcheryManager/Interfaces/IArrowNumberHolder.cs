using ArcheryManager.Entities;
using System.Collections.Generic;

namespace ArcheryManager.Interfaces
{
    public interface IArrowNumberHolder
    {
        int ArrowsCount { get; set; }
        IEnumerable<Flight> Flights { get; }
        bool HaveMaxArrowsCount { get; set; }
    }
}
