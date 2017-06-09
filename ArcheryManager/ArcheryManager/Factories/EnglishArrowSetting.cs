using ArcheryManager.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Factories
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
        private const int EnglishZOneCOunt = 12;

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

        private static readonly Dictionary<int, string> englishScoreByIndex = new Dictionary<int, string>()
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
                return EnglishZOneCOunt;
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
            return englishScoreByIndex[i];
        }

        public Color ColorOf(string score)
        {
            return EnglishColorOf[score];
        }

        public int ValueByScore(string score)
        {
            var index = englishScoreByIndex.Where(val => val.Value == score).FirstOrDefault().Key;
            if (index < 11)
                return index;
            else // case of X10
                return 10;
        }
    }
}
