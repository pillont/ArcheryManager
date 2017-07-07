using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public class NumericPicker : Picker
    {
        private const double DefaultStep = 5;
        private const double DefaultfMin = 0;
        private const double DefaultMax = 10;

        public static readonly BindableProperty MaxProperty =
                      BindableProperty.Create(nameof(Max), typeof(double), typeof(NumericPicker), DefaultMax);

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly BindableProperty MinProperty =
                      BindableProperty.Create(nameof(Min), typeof(double), typeof(NumericPicker), DefaultfMin);

        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static readonly BindableProperty StepProperty =
                      BindableProperty.Create(nameof(Step), typeof(double), typeof(NumericPicker), DefaultStep);

        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public static readonly BindableProperty ItemsTimePickerProperty =
                      BindableProperty.Create(nameof(ItemsTimePicker), typeof(IList), typeof(NumericPicker), null);

        public IList ItemsTimePicker
        {
            get { return (IList)GetValue(ItemsTimePickerProperty); }
            set { SetValue(ItemsTimePickerProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Min)
            || propertyName == nameof(Max)
            || propertyName == nameof(Step))
            {
                RefreshItems();
            }
        }

        private void RefreshItems()
        {
            ItemsTimePicker = GenerateItems(Min, Max, Step);
            ItemsSource = ItemsTimePicker;
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
