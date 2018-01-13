using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using XLabs.Forms.Mvvm;
using Xamarin.Forms;
using System;

namespace ArcheryManager.ViewModels
{
    /// <summary>
    /// View model of ResultPage
    /// </summary>
    public class ResultPageViewModel : ViewModel
    {
        public double Average { get; }
        public Color AverageColor { get; }

        /// <summary>
        /// list of view model to show all arrow
        /// </summary>
        public ObservableCollection<ResultScoreListViewModel> ListSource { get; }

        public int MaxCount { get; }
        public string MaxValue { get; }
        public int PreMaxCount { get; }
        public string PreMaxValue { get; }
        public int Total { get; }

        public ResultPageViewModel(CountedShoot shoot)
        {
            ListSource = GeneralSource(shoot);

            var setting = ArrowSettingFactory.Create(shoot.TargetStyle);
            Total = shoot.AllArrows.Sum(arr => ValueOf(arr, setting));
            Average = shoot.AllArrows.Average(arr => ValueOf(arr, setting));
            var color = setting.ColorOf((int)Average);
            AverageColor = color != Color.White
                            ? color
                            : Color.Gray;

            MaxValue = setting.MaxValue;
            MaxCount = shoot.AllArrows //get all arrows
                            .Where(arr => setting.ScoreByIndex(arr.Index) == MaxValue) // where is max
                            .Count(); // select count

            PreMaxValue = setting.PreMaxValue;
            PreMaxCount = shoot.AllArrows //get all arrows
                            .Where(arr => setting.ScoreByIndex(arr.Index) == PreMaxValue) // where is max
                            .Count(); // select count
        }

        public int ValueOf(Arrow arrow, IArrowSetting setting)
        {
            return setting.ValueByScore(setting.ScoreByIndex(arrow.Index));
        }

        /// <summary>
        /// generate list of view model
        /// one view model by flight
        /// </summary>
        private ObservableCollection<ResultScoreListViewModel> GeneralSource(CountedShoot shoot)
        {
            var setting = ArrowSettingFactory.Create(shoot.TargetStyle);
            var list = new ObservableCollection<ResultScoreListViewModel>();

            int index = 1;
            int accrued = 0;
            foreach (var fl in shoot.Flights)
            {
                var arrows = fl.Arrows;
                var vm = new ResultScoreListViewModel(arrows, setting, index, accrued);
                list.Add(vm);

                accrued = vm.AccruedTotal;
                index++;
            }

            return list;
        }
    }
}
