using ArcheryManager.Utils;
using Xamarin.Forms;
using ArcheryManager.Settings;
using ArcheryManager.Interfaces;
using System;

namespace ArcheryManager.CustomControls
{
    public partial class CounterButtons : ContentView
    {
        private CounterButtonGenerator ButtonCounterGenerator;
        public EventHandler ButtonTap;

        public static readonly BindableProperty GeneralCounterSettingProperty =
                      BindableProperty.Create(nameof(GeneralCounterSetting), typeof(IGeneralCounterSetting), typeof(CounterButtons), null);

        public IGeneralCounterSetting GeneralCounterSetting
        {
            get { return (IGeneralCounterSetting)GetValue(GeneralCounterSettingProperty); }
            set
            {
                SetValue(GeneralCounterSettingProperty, value);
                ButtonCounterGenerator = new CounterButtonGenerator(GeneralCounterSetting.ArrowSetting);
                buttonGrid.ArrowSetting = ArrowSetting;
                buttonGrid.Items = ButtonCounterGenerator.GeneralButton();
            }
        }

        private IArrowSetting ArrowSetting
        {
            get
            {
                return GeneralCounterSetting.ArrowSetting;
            }
        }

        public CounterButtons()
        {
            InitializeComponent();
            buttonGrid.ItemAdded += ButtonGrid_ItemAdded;
        }

        private void ButtonGrid_ItemAdded(View ctn)
        {
            var recognizer = new TapGestureRecognizer();
            recognizer.Tapped += ButtonTap;
            ctn.GestureRecognizers.Add(recognizer);
        }
    }
}
