using ArcheryManager.Settings;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Interactions.Behaviors;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        private static readonly IArrowSetting EnglishSetting = EnglishArrowSetting.Instance;

        public CounterPage()
        {
            InitializeComponent();
            var counter = new ScoreCounter();
            totalCounter.BindingContext = counter;
            scoreList.SizeChanged += ScoreList_SizeChanged;
            scoreList.Items = counter.Arrows;

            counterButtons.Counter = counter;
            counterButtons.Setting = EnglishSetting;

            counterCommands.Counter = counter;

            var selectBehavior = new SelectableArrowInListBehavior();
            scoreList.Behaviors.Add(selectBehavior);
        }

        private void ScoreList_SizeChanged(object sender, System.EventArgs e)
        {
            scrollArrows.ScrollToAsync(scoreList, ScrollToPosition.End, true);
        }
    }
}
