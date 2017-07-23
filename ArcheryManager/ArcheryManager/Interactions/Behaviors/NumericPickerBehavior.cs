using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class NumericPickerBehavior : CustomBehavior<Picker>
    {
        private const double DefaultStep = 5;
        private const double DefaultfMin = 0;
        private const double DefaultMax = 10;

        private readonly double Max;
        private readonly double Min;
        private readonly double Step;

        public NumericPickerBehavior(double min, double max, double step)
        {
            Max = max;
            Min = min;
            Step = step;
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            RefreshItems();
        }

        private void RefreshItems()
        {
            var items = GenerateItems();
            associatedObject.ItemsSource = items;
        }

        public IList GenerateItems()
        {
            var list = new List<double>();

            for (double i = Min; i <= Max; i += Step)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
