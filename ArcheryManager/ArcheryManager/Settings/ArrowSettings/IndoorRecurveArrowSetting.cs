using ArcheryManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Settings.ArrowSettings
{
    public class IndoorRecurveArrowSetting : IArrowSetting
    {
        public const string MissScore = "M";
        public const string SixScore = "6";
        public const string SevenScore = "7";
        public const string HeightScore = "8";
        public const string NineScore = "9";
        public const string TenScore = "10";
        private const int IndoorRecurveZoneCount = 6;
        private const int IndoorRecurveMaxValue = 10;

        private static Dictionary<string, Color> IndoorRecurveColorOf = new Dictionary<string, Color>()
        {
            { MissScore, Color.Green},
            { SixScore,  Color.CornflowerBlue},
            { SevenScore, Color.Red},
            { HeightScore, Color.Red},
            { NineScore, Color.Yellow},
            { TenScore, Color.Yellow},
        };

        private static readonly Dictionary<int, string> IndoorRecurveScoreByIndex = new Dictionary<int, string>()
        {
            { 0, MissScore },
            { 1 , SixScore },
            { 2 , SevenScore },
            { 3 , HeightScore },
            { 4 , NineScore },
            { 5 , TenScore },
        };

        public int MaxScore
        {
            get
            {
                return IndoorRecurveMaxValue;
            }
        }

        public int ZoneCount
        {
            get
            {
                return IndoorRecurveZoneCount;
            }
        }

        private static IArrowSetting instance;

        public static IArrowSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IndoorRecurveArrowSetting();
                }
                return instance;
            }
        }

        private IndoorRecurveArrowSetting()
        {
        }

        public string ScoreByIndex(int i)
        {
            if (IndoorRecurveScoreByIndex.ContainsKey(i))
            {
                return IndoorRecurveScoreByIndex[i];
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
            var index = IndoorRecurveScoreByIndex.Where(val => val.Value == score).FirstOrDefault().Key;
            if (index == 0)
                return index;
            else
            {
                index += 5;
                if (index < 11)
                    return index;
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
            return Color.Black;
        }
    }
}
