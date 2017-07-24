using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class CounterButtonGenerator
    {
        private IArrowSetting ArrowSetting { get; set; }

        public CounterButtonGenerator(IArrowSetting arrowSetting)
        {
            ArrowSetting = arrowSetting;
        }

        public ObservableCollection<Arrow> GeneralButton()
        {
            var buttonsData = new ObservableCollection<Arrow>();

            for (int i = 1; i < ArrowSetting.ZoneCount; i++)
            {
                Arrow arrow = GetArrow(i);
                buttonsData.Add(arrow);
            }

            //NOTE : remove second 9 zone on indoor compound target
            if (ArrowSetting is IndoorCompoundArrowSetting)
            {
                buttonsData.Remove(buttonsData.Last());
            }

            var missArrow = GetArrow(0);
            buttonsData.Add(missArrow);

            return buttonsData;
        }

        private Arrow GetArrow(int i)
        {
            var arrow = new Arrow(i, -1);
            return arrow;
        }
    }
}
