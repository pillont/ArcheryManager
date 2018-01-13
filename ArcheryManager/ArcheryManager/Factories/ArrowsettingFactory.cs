using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.Factories
{
    public class ArrowSettingFactory
    {
        public static readonly Dictionary<TargetStyle, IArrowSetting> Values = new Dictionary<TargetStyle, IArrowSetting>()
        {
            {TargetStyle.EnglishTarget, EnglishArrowSetting.Instance},
            {TargetStyle.FieldTarget, FieldArrowSetting.Instance },
            {TargetStyle.IndoorRecurveTarget, IndoorRecurveArrowSetting.Instance},
            {TargetStyle.IndoorCompoundTarget, IndoorCompoundArrowSetting.Instance},
        };

        public static IArrowSetting Create(TargetStyle targetStyle)
        {
            return Values[targetStyle];
        }

        public static TargetStyle GetTargetStyle(IArrowSetting arrowSetting)
        {
            return Values.Where(pair => pair.Value == arrowSetting).Single().Key;
        }

        internal static IArrowSetting Create(string targetStyleString)
        {
            TargetStyle style;
            Enum.TryParse(targetStyleString, out style);
            return Create(style);
        }
    }
}
