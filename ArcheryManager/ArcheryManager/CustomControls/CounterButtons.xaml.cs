using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterButtons : ContentView
    {
        public EventHandler ButtonTap;

        public CounterButtons()
        {
            InitializeComponent();

            buttonGrid.ItemAdded += ButtonGrid_ItemAdded;
        }

        public void ButtonGrid_ItemAdded(View ctn)
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

    public class CounterButtonsViewModel : ViewModel
    {
        public IArrowSetting ArrowSetting { get; private set; }
        public ObservableCollection<Arrow> Buttons { get; private set; }

        public CounterButtonsViewModel(CountedShoot shoot)
        {
            ArrowSetting = ArrowSettingFactory.Create(shoot.TargetStyle);

            Buttons = CounterButtonGenerator.GeneralButton(ArrowSetting);
        }
    }
}
