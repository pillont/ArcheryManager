using ArcheryManager.Interfaces;

namespace ArcheryManager.Settings
{
    public interface IGeneralCounterSetting
    {
        IArrowSetting ArrowSetting { get; set; }
        CountSetting CountSetting { get; set; }
        ScoreCounter ScoreCounter { get; set; }
    }
}
