using ArcheryManager.Interfaces;
using ArcheryManager.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(GeneralCounterSetting))]

namespace ArcheryManager.Settings
{
    public class GeneralCounterSetting : IGeneralCounterSetting
    {
        public ScoreResult ScoreResult { get; set; }
        public CountSetting CountSetting { get; set; }
        public IArrowSetting ArrowSetting { get; set; }
    }
}
