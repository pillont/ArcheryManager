using ArcheryManager.Factories;
using ArcheryManager.Utils;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace ArcheryManager.CustomControls
{
    public partial class CounterButtons : ContentView
    {
        public static readonly BindableProperty SettingProperty =
                      BindableProperty.Create(nameof(Setting), typeof(ArrowSetting), typeof(CounterButtons), null);

        public ArrowSetting Setting
        {
            get { return (ArrowSetting)GetValue(SettingProperty); }
            set { SetValue(SettingProperty, value); }
        }

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

            if (propertyName == nameof(Setting))
            {
                DrawButton(Setting);
            }
        }

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

                if (view.BindingContext is Arrow arrow)
                {
                    Counter.AddArrow(arrow);
                }
            }
        }

        private void DrawButton(ArrowSetting setting)
        {
            var buttonsData = new ObservableCollection<Arrow>();

            for (int i = 1; i < setting.ZoneCount; i++)
            {
                Arrow arrow = GetArrow(setting, i);
                buttonsData.Add(arrow);
            }
            var missArrow = GetArrow(setting, 0);
            buttonsData.Add(missArrow);

            buttonGrid.Items = buttonsData;
        }

        private static Arrow GetArrow(ArrowSetting setting, int i)
        {
            var score = setting.ScoreByIndex(i);
            var value = setting.ValueByScore(score);
            var color = setting.ColorOf(score);

            var arrow = new Arrow(score, value, color);
            return arrow;
        }
    }
}
