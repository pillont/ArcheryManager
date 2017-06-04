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
            scoreList.Items = customTarget.Counter.Arrows;
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
