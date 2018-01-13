using ArcheryManager.Entities;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcheryManager.Utils
{
    public static class CounterButtonGenerator
    {
        public static ObservableCollection<Arrow> GeneralButton(IArrowSetting setting)
        {
            // NOTE : reverse to have decrementing list
            var arrows = ArrowsEnumerable(setting).Reverse();
            var buttonsData = new ObservableCollection<Arrow>(arrows);

            return buttonsData;
        }

        private static IEnumerable<Arrow> ArrowsEnumerable(IArrowSetting setting)
        {
            for (int i = 0; i < setting.ZoneCount; i++)
            {
                //NOTE : remove second 9 zone on indoor compound target
                if (setting is IndoorCompoundArrowSetting
                && i == setting.ZoneCount - 2)
                {
                    continue;
                }

                yield return GetArrow(i);
            }

            yield break;
        }

        private static Arrow GetArrow(int i)
        {
            var arrow = new Arrow() { Index = i };
            return arrow;
        }
    }
}
