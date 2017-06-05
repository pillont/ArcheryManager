﻿using ArcheryManager.Utils;

using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public partial class TargetCommands : ContentView
    {
        public static readonly BindableProperty CounterProperty =
                      BindableProperty.Create(nameof(Counter), typeof(ScoreCounter), typeof(TargetCommands), null);

        public ScoreCounter Counter
        {
            get { return (ScoreCounter)GetValue(CounterProperty); }
            set
            {
                SetValue(CounterProperty, value);
            }
        }

        public TargetCommands()
        {
            InitializeComponent();
        }

        private void Button_RemoveLast(object sender, System.EventArgs e)
        {
            Counter.RemoveLastArrow();
        }

        private void Button_RemoveAll(object sender, System.EventArgs e)
        {
            Counter.ClearArrows();
        }

        private void Button_NewFlight(object sender, System.EventArgs e)
        {
            Counter.NewFlight();
        }
    }
}
