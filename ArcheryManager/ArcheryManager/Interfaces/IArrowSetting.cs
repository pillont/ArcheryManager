using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface IArrowSetting
    {
        int ZoneCount { get; }

        string ScoreByIndex(int i);

        Color ColorOf(string score);

        int ValueByScore(string score);

        /// <summary>
        ///determine the color associated to the score zone
        ///
        /// </summary>
        /// <param name="i">score zone / 11 => X10 </param>
        /// <returns>default white</returns>
        Color ColorofTargetZone(int i);

        /// <summary>
        /// determine the color of the zone string
        /// </summary>
        /// <param name="i">score zone</param>
        Color BorderColorZone(int i);
    }
}
