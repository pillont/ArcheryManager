using ArcheryManager.Interfaces;

namespace ArcheryManager.Settings
{
    public interface IGeneralCounterSetting
    {
        ScoreResult ScoreResult { get; }
        IArrowSetting ArrowSetting { get; }
        CountSetting CountSetting { get; }
    }
}
