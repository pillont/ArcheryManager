using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class SelectableArrowInListBehavior : CustomBehavior<ArrowUniformGrid>
    {
        internal SelectionToolbarItemsController ToolbarItemsController;
        private readonly ScoreCounter Counter;

        public SelectableArrowInListBehavior(ScoreCounter counter)
        {
            Counter = counter;
        }

        public void ArrowRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var container = sender as View;

            var arrow = container.BindingContext as Arrow;
            arrow.IsSelected = !arrow.IsSelected;

            ToolbarItemsController.UpdateToolBarItems();
        }

        protected override void OnAttachedTo(ArrowUniformGrid list)
        {
            base.OnAttachedTo(list);

            var generator = new SelectionToolbarItemsGenerator(Counter, AssociatedObject);
            ToolbarItemsController = new SelectionToolbarItemsController(Counter, generator);
            generator.ButtonPressed += ToolbarItemsController.UpdateToolBarItems;

            AssociatedObject.ItemAdded += AssociatedObject_ItemAdded;
        }

        private void AssociatedObject_ItemAdded(View obj)
        {
            GestureHelper.AddTapGestureOn(obj, ArrowRecognizer_Tapped);
        }

        private bool ContainsInAssociatedObject(View a)
        {
            return AssociatedObject.Items.Contains(a.BindingContext as Arrow);
        }
    }
}
