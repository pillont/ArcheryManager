using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class CounterButtonBehavior : CustomBehavior<CounterButtons>
    {
        private readonly ScoreCounter Counter;
        private readonly CountedShoot Shoot;

        public CounterButtonBehavior(CounterManager manager)
        {
            Counter = manager.Counter;
            Shoot = manager.CurrentShoot;
        }

        public void ButtonTap(BindableObject button)
        {
            if (button.BindingContext is Arrow buttonArrow)
            {
                var arrow = new Arrow()
                {
                    Index = buttonArrow.Index,
                    NumberInFlight = Shoot.CurrentArrows.Count
                };
                Counter.AddArrowIfPossible(arrow);
            }
        }

        protected override void OnAttachedTo(CounterButtons bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject.ButtonTap += AssociatedObject_ButtonTapped;
        }

        private void AssociatedObject_ButtonTapped(object sender, EventArgs e)
        {
            ButtonTap(sender as BindableObject);
        }
    }
}
