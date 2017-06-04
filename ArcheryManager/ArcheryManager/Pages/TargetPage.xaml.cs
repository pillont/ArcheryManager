using ArcheryManager.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        private ITargetWithInteraction target
        {
            get
            {
                return customTarget;
            }
        }

        public TargetPage()
        {
            InitializeComponent();
            var list = customTarget.Counter.Arrows;
            scoreList.Items = list;
            list.CollectionChanged += RowDefinitions_ItemSizeChanged;
        }

        private void RowDefinitions_ItemSizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }

        private void Button_RemoveLast(object sender, System.EventArgs e)
        {
            target.RemoveLastArrow();
        }

        private void Button_RemoveAll(object sender, System.EventArgs e)
        {
            target.ClearArrows();
        }
    }
}
