using ArcheryManager.CustomControls;
using ArcheryManager.Entities;

namespace ArcheryManager.Interactions.Behaviors
{
    public class ArrowListOrderedBehavior : CustomBehavior<ArrowUniformGrid>
    {
        private readonly CountedShoot Shoot;

        public ArrowListOrderedBehavior(CountedShoot shoot)
        {
            Shoot = shoot;
        }

        protected override void OnAttachedTo(ArrowUniformGrid bindable)
        {
            base.OnAttachedTo(bindable);
            Shoot.PropertyChanged += TargetSetting_PropertyChanged;
        }

        private void TargetSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountedShoot.IsDecreasingOrder))
            {
                if (Shoot.IsDecreasingOrder)
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
