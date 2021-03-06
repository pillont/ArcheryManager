﻿using ArcheryManager.Entities;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Factories
{
    public class ArrowFactory
    {
        private readonly IMovableTarget Target;

        public IArrowSetting Setting { get; internal set; }

        public ArrowFactory(IMovableTarget target, IArrowSetting setting)
        {
            this.Target = target;
            Setting = setting;
        }

        public virtual Arrow Create(Point position, int numberInFlight, double targetSize)
        {
            int index = IndexByPosition(position);
            var x = transformPosition(position.X);
            var y = transformPosition(position.Y);
            var res = new Arrow()
            {
                Index = index,
                NumberInFlight = numberInFlight,
                TranslationX = x,
                TranslationY = y,
                TargetSize = targetSize
            };

            return res;
        }

        protected Color ColorOf(string value)
        {
            return Setting.ColorOf(value);
        }

        protected int IndexByPosition(Point position)
        {
            double distance = Math.Sqrt(Math.Pow(position.X, 2) + Math.Pow(position.Y, 2));
            distance -= distance * MovableTargetBehavior.TargetTranslationRate; // target translation
            distance -= CustomControls.Target.ArrowWidth / 2; // arrow size
            distance -= CustomControls.Target.StringWidth; // string size

            for (int i = Setting.ZoneCount - 1; i > 0; i--)
            {
                double rate = (Setting.ZoneCount - i * CustomControls.Target.ColorWidthRatio) / Setting.ZoneCount;

                double size = Target.TargetSize * rate;
                size *= MovableTargetBehavior.TargetScale; // target scale
                if (distance < size / 2)
                    return i;
            }
            return 0;
        }

        protected string ScoreByIndex(int i)
        {
            return Setting.ScoreByIndex(i);
        }

        protected int ValueByScore(string score)
        {
            return Setting.ValueByScore(score);
        }

        private double transformPosition(double val)
        {
            return (val + val * Math.Abs(MovableTargetBehavior.TargetTranslationRate)) / MovableTargetBehavior.TargetScale;
        }
    }
}
