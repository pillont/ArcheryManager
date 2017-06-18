using ArcheryManager.Utils;

using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    // TODO remove

    public partial class CounterCommands : ContentView
    {
        public static readonly BindableProperty OrientationProperty =
                      BindableProperty.Create(nameof(Orientation), typeof(StackOrientation), typeof(CounterButtons), StackOrientation.Horizontal);

        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly BindableProperty CounterProperty =
                      BindableProperty.Create(nameof(Counter), typeof(ScoreCounter), typeof(CounterCommands), null);

        public ScoreCounter Counter
        {
            get { return (ScoreCounter)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public CounterCommands()
        {
            InitializeComponent();
            this.BindingContext = this;
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
