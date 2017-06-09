using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IArrowSetting
    {
        int ZoneCount { get; }

        string ScoreByIndex(int i);

        Color ColorOf(string score);

        int ValueByScore(string score);
    }
}
