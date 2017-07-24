using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using System.Collections.ObjectModel;

namespace ArcheryManager.Utils
{
    internal class CounterButtonGenerator
    {
        private readonly IGeneralCounterSetting GeneralCounterSetting;

        public CounterButtonGenerator(IGeneralCounterSetting generalCounterSetting)
        {
            GeneralCounterSetting = generalCounterSetting;
        }

        private IArrowSetting ArrowSetting
        {
            get
            {
                return GeneralCounterSetting.ArrowSetting;
            }
        }

        public ObservableCollection<Arrow> GeneralButton()
        {
            var buttonsData = new ObservableCollection<Arrow>();

            for (int i = 1; i < ArrowSetting.ZoneCount; i++)
            {
                Arrow arrow = GetArrow(i);
                buttonsData.Add(arrow);
            }
            var missArrow = GetArrow(0);
            buttonsData.Add(missArrow);

            return buttonsData;
        }

        private Arrow GetArrow(int i)
        {
            int numberInFlight = GeneralCounterSetting.ScoreResult.CurrentArrows.Count;
            var arrow = new Arrow(i, numberInFlight);
            return arrow;
        }
    }
}
