using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Specialized;
using ArcheryManager.Settings;

namespace ArcheryManager.Factories
{
    public static class ScoreListFactory
    {
        /// <summary>
        /// create score list
        /// scoreList items is currentarrows of counter
        /// Add selectableArrowInListBehavior to change the toolbar Items during selection
        /// </summary>
        public static ArrowUniformGrid Create(IGeneralCounterSetting generalCounterSetting, IList<ToolbarItem> toolbarItems)
        {
            var arrowSetting = generalCounterSetting.ArrowSetting;

            var scoreList = new ArrowUniformGrid { AutomationId = "scoreList", CountByRow = 6, ArrowSetting = arrowSetting };
            scoreList.Items = generalCounterSetting.ScoreResult.CurrentArrows;

            var selectBehavior = new SelectableArrowInListBehavior(toolbarItems, generalCounterSetting);
            scoreList.Behaviors.Add(selectBehavior);

            var orderBehavior = new ArrowListOrderedBehavior(generalCounterSetting);
            scoreList.Behaviors.Add(orderBehavior);
            return scoreList;
        }

        /// <summary>
        /// create score list
        /// scoreList items is currentarrows of counter
        /// Add selectableArrowInListBehavior to change the toolbar Items during selection
        /// change the color of arrows in the target during the selection of arrow
        /// </summary>
        public static ArrowUniformGrid Create(Target customTarget, IGeneralCounterSetting generalCounterSetting, IList<ToolbarItem> toolbarItems)
        {
            var scoreList = Create(generalCounterSetting, toolbarItems);
            var selectBehavior = scoreList.Behaviors.OfType<SelectableArrowInListBehavior>().First();

            return scoreList;
        }
    }
}
