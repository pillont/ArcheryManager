using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Specialized;
using ArcheryManager.Interfaces;

namespace ArcheryManager.Factories
{
    public static class ScoreListFactory
    {
        /// <summary>
        /// create score list
        /// scoreList items is currentarrows of counter
        /// Add selectableArrowInListBehavior to change the toolbar Items during selection
        /// </summary>
        public static ArrowUniformGrid Create(ScoreCounter counter, IList<ToolbarItem> toolbarItems, IArrowSetting setting)
        {
            var scoreList = new ArrowUniformGrid { AutomationId = "scoreList", CountByRow = 6, Setting = setting };
            scoreList.Items = counter.CurrentArrows;

            var selectBehavior = new SelectableArrowInListBehavior(toolbarItems);
            scoreList.Behaviors.Add(selectBehavior);

            return scoreList;
        }

        /// <summary>
        /// create score list
        /// scoreList items is currentarrows of counter
        /// Add selectableArrowInListBehavior to change the toolbar Items during selection
        /// change the color of arrows in the target during the selection of arrow
        /// </summary>
        public static ArrowUniformGrid Create(Target customTarget, ScoreCounter counter, IList<ToolbarItem> toolbarItems, IArrowSetting setting)
        {
            var scoreList = Create(counter, toolbarItems, setting);
            var selectBehavior = scoreList.Behaviors.OfType<SelectableArrowInListBehavior>().First();
            selectBehavior.ItemsSelectedChange += (s, e) => SelectBehavior_ItemsSelectedChange(customTarget, e);

            return scoreList;
        }

        /// <summary>
        /// update color of arrows in the target during the selection
        /// </summary>
        private static void SelectBehavior_ItemsSelectedChange(Target customTarget, NotifyCollectionChangedEventArgs e)
        {
            //reset selection
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                customTarget.ResetSelection();
            }
            // new selected element
            if (e.NewItems != null)
            {
                foreach (View v in e.NewItems)
                {
                    var a = v.BindingContext as Arrow;
                    customTarget.SelectArrow(a);
                }
            }
            // remove selected element
            if (e.OldItems != null)
            {
                foreach (View v in e.OldItems)
                {
                    var a = v.BindingContext as Arrow;
                    customTarget.UnSelectArrow(a);
                }
            }
        }
    }
}
