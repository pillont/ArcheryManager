using ArcheryManager.Behaviors;
using ArcheryManager.CustomControls.Targets;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        private ScoreCounter counter;

        public TargetPage()
        {
            InitializeComponent();

            counter = new ScoreCounter(customTarget.Factory);
            var list = counter.Arrows;
            scoreList.Items = list;
            customTarget.Items = list;
            list.CollectionChanged += RowDefinitions_ItemSizeChanged;

            var behavior = new MovableTargetBehavior<EnglishTarget>(counter);
            customTarget.Behaviors.Add(behavior);
        }

        private void RowDefinitions_ItemSizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        private void Button_RemoveLast(object sender, System.EventArgs e)
        {
            counter.RemoveLastArrow();
        }

        private void Button_RemoveAll(object sender, System.EventArgs e)
        {
            counter.ClearArrows();
        }
    }
}
