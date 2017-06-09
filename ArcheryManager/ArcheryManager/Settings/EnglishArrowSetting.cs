using ArcheryManager.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Settings
{
    public class EnglishArrowSetting : IArrowSetting
    {
        public const string MissScore = "M";
        public const string OneScore = "1";
        public const string TwoScore = "2";
        public const string ThreeScore = "3";
        public const string FourScore = "4";
        public const string FiveScore = "5";
        public const string SixScore = "6";
        public const string SevenScore = "7";
        public const string HeightScore = "8";
        public const string NineScore = "9";
        public const string TenScore = "10";
        public const string XtenScore = "X10";
        private const int EnglishZoneCount = 12;

        private static Dictionary<string, Color> EnglishColorOf = new Dictionary<string, Color>()
        {
            { MissScore, Color.Green},
            { OneScore, Color.White},
            { TwoScore, Color.White},
            { ThreeScore, Color.Gray},
            { FourScore, Color.Gray},
            { FiveScore, Color.CornflowerBlue},
            { SixScore,  Color.CornflowerBlue},
            { SevenScore, Color.Red},
            { HeightScore, Color.Red},
            { NineScore, Color.Yellow},
            { TenScore, Color.Yellow},
            { XtenScore, Color.Yellow},
        };

        private static readonly Dictionary<int, string> EnglishScoreByIndex = new Dictionary<int, string>()
        {
            { 0 , MissScore },
            { 1 , OneScore },
            { 2 , TwoScore },
            { 3 , ThreeScore },
            { 4 , FourScore },
            { 5 , FiveScore },
            { 6 , SixScore },
            { 7 , SevenScore },
            { 8 , HeightScore },
            { 9 , NineScore },
            { 10 , TenScore },
            { 11 , XtenScore },
        };

        public int ZoneCount
        {
            get
            {
                return EnglishZoneCount;
            }
        }

        private static IArrowSetting instance;

        public static IArrowSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnglishArrowSetting();
                }
                return instance;
            }
        }

        private EnglishArrowSetting()
        {
        }

        public string ScoreByIndex(int i)
        {
            if (EnglishScoreByIndex.ContainsKey(i))
            {
                return EnglishScoreByIndex[i];
            }
            else
            {
                return MissScore;
            }
        }

        public Color ColorOf(string score)
        {
            if (EnglishColorOf.ContainsKey(score))
            {
                return EnglishColorOf[score];
            }
            else
            {
                return EnglishColorOf[MissScore];
            }
        }

        public int ValueByScore(string score)
        {
            var index = EnglishScoreByIndex.Where(val => val.Value == score).FirstOrDefault().Key;
            if (index < 11)
                return index;
            else // case of X10
                return 10;
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
                case 3:
                case 4:
                    return Color.Black;

                case 5:
                case 6:
                    return Color.Blue;

                case 7:
                case 8:
                    return Color.Red;

                case 9:
                case 10:
                case 11:
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
            if (i == 3 || i == 4)
                return Color.White;
            else
                return Color.Black;
        }
    }
}
