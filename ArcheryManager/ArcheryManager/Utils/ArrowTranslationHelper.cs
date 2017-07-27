using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryManager.Utils
{
    public static class ArrowTranslationHelper
    {
        public static double TranslationYOf(Arrow arrow, double targetSize)
        {
            return TransformTranslation(arrow.TranslationY, arrow.TargetSize, targetSize);
        }

        public static double TranslationXOf(Arrow arrow, double targetSize)
        {
            return TransformTranslation(arrow.TranslationX, arrow.TargetSize, targetSize);
        }

        private static double TransformTranslation(double translation, double arrowTargetSize, double targetSize)
        {
            return targetSize / arrowTargetSize * translation;
        }
    }
}
