using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;

[assembly: Xamarin.Forms.Dependency(typeof(GeneralCounterSetting))]

namespace ArcheryManager.Settings
{
    public class GeneralCounterSetting : IGeneralCounterSetting
    {
        private static readonly IArrowSetting DefaultArrowSetting = EnglishArrowSetting.Instance;

        public ScoreResult ScoreResult { get; set; }
        public CountSetting CountSetting { get; set; }
        public IArrowSetting ArrowSetting { get; set; }
        public RemarksSaved RemarksSaved { get; set; }

        public GeneralCounterSetting()
        {
            ScoreResult = new ScoreResult();
            CountSetting = new CountSetting();
            ArrowSetting = DefaultArrowSetting;
            RemarksSaved = new RemarksSaved();
        }
    }
}
