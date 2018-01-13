using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Factories
{
    public static class ScoreListFactory
    {
        /// <summary>
        /// create score list
        /// scoreList items is currentarrows of counter
        /// Add selectableArrowInListBehavior to change the toolbar Items during selection
        /// </summary>
        public static ArrowUniformGrid AddInScrollView(ScrollView scrollArrows)
        {
            var scoreList = CreateScoreList();

            scoreList.SizeChanged += (t, e) =>
            {
                scrollArrows.ScrollToAsync(scrollArrows.Content, ScrollToPosition.End, true);
            };

            scrollArrows.Content = scoreList;

            return scoreList;
        }

        public static ScoreList CreateScoreList()
        {
            var scoreList = ViewFactory.CreatePage<ScoreListCurrentArrowsViewModel, ScoreList>() as ScoreList;

            scoreList.AutomationId = "scoreList";
            scoreList.CountByRow = 6;
            var viewModel = Resolver.Resolve<ScoreListViewModel>();

            var counter = Resolver.Resolve<ScoreCounter>();
            var selectBehavior = new SelectableArrowInListBehavior(counter);
            scoreList.Behaviors.Add(selectBehavior);

            var orderBehavior = Resolver.Resolve<ArrowListOrderedBehavior>();
            scoreList.Behaviors.Add(orderBehavior);

            return scoreList;
        }
    }
}
