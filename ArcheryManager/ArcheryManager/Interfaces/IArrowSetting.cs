using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IArrowSetting
    {
        int MaxScore { get; }
        string MaxValue { get; }
        string PreMaxValue { get; }
        int ZoneCount { get; }

        /// <summary>
        /// determine the color of the zone string
        /// </summary>
        /// <param name="i">score zone</param>
        Color BorderColorZone(int i);

        Color ColorOf(string score);

        Color ColorOf(int value);

        /// <summary>
        ///determine the color associated to the score zone
        ///
        /// </summary>
        /// <param name="i">score zone / 11 => X10 </param>
        /// <returns>default white</returns>
        Color ColorofTargetZone(int i);

        string ScoreByIndex(int i);

        int ValueByScore(string score);
    }
}
