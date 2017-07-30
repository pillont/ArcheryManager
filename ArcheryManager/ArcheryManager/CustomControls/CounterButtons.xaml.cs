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

        private static readonly IGeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>();

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

            ButtonCounterGenerator = new CounterButtonGenerator(GeneralCounterSetting.ArrowSetting);
            buttonGrid.ArrowSetting = ArrowSetting;
            buttonGrid.Items = ButtonCounterGenerator.GeneralButton();
        }

        private void ButtonGrid_ItemAdded(View ctn)
        {
            var recognizer = new TapGestureRecognizer();
            recognizer.Tapped += Recognizer_Tapped;
            ctn.GestureRecognizers.Add(recognizer);
        }

        private void Recognizer_Tapped(object sender, EventArgs e)
        {
            ButtonTap(sender, e);
        }
    }
}
