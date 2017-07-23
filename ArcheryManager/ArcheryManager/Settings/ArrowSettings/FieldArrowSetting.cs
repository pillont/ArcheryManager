using ArcheryManager.Interfaces;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Settings.ArrowSettings
{
    public class FieldArrowSetting : IArrowSetting
    {
        public int ZoneCount => 7;

        private const string MissScore = "M";
        private const int FieldMaxValue = 6;
        private static FieldArrowSetting instance;

        public static FieldArrowSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FieldArrowSetting();
                }

                return instance;
            }
        }

        public int MaxScore
        {
            get
            {
                return FieldMaxValue;
            }
        }

        private FieldArrowSetting()
        {
        }

        public Color BorderColorZone(int i)
        {
            switch (i)
            {
                case 5:
                case 6:
                    return Color.Black;

                default:
                    return Color.White;
            }
        }

        public Color ColorOf(string score)
        {
            if (int.TryParse(score, out int val) && val > 0 && val < 7)
            {// val 1 to 6
                var res = ColorofTargetZone(val);
                if (res == Color.Black)
                {
                    return Color.Gray;
                }
                else
                {
                    return res;
                }
            }
            else if (score == MissScore)
            {// miss
                return Color.Green;
            }
            else
            {// other
                return Color.White;
            }
        }

        public Color ColorofTargetZone(int i)
        {
            if (i > 0 && i < 7)
            {// 1 to 6
                switch (i)
                {
                    case 5:
                    case 6:
                        return Color.Yellow;

                    default:
                        return Color.Black;
                }
            }
            else if (i == 0)
            {// miss
                return Color.Green;
            }
            else
            {//other
                return Color.White;
            }
        }

        public string ScoreByIndex(int i)
        {
            if (i > 0 && i < 7)
            {// one to seven
                return i.ToString();
            }
            else if (i == 0)
            {// miss
                return MissScore;
            }
            else
            {// other
                throw new ArgumentException("index not valid");
            }
        }

        public int ValueByScore(string score)
        {
            if (score == MissScore)
            {// miss
                return 0;
            }
            else if (int.TryParse(score, out int val) && val > 0 && val < 7)
            {
                return val;
            }
            else
            {
                throw new ArgumentException("score not valid");
            }
        }
    }
}
