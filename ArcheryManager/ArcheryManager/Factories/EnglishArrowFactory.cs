using ArcheryManager.Behaviors;
using ArcheryManager.CustomControls.Targets;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class EnglishArrowFactory : ArrowFactory
    {
        private const string MissScore = "M";
        private const string OneScore = "1";
        private const string TwoScore = "2";
        private const string ThreeScore = "3";
        private const string FourScore = "4";
        private const string FiveScore = "5";
        private const string SixScore = "6";
        private const string SevenScore = "7";
        private const string HeightScore = "8";
        private const string NineScore = "9";
        private const string TenScore = "10";
        private const string XtenScore = "X10";

        private Dictionary<string, Color> EnglishColorOf = new Dictionary<string, Color>()
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

        private readonly IMovableTarget target;

        public EnglishArrowFactory(IMovableTarget target)
        {
            this.target = target;
        }

        public override Arrow Create(Point position)
        {
            var arrow = base.Create(position);

            var x = transformPosition(arrow.TranslationX);
            var y = transformPosition(arrow.TranslationY);
            var point = new Point(x, y);
            var res = new Arrow(point, arrow.Score, arrow.Value, arrow.Color);

            return res;
        }

        private double transformPosition(double val)
        {
            return (val + val * Math.Abs(MovableTargetBehavior<EnglishTarget>.TargetTranslationRate)) / MovableTargetBehavior<EnglishTarget>.TargetScale;
        }

        protected string ScoreByIndex(int i)
        {
            return englishScoreByIndex[i];
        }

        protected override string ScoreOf(Point position)
        {
            double distance = Math.Sqrt(Math.Pow(position.X, 2) + Math.Pow(position.Y, 2));
            distance -= distance * MovableTargetBehavior<EnglishTarget>.TargetTranslationRate; // target translation
            distance -= EnglishTarget.ArrowWidth / 2; // arrow size
            distance -= EnglishTarget.StringWidth; // string size

            for (int i = 11; i > 0; i--)
            {
                double rate = (EnglishTarget.ColorCount - i * EnglishTarget.ColorWidthRatio) / EnglishTarget.ColorCount;

                double size = target.TargetSize * rate;
                size *= MovableTargetBehavior<EnglishTarget>.TargetScale; // target scale
                if (distance < size / 2)
                    return ScoreByIndex(i);
            }
            return MissScore;
        }

        protected override Color ColorOf(string value)
        {
            return EnglishColorOf[value];
        }

        protected override int ValueByScore(string score)
        {
            var index = englishScoreByIndex.Where(val => val.Value == score).FirstOrDefault().Key;
            if (index < 11)
                return index;
            else // case of X10
                return 10;
        }
    }
}
