using ArcheryManager.CustomControls;
using ArcheryManager.Settings;
using ArcheryManager.Utils;

namespace ArcheryManager.Interactions.Behaviors
{
    public class ArrowListOrderedBehavior : CustomBehavior<ArrowUniformGrid>
    {
        private readonly IGeneralCounterSetting GeneralCounterSetting;

        private CountSetting CountSetting
        {
            get
            {
                return GeneralCounterSetting.CountSetting;
            }
        }

        public ArrowListOrderedBehavior(IGeneralCounterSetting generalCounterSetting)
        {
            GeneralCounterSetting = generalCounterSetting;
        }

        protected override void OnAttachedTo(ArrowUniformGrid bindable)
        {
            base.OnAttachedTo(bindable);
            CountSetting.PropertyChanged += TargetSetting_PropertyChanged;
        }

        private void TargetSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountSetting.IsDecreasingOrder))
            {
                if (CountSetting.IsDecreasingOrder)
                {
                    AssociatedObject.OrderSelector = a => a.Index * -1;
                }
                else
                {
                    AssociatedObject.OrderSelector = null;
                }
            }
        }
    }
}
