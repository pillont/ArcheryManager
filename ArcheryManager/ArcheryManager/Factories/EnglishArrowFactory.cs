﻿using ArcheryManager.Behaviors;
using ArcheryManager.CustomControls.Targets;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class EnglishArrowFactory : ArrowFactory // TODO add functionnalities to general ArrowFactory, just add setting to ctor
    {
        private readonly IMovableTarget target;

        public EnglishArrowFactory(IMovableTarget target)
        {
            this.target = target;
            Setting = EnglishArrowSetting.Instance;
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
            return Setting.ScoreByIndex(i);
        }

        protected override string ScoreOf(Point position)
        {
            double distance = Math.Sqrt(Math.Pow(position.X, 2) + Math.Pow(position.Y, 2));
            distance -= distance * MovableTargetBehavior<EnglishTarget>.TargetTranslationRate; // target translation
            distance -= EnglishTarget.ArrowWidth / 2; // arrow size
            distance -= EnglishTarget.StringWidth; // string size

            for (int i = 11; i > 0; i--)
            {
                double rate = (Setting.ZoneCount - i * EnglishTarget.ColorWidthRatio) / Setting.ZoneCount;

                double size = target.TargetSize * rate;
                size *= MovableTargetBehavior<EnglishTarget>.TargetScale; // target scale
                if (distance < size / 2)
                    return ScoreByIndex(i);
            }
            return EnglishArrowSetting.MissScore;
        }

        protected override Color ColorOf(string value)
        {
            return Setting.ColorOf(value);
        }

        protected override int ValueByScore(string score)
        {
            return Setting.ValueByScore(score);
        }
    }
}
