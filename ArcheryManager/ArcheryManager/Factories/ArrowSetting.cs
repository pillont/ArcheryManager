using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace ArcheryManager.Factories
{
    public class ArrowSetting
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

        private static ArrowSetting englishInstance;

        private readonly Dictionary<int, string> scoreByIndex;
        private readonly Dictionary<string, Color> colorOf;

        private ArrowSetting(Dictionary<int, string> scoreByIndex, Dictionary<string, Color> colorOf)
        {
            this.scoreByIndex = scoreByIndex;
            this.colorOf = colorOf;
            ZoneCount = scoreByIndex.Count;
        }

        public int ZoneCount { get; set; }

        public static ArrowSetting EnglishInstance //TODO multi class with singleton and common interface IArrowSetting
        {
            get
            {
                if (englishInstance == null)
                {
                    englishInstance = new ArrowSetting(englishScoreByIndex, EnglishColorOf);
                }
                return englishInstance;
            }
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
