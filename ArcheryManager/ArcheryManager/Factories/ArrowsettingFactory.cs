using System;
using ArcheryManager.CustomControls;
using ArcheryManager.Interfaces;
using static ArcheryManager.CustomControls.TargetImage;
using ArcheryManager.Settings;

namespace ArcheryManager.Factories
{
    internal class ArrowsettingFactory
    {
        public static IArrowSetting Create(TargetStyle targetStyle)
        {
            switch (targetStyle)
            {
                case TargetStyle.EnglishTarget:
                    return EnglishArrowSetting.Instance;

                case TargetStyle.FieldTarget:
                    return FieldArrowSetting.Instance;

                case TargetStyle.IndoorRecurveTarget:
                    return IndoorRecurveArrowSetting.Instance;

                case TargetStyle.IndoorCompoundTarget:
                    return IndoorCompoundArrowSetting.Instance;

                default:
                    goto case TargetStyle.EnglishTarget;
            }
        }
    }
}
