using ArcheryManager.Entities;
using ArcheryManager.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcheryManager.ViewModels
{
    /// <summary>
    /// view model for each flight in the result page
    /// </summary>
    public class ResultScoreListViewModel
    {
        public int AccruedTotal { get; }
        public ObservableCollection<Arrow> Arrows { get; }
        public IArrowSetting ArrowSetting { get; }
        public int FlightNumber { get; }
        public int Total { get; }

        public ResultScoreListViewModel(IEnumerable<Arrow> arrows, IArrowSetting setting, int flightNumber, int previousTotal)
        {
            FlightNumber = flightNumber;
            Arrows = new ObservableCollection<Arrow>(arrows);
            ArrowSetting = setting;
            Total = Arrows.Sum(arr => ValueOf(arr));
            AccruedTotal = previousTotal + Total;
        }

        private int ValueOf(Arrow arr)
        {
            return ArrowSetting.ValueByScore(ArrowSetting.ScoreByIndex(arr.Index));
        }
    }
}
