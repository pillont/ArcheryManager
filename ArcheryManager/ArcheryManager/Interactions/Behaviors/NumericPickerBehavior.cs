using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            Min = min;
            Max = max;
            Step = step;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Min)
            || propertyName == nameof(Max)
            || propertyName == nameof(Step))
            {
                AssociatedObject.ItemsSource = GenerateItems(Min, Max, Step);
            }
        }

        public static IList GenerateItems(double min, double max, double step)
        {
            var list = new List<double>();

            for (double i = min; i <= max; i += step)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
