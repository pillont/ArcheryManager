using ArcheryManager.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        public static readonly BindableProperty CounterProperty =
                              BindableProperty.Create(nameof(Counter), typeof(ScoreCounter), typeof(TargetPage), null);

        public ScoreCounter Counter
        {
            get { return (ScoreCounter)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public TargetPage(IArrowSetting setting)
        {
            InitializeComponent();
            this.BindingContext = this;
            Counter = new ScoreCounter();

            var list = Counter.Arrows;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = list;

            var selectBehavior = new SelectableArrowInListBehavior(unSelectButton, removeSelectionButton);
            scoreList.Behaviors.Add(selectBehavior);
            selectBehavior.ItemsSelectedChange += SelectBehavior_SelectionChange;

            customTarget.Items = list;
            customTarget.Setting = setting;

            var behavior = new MovableTargetBehavior(Counter);
            customTarget.Behaviors.Add(behavior);

            totalCounter.BindingContext = Counter;
        }

        private void SelectBehavior_SelectionChange(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                customTarget.ResetSelection();
            }
            if (e.NewItems != null)
            {
                foreach (View v in e.NewItems)
                {
                    var a = v.BindingContext as Arrow;
                    customTarget.SelectArrow(a);
                }
            }
            if (e.OldItems != null)
            {
                foreach (View v in e.OldItems)
                {
                    var a = v.BindingContext as Arrow;
                    customTarget.UnSelectArrow(a);
                }
            }
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }
    }
}
