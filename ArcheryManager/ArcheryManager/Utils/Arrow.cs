﻿using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class Arrow
    {
        public double TranslationX { get; private set; }
        public double TranslationY { get; private set; }
        public string Score { get; private set; }
        public int Value { get; private set; }
        public Color Color { get; private set; }

        public Arrow(Point position, string score, int value, Color color)
        {
            TranslationX = position.X;
            TranslationY = position.Y;
            Score = score;
            Color = color;
            Value = value;
        }
    }
}
