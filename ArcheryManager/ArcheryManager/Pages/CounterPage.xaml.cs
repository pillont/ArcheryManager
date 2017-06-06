using ArcheryManager.Factories;
using ArcheryManager.Utils;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        public CounterPage()
        {
            InitializeComponent();
            var counter = new ScoreCounter();
            totalCounter.BindingContext = counter;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = counter.Arrows;

            counterButtons.Counter = counter;
            counterButtons.Setting = ArrowSetting.EnglishInstance;

            counterCommands.Counter = counter;
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }
    }
}
