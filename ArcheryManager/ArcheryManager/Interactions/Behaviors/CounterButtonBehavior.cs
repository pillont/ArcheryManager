using ArcheryManager.CustomControls;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class CounterButtonBehavior : CustomBehavior<CounterButtons>
    {
        private readonly IGeneralCounterSetting GeneralCounterSetting;
        private readonly ScoreCounter Counter;

        private IArrowSetting ArrowSetting
        {
            get
            {
                return GeneralCounterSetting.ArrowSetting;
            }
        }

        public CounterButtonBehavior(IGeneralCounterSetting generalCounterSetting, ScoreCounter scoreCounter)
        {
            GeneralCounterSetting = generalCounterSetting;
            Counter = scoreCounter;
        }

        protected override void OnAttachedTo(CounterButtons bindable)
        {
            base.OnAttachedTo(bindable);

            try
            {
                AssociatedObject.ButtonTap += AssociatedObject_ButtonTapped;
                AssociatedObject.GeneralCounterSetting = GeneralCounterSetting;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void AssociatedObject_ButtonTapped(object sender, EventArgs e)
        {
            if (Counter != null)
            {
                var view = sender as BindableObject;

                if (view.BindingContext is Arrow buttonArrow)
                {
                    var arrow = new Arrow(buttonArrow.Index, GeneralCounterSetting.ScoreResult.CurrentArrows.Count);
                    Counter.AddArrow(arrow);
                }
            }
        }
    }
}
