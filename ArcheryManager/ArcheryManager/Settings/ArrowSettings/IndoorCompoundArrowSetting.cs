using ArcheryManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Settings.ArrowSettings
{
    public class IndoorCompoundArrowSetting : IArrowSetting
    {
        public const string MissScore = "M";
        public const string SixScore = "6";
        public const string SevenScore = "7";
        public const string HeightScore = "8";
        public const string NineScore = "9";
        public const string TenScore = "10";
        private const int IndoorRecurveZoneCount = 7;
        private const int IndoorCounpoundMaxValue = 10;

        private static Dictionary<string, Color> IndoorRecurveColorOf = new Dictionary<string, Color>()
        {
            { MissScore, Color.Green},
            { SixScore,  Color.CornflowerBlue},
            { SevenScore, Color.Red},
            { HeightScore, Color.Red},
            { NineScore, Color.Yellow},
            { TenScore, Color.Yellow},
        };

        private static readonly Dictionary<int, string> IndoorCompoundScoreByIndex = new Dictionary<int, string>()
        {
            { 0, MissScore },
            { 1 , SixScore },
            { 2 , SevenScore },
            { 3 , HeightScore },
            { 4 , NineScore },
            { 5 , NineScore },
            { 6 , TenScore },
        };

        public int ZoneCount
        {
            get
            {
                return IndoorRecurveZoneCount;
            }
        }

        public int MaxScore
        {
            get
            {
                return IndoorCounpoundMaxValue;
            }
        }

        private static IArrowSetting instance;

        public static IArrowSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IndoorCompoundArrowSetting();
                }
                return instance;
            }
        }

        private IndoorCompoundArrowSetting()
        {
        }

        public string ScoreByIndex(int i)
        {
            if (IndoorCompoundScoreByIndex.ContainsKey(i))
            {
                return IndoorCompoundScoreByIndex[i];
            }
            else
            {
                return MissScore;
            }
        }

        public Color ColorOf(string score)
        {
            if (IndoorRecurveColorOf.ContainsKey(score))
            {
                return IndoorRecurveColorOf[score];
            }
            else
            {
                return IndoorRecurveColorOf[MissScore];
            }
        }

        public int ValueByScore(string score)
        {
            var index = IndoorCompoundScoreByIndex.Where(val => val.Value == score).FirstOrDefault().Key;
            if (index == 0) // miss
                return index;
            else
            {
                index += 5;
                if (index < 10) // 6 to 9
                    return index;
                else if (index == 10 || index == 11) // second nine and ten
                    return index - 1;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///determine the color associated to the score zone
        ///
        /// </summary>
        /// <param name="i">score zone / 11 => X10 </param>
        /// <returns>default white</returns>
        public Color ColorofTargetZone(int i)
        {
            switch (i)
            {
                case 1:
                    return Color.Blue;

                case 2:
                case 3:
                    return Color.Red;

                case 4:
                case 5:
                case 6:
                    return Color.Yellow;

                default:
                    return Color.White;
            }
        }

        /// <summary>
        /// determine the color of the zone string
        /// </summary>
        /// <param name="i">score zone</param>
        public Color BorderColorZone(int i)
        {
            if (i == 5)
            {
                return Color.Yellow; // border to not see defferent between first and second nine
            }
            return Color.Black;
        }
    }
}
