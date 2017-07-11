using ArcheryManager.Utils;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using System.Runtime.CompilerServices;
using ArcheryManager.Interfaces;

namespace ArcheryManager.CustomControls
{
    public partial class CounterButtons : ContentView
    {
        public static readonly BindableProperty CounterProperty =
                      BindableProperty.Create(nameof(Counter), typeof(ScoreCounter), typeof(CounterButtons), null);

        public ScoreCounter Counter
        {
            get { return (ScoreCounter)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public CounterButtons()
        {
            InitializeComponent();
            buttonGrid.ItemAdded += ButtonGrid_ItemAdded;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Counter))
            {
                DrawButtons();
            }
        }

        //TODO Set behavior
        private void ButtonGrid_ItemAdded(View ctn)
        {
            var recognizer = new TapGestureRecognizer();
            recognizer.Tapped += Recognizer_Tapped;

            ctn.GestureRecognizers.Add(recognizer);
        }

        private void Recognizer_Tapped(object sender, EventArgs e)
        {
            if (Counter != null)
            {
                var view = sender as BindableObject;

                if (view.BindingContext is Arrow buttonArrow)
                {
                    var arrow = new Arrow(buttonArrow.Index, Counter.CurrentArrows.Count);
                    Counter.AddArrow(arrow);
                }
            }
        }

        private void DrawButtons()
        {
            var buttonsData = new ObservableCollection<Arrow>();

            for (int i = 1; i < Counter.ArrowSetting.ZoneCount; i++)
            {
                Arrow arrow = GetArrow(i);
                buttonsData.Add(arrow);
            }
            var missArrow = GetArrow(0);
            buttonsData.Add(missArrow);

            buttonGrid.Items = buttonsData;
        }

        private Arrow GetArrow(int i)
        {
            int numberInFlight = Counter.CurrentArrows.Count;
            var arrow = new Arrow(i, numberInFlight);
            return arrow;
        }
    }
}
